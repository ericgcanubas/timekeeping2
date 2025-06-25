using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    public partial class FrmPRW : Form
    {

        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 PRW_nID as ID,sEmpName ,nCtrlNo,dTransDate,sReasons FROM [tbl_PRW_NEW]  ");
        const string sSelectSql = "SELECT TOP 1 [PRW_nID] ,[nCtrlNo] ,[dTransDate] ,[nType] ,[EmpPK] ,[sEmpName] ,[sSection] ,[sBrand] ,[sALDates] ,[sReasons] ,[dStarting] ,[dEnding] ,[sATDNo] ,[nAmount] ,[sTransNo] ,[sVerBy] ,[sRecBy] ,[sNotBy1] ,[sAppBy] ,[sRelBy] ,[nDiscActType] ,[sSuspensionFor] ,[sSuspensionSked] ,[dTerminationDate] ,[sRemarks] ,[sPreBy] ,[sNotBy2] ,[sAppBy2] ,[sConfrm] ,[nPosted] ,[sLastUpdatedBy] ,[sNoOfDaysMins] ,[nFreq] FROM [tbl_PRW_NEW] ";

        public FrmPRW()
        {
            InitializeComponent();
        }
        private void setActionType(int DiscActType)
        {
            switch (DiscActType)
            {
                case 1:
                    rdbnCounsilingWarning.Checked = true;
                    break;
                case 2:
                    rdbnReprimand.Checked = true;
                    break;
                case 3:
                    rdbnSuspensionFor.Checked = true;
                    break;
                case 4:
                    rdbnWarningForTermination.Checked = true;
                    break;
                case 5:
                    rdbnTerminationEffectOn.Checked = true;
                    break;
                default:
                    break;
            }
            setActionTypeObjet(DiscActType);
        }

        private void setActionTypeObjet(int DiscActType)
        {
            if (!dtpdTransDate.Enabled)
            {
                return;
            }

            switch (DiscActType)
            {

                case 1:
                    txtsSuspensionFor.Enabled = false;
                    dtpsSuspensionSked.Enabled = false;
                    dtpdTerminationDate.Enabled = false;
                    break;
                case 2:

                    txtsSuspensionFor.Enabled = false;
                    dtpsSuspensionSked.Enabled = false;
                    dtpdTerminationDate.Enabled = false;
                    break;
                case 3:
                    txtsSuspensionFor.Enabled = true;
                    dtpsSuspensionSked.Enabled = true;
                    dtpdTerminationDate.Enabled = false;
                    break;
                case 4:
                    txtsSuspensionFor.Enabled = false;
                    dtpsSuspensionSked.Enabled = false;
                    dtpdTerminationDate.Enabled = false;
                    break;
                case 5:

                    txtsSuspensionFor.Enabled = false;
                    dtpsSuspensionSked.Enabled = false;
                    dtpdTerminationDate.Enabled = true;
                    break;
                default:
                    break;
            }



        }
        private void FrmPRW_Load(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (Tag != null)
            {
                //Viewing
                lblPRW_nID.Text = Tag.ToString();
                RefreshData();

            }

            if (AccessibleName != null)
            {
                // New
                SetNewData(AccessibleName.ToString());

            }

        }
        private bool SetNewData(string Value)
        {
            string strSelect = $@"SELECT PK, 
                                    EEmployeeIDNo,
                                    ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS Name,
                                    ELastName, 
                                    ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS EActive, 
                                    ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS Hired
                                    FROM tbl_Profile_IDNumber 
                                    WHERE PK = {Value} ";

            var empData = clsPayrollSystem.GetFirstRecord(strSelect);

            if (empData != null)
            {

                clsComponentControl.ClearValue(this);
                clsComponentControl.HeaderMenu(tsHeaderControl, false);
                clsComponentControl.ObjectEnable(this, true);

                lblsEmpName.Text = $"{empData["EEmployeeIDNo"].ToString()} - {empData["Name"].ToString()}";
                lblEmpPK.Text = empData["PK"].ToString();

                tsPosted.Visible = false;
                tsPost.Text = "Post";

                rdbLate.Checked = false;
                rdbAbsent.Checked = false;
                rdbLate.Checked = true;

                setActionType(1);
                return true;
            }

            return false;
        }
        private int CalculateFrequently()
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(txtsALDates.Text))
            {
                string[] dates = txtsALDates.Text.Split(',');
                for (int i = 0; i < dates.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(dates[i]))
                        result++;
                }
            }

            //for (int i = 0; i < gridDetails.Rows.Count; i++)
            //{
            //    result += string.IsNullOrWhiteSpace(gridDetails.Rows[i].Cells[7].Value.ToString()) ?
            //        0 : Convert.ToInt32(gridDetails.Rows[i].Cells[7].Value);
            //}
            return result;
        }

        private void Frequently(int count)
        {
            if (rdbAbsent.Checked)
            {
                if (count == 1)
                    rdbnReprimand.Checked = true;
                else if (count >= 2 && count <= 4)
                {
                    rdbnSuspensionFor.Checked = true;
                    txtsSuspensionFor.Text = "1";
                }
                else if (count >= 5 && count <= 7)
                {
                    rdbnSuspensionFor.Checked = true;
                    txtsSuspensionFor.Text = "2";
                }
                else if (count >= 8 && count <= 9)
                {
                    rdbnSuspensionFor.Checked = true;
                    txtsSuspensionFor.Text = "3";
                }
                else if (count == 10)
                    rdbnWarningForTermination.Checked = true;
                else if (count == 11)
                    rdbnTerminationEffectOn.Checked = true;
            }
            else if (rdbLate.Checked)
            {
                if (count <= 2)
                    rdbnCounsilingWarning.Checked = true;
                else if (count == 3)
                    rdbnReprimand.Checked = true;
                else if (count >= 4 && count <= 7)
                {
                    rdbnSuspensionFor.Checked = true;
                    txtsSuspensionFor.Text = "1/2";
                }
                else if (count >= 8 && count <= 11)
                {
                    rdbnSuspensionFor.Checked = true;
                    txtsSuspensionFor.Text = "1";
                }
                else if (count >= 12 && count <= 14)
                {
                    rdbnSuspensionFor.Checked = true;
                    txtsSuspensionFor.Text = "1 1/2";
                }
                else if (count == 15)
                {
                    rdbnWarningForTermination.Checked = true;
                }
                else if (count == 16)
                {
                    rdbnTerminationEffectOn.Checked = true;
                }
            }
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            if (!clsAccessControl.AccessRight(AccessibleDescription, "ADD"))
            {
                return;
            }

            RequestEmp();
        }
        private bool RequestEmp()
        {
            FrmEmployeeList frm = new FrmEmployeeList("Request");
            frm.ShowDialog();

            if (frm.VALUE != "")
            {
                return SetNewData(frm.VALUE);
            }

            return false;
        }

        private void rdbnCounsilingWarning_CheckedChanged(object sender, EventArgs e)
        {
            setActionTypeObjet(1);
        }

        private void rdbnReprimand_CheckedChanged(object sender, EventArgs e)
        {
            setActionTypeObjet(2);
        }

        private void rdbnSuspensionFor_CheckedChanged(object sender, EventArgs e)
        {
            setActionTypeObjet(3);
        }

        private void rdbnWarningForTermination_CheckedChanged(object sender, EventArgs e)
        {
            setActionTypeObjet(4);
        }

        private void rdbnTerminationEffectOn_CheckedChanged(object sender, EventArgs e)
        {
            setActionTypeObjet(5);
        }
        private void RefreshData()
        {
            string squery = $@"{sSelectSql} WHERE PRW_nID = {lblPRW_nID.Text}";
            DataRecord(squery);
        }
        private void DataRecord(string squery)
        {
            var data = clsBiometrics.GetFirstRecord(squery);
            if (data != null)
            {
                clsComponentControl.AssignValue(this, data);
                int postValue = int.Parse(data["nPosted"].ToString());
                tsPosted.Visible = postValue == 1 ? true : false;
                tsPost.Text = postValue == 1 ? "Unpost" : "Post";

                tsEdit.Enabled = postValue == 1 ? false : true;
                tsDelete.Enabled = postValue == 1 ? false : true;
                int type = int.Parse(data["nType"].ToString());
                setType(type);

            }
        }

        private void setType(int type)
        {
            if (type == 1)
            {
                rdbAbsent.Checked = true;

                return;
            }

            rdbLate.Checked = true;


        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblPRW_nID.Text.Length > 0)
            {
                RefreshData();
            }
            else
            {
                clsComponentControl.ClearValue(this);
                tsPosted.Visible = false;
                tsPost.Text = "Post";

                rdbLate.Checked = false;
                rdbAbsent.Checked = false;
                rdbLate.Checked = true;

            }
        }

        private void tsFirst_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql} ORDER BY nCtrlNo ";
            DataRecord(squery);
        }

        private void tsBack_Click(object sender, EventArgs e)
        {
            if (lblnCtrlNo.Text.Length == 0)
            {
                tsFirst.PerformClick();
                return;
            }
            string squery = $@"{sSelectSql} WHERE nCtrlNo < '{lblnCtrlNo.Text}'  ORDER BY nCtrlNo DESC ";
            DataRecord(squery);
        }

        private void tsNext_Click(object sender, EventArgs e)
        {
            if (lblnCtrlNo.Text.Length == 0)
            {
                tsLast.PerformClick();
                return;
            }
            string squery = $@"{sSelectSql} WHERE  nCtrlNo > '{lblnCtrlNo.Text}' ORDER BY nCtrlNo  ";
            DataRecord(squery);
        }

        private void tsLast_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql} ORDER BY nCtrlNo desc ";
            DataRecord(squery);
        }

        private void tsFind_Click(object sender, EventArgs e)
        {
            frmFind.ShowDialog();
            if (frmFind.isYes == true)
            {
                frmFind.isYes = false;
                clsComponentControl.ClearValue(this);
                lblPRW_nID.Text = frmFind.PK;
                RefreshData();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            if (lblPRW_nID.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(AccessibleDescription, "EDIT"))
            {
                return;
            }


            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (lblPRW_nID.Text.Length == 0)
            {
                return;
            }
            if (!clsAccessControl.AccessRight(AccessibleDescription, "DELETE"))
            {
                return;
            }
            if (clsMessage.MessageQuestionWarning("ARE YOU SURE IN DELETING THIS RECORD? "))
            {
                clsBiometrics.ExecuteNonQuery($@"Delete From tbl_PRW_NEW WHERE PRW_nID = {lblPRW_nID.Text}");
                clsComponentControl.ClearValue(this);
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (lblEmpPK.Text.Length == 0) { clsMessage.MessageShowWarning("Please Select Employee Request !"); return; };
            if (txtsReasons.Text.Length == 0) { clsMessage.MessageShowWarning("Please Enter an Reason!"); return; }

            int nType = rdbAbsent.Checked ? 1 : 2;


            string[] dates = txtsALDates.Text.Split(',');
            string dStarting, dEnding;
            // Trim spaces and remove empty entries
            dates = dates.Where(d => !string.IsNullOrWhiteSpace(d)).Select(d => d.Trim()).ToArray();

            dStarting = dates[0];
            dEnding = dates[dates.Length - 1];
            int nDiscActType = 1;
            int nFreq = 1;
            string sLastUpdatedBy = clsDateTime.LastModify();
            if (lblPRW_nID.Text.Length == 0)
            {
                int nCtrlNo = 1;
                var data = clsBiometrics.GetFirstRecord($"select top 1 nCtrlNo from tbl_PRW_NEW order by nCtrlNo desc");
                if (data != null)
                {
                    nCtrlNo = int.Parse(data["nCtrlNo"].ToString()) + 1;
                }

                string sSection = "";
                string sBrand = "";


                object ID = clsBiometrics.ExecuteScalarQuery($@"INSERT INTO [tbl_PRW_NEW] (
                                                                 [nCtrlNo], [dTransDate], [nType], [EmpPK], [sEmpName], [sSection],
                                                                [sBrand], [sALDates], [sReasons], [dStarting], [dEnding], [sATDNo],
                                                                [nAmount], [sTransNo], [sVerBy], [sRecBy], [sNotBy1], [sAppBy], [sRelBy],
                                                                [nDiscActType], [sSuspensionFor], [sSuspensionSked], [dTerminationDate],
                                                                [sRemarks], [sPreBy], [sNotBy2], [sAppBy2], [sConfrm], [nPosted],
                                                                [sLastUpdatedBy], [sNoOfDaysMins], [nFreq])
                                                            VALUES (
                                                                 {nCtrlNo}, {clsMisc.SQL_Date(dtpdTransDate)}, {nType}, {lblEmpPK.Text}, '{lblsEmpName.Text}', '{sSection}', '{sBrand}', '{txtsALDates.Text}',
                                                                '{txtsReasons.Text}', '{dStarting}', '{dEnding}', '', 0, '','{txtsVerBy.Text}', '{txtsRecBy.Text}', '{txtsNotBy1.Text}', '{txtsAppBy.Text}', 
                                                                '{txtsRelBy.Text}', {nDiscActType}, '{txtsSuspensionFor.Text}', '{dtpsSuspensionSked.Value}', '{dtpdTerminationDate.Value}', '{txtsRemarks.Text}', '{txtsPreBy.Text}', '{txtsNotBy2.Text}', '{txtsAppBy2.Text}', '{txtsConfrm.Text}', 0, '{sLastUpdatedBy}', '{lblsNoOfDaysMins.Text}', {nFreq});");



                if (ID == null)
                {
                    return;
                }

                lblPRW_nID.Text = ID.ToString();
                tsCancel.PerformClick();

            }
            else
            {
                bool isUpdate = clsBiometrics.ExecuteNonQueryBool($@"UPDATE [tbl_PRW_NEW]
                                                                        SET
                                                                 
                                                                            [nType] = {nType},
                                                                            [sALDates] = '{txtsALDates.Text}',
                                                                            [sReasons] = '{txtsReasons.Text}',
                                                                            [dStarting] = '{dStarting}',
                                                                            [dEnding] = '{dEnding}',
                                                                            [sATDNo] = '',
                                                                            [nAmount] = 0,
                                                                            [sTransNo] = '',
                                                                            [sVerBy] = '{txtsVerBy.Text}',
                                                                            [sRecBy] = '{txtsRecBy.Text}',
                                                                            [sNotBy1] = '{txtsNotBy1.Text}',
                                                                            [sAppBy] = '{txtsAppBy.Text}',
                                                                            [sRelBy] = '{txtsRelBy.Text}',
                                                                            [nDiscActType] = {nDiscActType},
                                                                            [sSuspensionFor] = '{txtsSuspensionFor.Text}',
                                                                            [sSuspensionSked] = '{dtpsSuspensionSked.Value}',
                                                                            [dTerminationDate] = '{dtpdTerminationDate.Value}',
                                                                            [sRemarks] = '{txtsRemarks.Text}',
                                                                            [sPreBy] = '{txtsPreBy.Text}',
                                                                            [sNotBy2] = '{txtsNotBy2.Text}',
                                                                            [sAppBy2] = '{txtsAppBy2.Text}',
                                                                            [sConfrm] = '{txtsConfrm.Text}',
                                                                            [sLastUpdatedBy] = '{sLastUpdatedBy}',
                                                                            [sNoOfDaysMins] = '{lblsNoOfDaysMins.Text}',
                                                                            [nFreq] = {nFreq}
                                                                        WHERE [PRW_nID] = {lblPRW_nID.Text};");

                if(isUpdate == true)
                {
                    tsCancel.PerformClick();
                }
             


            }
        }
        private void lblsEmpName_Click(object sender, EventArgs e)
        {
            clsMenu.OpenProifile(lblEmpPK.Text);
        }

        private void FrmPRW_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    tsAdd.PerformClick();
                    break;
                case Keys.F2:
                    tsEdit.PerformClick();
                    break;
                case Keys.Delete:
                    tsDelete.PerformClick();
                    break;
                case Keys.F5:
                    tsSave.PerformClick();
                    break;
                case Keys.Escape:
                    if (tsCancel.Enabled)
                    {
                        tsCancel.PerformClick();
                    }
                    else
                    {
                        tsClose.PerformClick();
                    }
                    break;
                case Keys.F6:
                    tsFind.PerformClick();
                    break;
                case Keys.PageUp:
                    tsBack.PerformClick();
                    break;

                case Keys.PageDown:
                    tsNext.PerformClick();
                    break;
                case Keys.Home:
                    tsFirst.PerformClick();
                    break;
                case Keys.End:
                    tsLast.PerformClick();
                    break;
                case Keys.F9:
                    tsPrint.PerformClick();
                    break;
                case Keys.F8:
                    tsPost.PerformClick();
                    break;
                default:
                    // Nothing
                    break;

            }
        }

        private void rdbLate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLate.Enabled == false || rdbLate.Checked == false)
            {
                return;
            }
            GetDayOfLate();
            Frequently(CalculateFrequently());
        }

        private void rdbAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAbsent.Enabled == false || rdbAbsent.Checked == false)
            {
                return;
            }

            GetDayOfAbsent();
            Frequently(CalculateFrequently());
        }
        public void GetDayOfLate()
        {
            string result = string.Empty;
            string query = $"SELECT  top 1  Pk,EmpNo,EmpId,EmpName,EffectDate,Sunday,Monday,Tuesday ,Wednesday,Thursday,Friday,Saturday,MachineId ,MachineNo,Restday,LastModified FROM EmployeeShifting where 1=1  and EmpNo = {lblEmpPK.Text}  and EffectDate <= GETDATE()  order by EffectDate desc ";
            var currEmployeeShifting = clsBiometrics.GetFirstRecord(query);
            if (currEmployeeShifting != null)
            {
                clsDateTime dt = new clsDateTime();
                DateTime serverDate = dt.ServerDate();
                int shiftID = 0;
                switch (serverDate.DayOfWeek)
                {
                    case DayOfWeek.Monday: shiftID = int.Parse(currEmployeeShifting["Monday"].ToString()); break;
                    case DayOfWeek.Tuesday: shiftID = int.Parse(currEmployeeShifting["Tuesday"].ToString()); break;
                    case DayOfWeek.Wednesday: shiftID = int.Parse(currEmployeeShifting["Wednesday"].ToString()); break;
                    case DayOfWeek.Thursday: shiftID = int.Parse(currEmployeeShifting["Thursday"].ToString()); break;
                    case DayOfWeek.Friday: shiftID = int.Parse(currEmployeeShifting["Friday"].ToString()); break;
                    case DayOfWeek.Saturday: shiftID = int.Parse(currEmployeeShifting["Saturday"].ToString()); break;
                    case DayOfWeek.Sunday: shiftID = int.Parse(currEmployeeShifting["Sunday"].ToString()); break;
                }


                var schedule = clsBiometrics.GetFirstRecord($"SELECT TOP 1 [PK] ,[ShiftName] ,[ShiftType] ,[IN_AM] ,[OUT_Lunch] ,[IN_Lunch] ,[OUT_Break] ,[IN_Break] ,[OUT_PM] ,[LastModifiedBy] ,[Fixed] ,[Lunch] ,[BreakTime] ,[Add_Edit] ,[Status] ,[ScheduleType] FROM [ShiftingSchedule] WHERE PK = {shiftID}");
                if (schedule != null)
                {
                    TimeSpan time = new TimeSpan();

                    TimeSpan AMIn = TimeSpan.Parse(clsMisc.FX_TIME_EMPTY(schedule["IN_AM"].ToString()));

                    TimeSpan LunchOut = TimeSpan.Parse(clsMisc.FX_TIME_EMPTY(schedule["OUT_Lunch"].ToString()));
                    TimeSpan LunchIn = TimeSpan.Parse(clsMisc.FX_TIME_EMPTY(schedule["IN_Lunch"].ToString()));


                    TimeSpan CoffeeOut = TimeSpan.Parse(clsMisc.FX_TIME_EMPTY(schedule["OUT_Break"].ToString()));
                    TimeSpan CoffeeIn = TimeSpan.Parse(clsMisc.FX_TIME_EMPTY(schedule["IN_Break"].ToString()));


                    TimeSpan PmOut = TimeSpan.Parse(clsMisc.FX_TIME_EMPTY(schedule["OUT_PM"].ToString()));

                    int Lunchtime = int.Parse(schedule["Lunch"].ToString());
                    int Breaktime = int.Parse(schedule["BreakTime"].ToString());
                    bool IsFixed = bool.Parse((schedule["Fixed"].ToString() == "1" ? "true" : "false"));

                    switch (int.Parse(schedule["ScheduleType"].ToString()))
                    {
                        case 1:
                            if (serverDate.TimeOfDay >= CoffeeIn)
                            {
                                time = LunchOut.Subtract(AMIn).Add(CoffeeOut.Subtract(LunchIn)).Add(serverDate.TimeOfDay.Subtract(CoffeeIn));
                            }
                            else if (serverDate.TimeOfDay >= CoffeeOut)
                            {
                                time = LunchOut.Subtract(AMIn).Add(CoffeeOut.Subtract(LunchIn));
                            }
                            else if (serverDate.TimeOfDay >= LunchIn)
                            {
                                time = LunchOut.Subtract(AMIn).Add(serverDate.TimeOfDay.Subtract(LunchIn));
                            }
                            else if (serverDate.TimeOfDay >= LunchOut)
                            {
                                time = LunchOut.Subtract(AMIn);
                            }
                            else if (serverDate.TimeOfDay > AMIn)
                            {
                                time = serverDate.TimeOfDay.Subtract(AMIn);
                            }
                            break;
                        case 2:
                            if (serverDate.TimeOfDay >= CoffeeIn)
                            {
                                time = CoffeeOut.Subtract(AMIn).Add(serverDate.TimeOfDay.Subtract(CoffeeIn));
                            }
                            else if (serverDate.TimeOfDay >= CoffeeOut)
                            {
                                time = CoffeeOut.Subtract(AMIn);
                            }
                            else if (serverDate.TimeOfDay > AMIn)
                            {
                                time = serverDate.TimeOfDay.Subtract(AMIn);
                            }
                            break;
                        case 3:
                            if (serverDate.TimeOfDay >= LunchIn)
                            {
                                time = LunchOut.Subtract(AMIn).Add(serverDate.TimeOfDay.Subtract(LunchIn));
                            }
                            else if (serverDate.TimeOfDay >= LunchOut)
                            {
                                time = LunchOut.Subtract(AMIn);
                            }
                            else if (serverDate.TimeOfDay > AMIn)
                            {
                                time = serverDate.TimeOfDay.Subtract(AMIn);
                            }
                            break;
                        case 4:

                            time = serverDate.TimeOfDay.Subtract(AMIn);
                            break;

                        default:
                            break;
                    }


                    result = time.Hours > 1 ? time.Hours + " hrs " + time.Minutes + (time.Minutes > 1 ? " mins" : " min") :
                                time.Hours + " hr " + time.Minutes + (time.Minutes > 1 ? " mins" : " min");

                    txtsALDates.Text = serverDate.ToString("MM/dd/yyyy hh:mm tt");
                    lblsNoOfDaysMins.Text = result;
                }
                else
                {
                    MessageBox.Show("No Shifting Schedule Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void GetDayOfAbsent()
        {
            clsDateTime dt = new clsDateTime();

            DateTime serverDate = dt.ServerDate();
            string allData = string.Empty;
            string result = string.Empty;
            int count = 0;
            DateTime date = serverDate.AddDays(-1);
            string holidayType = string.Empty;
            while (true)
            {
                if (IsEmployeeHasTransactionLog(date, int.Parse(lblEmpPK.Text)) == false)
                {
                    if (IsRestday(date, int.Parse(lblEmpPK.Text)) == false)
                    {
                        if (IsEmployeeHoliday(date, int.Parse(lblEmpPK.Text), out holidayType) == false)
                        {
                            if (IsLeave(date, int.Parse(lblEmpPK.Text)) == false)
                            {
                                count++;
                                if (string.IsNullOrWhiteSpace(allData))
                                    allData = date.ToString("MM/dd/yyyy");
                                else
                                    allData += "," + date.ToString("MM/dd/yyyy");
                            }
                        }
                    }
                }
                else
                    break;

                date = date.AddDays(-1);
            }

            result = count > 1 ? count + " Days" : count + " Day";


            txtsALDates.Text = allData;
            lblsNoOfDaysMins.Text = result;


        }
        private bool IsRestday(DateTime date, int empId)
        {
            string query = "declare @date date = '" + date.ToShortDateString() + "'; " +
                          "declare @empPK int = " + empId + " " +
                          "select a.EmpNo,a.Restday " +
                          "from ( " +
                           "select a.EmpNo,isnull(b.ToDay,a.RestDay) Restday " +
                           "from ( " +
                               "select EmpNo,RestDay, " +
                                      "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
                               "from EmployeeShifting " +
                               "where EmpNo = @empPK and cast(EffectDate as date) <= cast(@date as date) ) a " +
                           "left join (select EmpPK = case when EmpPK = @empPK " +
                                                             "then @empPK else EmpPKWith end, " +
                                          "dReqDateFrom,dReqDateTo, " +
                                          "FromDay = case when EmpPK = @empPK " +
                                                         "then " +
                                                             "case when DATEPART(W,dReqDateFrom) = 1 " +
                                                                 "then 7 else (DATEPART(W,dReqDateFrom) - 1) end " +
                                                         "else " +
                                                             "case when DATEPART(W,dExDateFrom) = 1 " +
                                                                 "then 7 else (DATEPART(W,dExDateFrom) - 1) end " +
                                                     "end, " +
                                          "ToDay = case when EmpPK = @empPK " +
                                                      "then " +
                                                         "case when DATEPART(W,dReqDateTo) = 1 " +
                                                             "then 7 else (DATEPART(W,dReqDateTo) -1) end " +
                                                      "else " +
                                                         "case when DATEPART(W,dReqDateTo) = 1 " +
                                                             "then 7 else (DATEPART(W,dExDateTo) -1) end " +
                                                  "end " +
                                     "from tbl_CHANGERESTDAY " +
                                     "where (cast(dReqDateTo as date) = cast(@date as date) " +
                                     "or cast(dReqDateFrom as date) = cast(@date as date)) " +
                                     "and nPosted = 1 and nCancelled = 0 and (EmpPK = @empPK or EmpPKWith = @empPK)) b " +
                           "on a.EmpNo = b.EmpPK " +
                           "where a.Row = 1 ) a  " +
                          "where a.Restday = case when DATEPART(W,cast(@date as date)) = 1 " +
                                          "then 7 else (DATEPART(W,cast(@date as date)) - 1) end ";


            var data = clsBiometrics.GetFirstRecord(query);

            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool IsEmployeeHasTransactionLog(DateTime actualDate, int empPk)
        {


            string query = "SELECT TOP 1 PK,EmpPK,MachineNo,MachineID,Actual_Date, " +
                            "Actual_Time,InOutMode,EntryMode,Posted,EmployeeName " +
                           "FROM tbl_TransactionLog " +
                           "where EmpPK= " + empPk + "  and  Actual_Date='" + actualDate.ToShortDateString() + "'";

            var d = clsBiometrics.GetFirstRecord(query);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool IsEmployeeHoliday(DateTime date, int empId, out string holidayType)
        {
            string query = "SELECT TOP 1 a.HolidayEmployeesPk,a.EmpId,a.IsHolidayDuty,b.HolidayType " +
                           "FROM tbl_HolidayEmployees a " +
                           "join dbo.tbl_HolidayName b on a.HolidayNamePk = b.HolidayNamePk " +
                           "where b.HolidayDate = '" + date.ToShortDateString() + "' and a.EmpId =" + empId + " and IsHolidayDuty = 0 ";

            var d = clsBiometrics.GetFirstRecord(query);

            if (d != null)
            {
                holidayType = d["HolidayType"].ToString();
                return true;
            }
            else
            {
                holidayType = string.Empty;
                return false;
            }
        }

        public static bool IsLeave(DateTime date, int empId)
        {
            string query = "select TOP 1 a.EmpPK " +
                           "from tbl_LEAVE_UNDERTIME a " +
                           "where a.nType = 1 and a.EffectDates like '%" + date.ToString("MM/dd/yyyy") + "%' " +
                           "and a.nPosted = 1 and a.nCancelled = 0 and a.EmpPK =" + empId + " ";

            var d = clsBiometrics.GetFirstRecord(query);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void tsPost_Click(object sender, EventArgs e)
        {
            if (lblPRW_nID.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "POST"))
            {
                return;
            }


            if (tsPosted.Visible)
            {
                if (!clsMessage.MessageQuestion("ARE YOU SURE TO UNPOST THIS TRANSACTION?"))
                {
                    return;
                }
            }
            else
            {
                if (!clsMessage.MessageQuestion("ARE YOU SURE TO POST THIS TRANSACTION? "))
                {
                    return;
                }
            }

            clsBiometrics.ExecuteNonQueryBool($"UPDATE tbl_PRW_NEW SET nPosted = {(tsPosted.Visible ? 0 : 1)} WHERE (PRW_nID = {lblPRW_nID.Text} ) ");
            RefreshData();
        }
    }
}
