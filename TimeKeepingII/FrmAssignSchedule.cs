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
    public partial class FrmAssignSchedule : Form
    {
        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 EmployeeShifting.PK, EmployeeName.EmpName,  EmployeeName.EmpID, EmployeeShifting.EffectDate  FROM EmployeeShifting LEFT OUTER JOIN EmployeeName ON EmployeeShifting.EmpNo = EmployeeName.EmpPK ");
        readonly string sSelectSql = "SELECT EmployeeShifting.*, EmployeeName.EmpName as EmployeeName,  EmployeeName.EmpID as EMPLOYEE_NO, EmployeeName.EmpPK as  EMP_PK  FROM EmployeeShifting LEFT JOIN  EmployeeName ON EmployeeShifting.EmpNo = EmployeeName.EmpPK ";

        public FrmAssignSchedule()
        {
            InitializeComponent();
        }
        private void FrmAssignSchedule_Load(object sender, EventArgs e)
        {
            CustomDataTable();
            LoadShift();
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            clsComponentControl.ClearValue(this);

            OpenLoad();

            if (this.Tag != null)
            {
                //view
                lblPK.Text = this.Tag.ToString();
                RefreshData();

            }

            if (this.AccessibleName != null)
            {
                // create
                SetNewData(this.AccessibleName.ToString());
            }

        }
        private void CustomDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(int));
            dt.Columns.Add("Text", typeof(string));

            dt.Rows.Add(1, "1st FLOOR");
            dt.Rows.Add(2, "2nd FLOOR");
            dt.Rows.Add(3, "3rd FLOOR");
            dt.Rows.Add(4, "MANILA");

            clsTool.ComboBoxDataLoad(cmbMachineNo, dt, "Text", "Value");
        }
        private void OpenLoad()
        {
            OpenMonday();
            OpenTuesday();
            OpenWednesday();
            OpenThursday();
            OpenFriday();
            OpenSaturday();
            OpenSunday();
        }
        private void tsAdd_Click(object sender, EventArgs e)
        {
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "ADD"))
            {
                return;
            }

            FrmEmployeeList frm = new FrmEmployeeList();
            frm.ShowDialog();

            if (frm.VALUE != "")
            {
            
                SetNewData(frm.VALUE);
            }
        }
        private void SetNewData(string id)
        {
            string strSelect = $@"SELECT PK, 
                                    EEmployeeIDNo,
                                    ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS Name,
                                    ELastName, 
                                    ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS EActive, 
                                    ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS Hired
                                    FROM tbl_Profile_IDNumber 
                                    WHERE PK = {id} ";

            var empData = clsPayrollSystem.GetFirstRecord(strSelect);
            if (empData != null)
            {

                clsComponentControl.HeaderMenu(tsHeaderControl, false);
                clsComponentControl.ObjectEnable(this, true);
                clsComponentControl.ClearValue(this);
                OpenLoad();
                lblEMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                lblEmployeeName.Text = empData["Name"].ToString();
                lblEMP_PK.Text = empData["PK"].ToString();

            }
        }
        private void LoadShift()
        {
            string ShiftingSchedule = $@"SELECT [PK],[ShiftName] From ShiftingSchedule";
            DataTable dt = clsBiometrics.dataList(ShiftingSchedule);
            ComboBox[] dayCombos = { cmbMonday, cmbTuesday, cmbWednesday, cmbThursday, cmbFriday, cmbSaturday, cmbSunday };
            foreach (var cmb in dayCombos)
            {
                clsTool.ComboBoxDataLoad(cmb, dt, "ShiftName", "PK");
            }



        }
        private void RefreshData()
        {

            RestDayResetter(null);
            string squery = $@"{sSelectSql}  WHERE EmployeeShifting.PK = {lblPK.Text} ORDER BY EmployeeShifting.PK  ";
            DataRecord(squery);
            checkOpen();
        }
        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblPK.Text.Length > 0)
            {

                RefreshData();
            }
            else
            {
                clsComponentControl.ClearValue(this);
            }



        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            if (cmbMachineNo.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Select Machine Number!"); return; }
            if (dtpEffectDate.Checked == false) { clsMessage.MessageShowWarning("Please Supply Date Effectively!"); return; }

            if (numMachineID.Value == 0) { clsMessage.MessageShowWarning("Please Supply Machine ID!"); return; }
            if (chkOpenMon.Checked == false && cmbMonday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Monday Shifting Schedule!"); return; }
            if (chkOpenTue.Checked == false && cmbTuesday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Tuesday Shifting Schedule!"); return; }
            if (chkOpenWed.Checked == false && cmbWednesday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Wednesday Shifting Schedule!"); return; }
            if (chkOpenThu.Checked == false && cmbThursday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Thursday Shifting Schedule!"); return; }
            if (chkOpenFri.Checked == false && cmbFriday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Friday Shifting Schedule!"); return; }
            if (chkOpenSat.Checked == false && cmbSaturday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Saturday Shifting Schedule!"); return; }
            if (chkOpenSun.Checked == false && cmbSunday.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Supply Sunday Shifting Schedule!"); return; }
            if (GetDayOff() == "") { clsMessage.MessageShowWarning("Please Select Restday!"); return; }


            // initialize value
            string LastModify = clsDateTime.LastModify();
            object SundayID = (!chkOpenSun.Checked ? cmbSunday.SelectedValue : 0);
            object MondayID = (!chkOpenMon.Checked ? cmbMonday.SelectedValue : 0);
            object TuesdayID = (!chkOpenTue.Checked ? cmbTuesday.SelectedValue : 0);
            object WednesdayID = (!chkOpenWed.Checked ? cmbWednesday.SelectedValue : 0);
            object ThursdayID = (!chkOpenThu.Checked ? cmbThursday.SelectedValue : 0);
            object FridayID = (!chkOpenFri.Checked ? cmbFriday.SelectedValue : 0);
            object Saturday = (!chkOpenSat.Checked ? cmbSaturday.SelectedValue : 0);


            if (lblPK.Text.Length == 0) // INSERT
            {
                object ID = clsBiometrics.ExecuteScalarQuery($@"INSERT INTO EmployeeShifting
                     (EmpNo, EmpID, EmpName, EffectDate, 
                     MachineID, MachineNo, Sunday, Monday, 
                     Tuesday, Wednesday, Thursday, Friday, 
                     Saturday, DayOff, LastModified, Added)
                     VALUES
                    ({lblEMP_PK.Text},'{lblEMPLOYEE_NO.Text}','{lblEmployeeName.Text}','{dtpEffectDate.Value}',
                    {numMachineID.Value},{cmbMachineNo.SelectedValue},{SundayID},{MondayID},
                    {TuesdayID},{WednesdayID},{ThursdayID},{FridayID},
                    {Saturday},'{GetDayOff()}','{LastModify}',1)");

                if (ID == null)
                {
                    return;
                }

                int PK = Convert.ToInt32(ID);
                if (PK > 0)
                {
                    lblPK.Text = PK.ToString();
                    updateProfile();
                    tsCancel.PerformClick();

                }

            }
            else
            {
                // UPDATE

                bool isSuccess = clsBiometrics.ExecuteNonQueryBool($@"UPDATE EmployeeShifting
                    SET EmpNo = {lblEMP_PK.Text}, EmpID = '{lblEMPLOYEE_NO.Text}',
                        EmpName = '{lblEmployeeName.Text}', EffectDate = '{dtpEffectDate.Value}', 
                        MachineID ={numMachineID.Value}, MachineNo = {cmbMachineNo.SelectedValue} , 
                        Sunday = { SundayID}, Monday = {MondayID},
                        Tuesday = { TuesdayID}, Wednesday = { WednesdayID},
                        Thursday = {ThursdayID}, Friday = {FridayID}, 
                        Saturday = {Saturday}, DayOff = '{GetDayOff()}', 
                        LastModified = '{LastModify}', Editted = 0 
                        WHERE (PK ={lblPK.Text})");

                if (isSuccess)
                {
                    updateProfile();
                    tsCancel.PerformClick();
                }

            }


        }
        private void updateProfile()
        {
            var payData = clsPayrollSystem.GetFirstRecord($@"SELECT TOP 1 ProfilePK FROM tbl_Profile_IDNumber  WHERE (PK = {lblEMP_PK.Text}) ");
            if (payData != null)
            {
                clsBiometrics.ExecuteNonQueryBool($@" UPDATE EmployeeName SET Privilege = 0, ProfilePK={payData["ProfilePK"].ToString()} WHERE (EmpPK = {lblEMP_PK.Text})");
            }
        }
        private string GetDayOff()
        {
            int t = 0;
            string dfData = "";
            CheckBox[] rd = { chkRestday1, chkRestday2, chkRestday3, chkRestday4, chkRestday5, chkRestday6, chkRestday7 };
            foreach (var r in rd)
            {
                t++;
                if (r.Checked)
                {
                    if (dfData == "")
                    {
                        dfData = $"{t}";
                    }
                    else
                    {
                        dfData = dfData + $",{t}";
                    }
                }
            }

            return dfData;
        }
        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsEdit_Click(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {
                if (!clsAccessControl.AccessRight(this.AccessibleDescription, "EDIT"))
                {
                    return;
                }
                clsComponentControl.HeaderMenu(tsHeaderControl, false);
                clsComponentControl.ObjectEnable(this, true);
            }



            //OpenLoad();
        }
        private void OpenMonday()
        {

            if (chkOpenMon.Enabled == false)
            {
                return;
            }
            cmbMonday.Enabled = !chkOpenMon.Checked;
            if (chkOpenMon.Checked)
            {
                cmbMonday.SelectedIndex = -1;
            }



        }
        private void OpenTuesday()
        {

            if (chkOpenTue.Enabled == false)
            {
                return;
            }

            cmbTuesday.Enabled = !chkOpenTue.Checked;


            if (chkOpenTue.Checked)
            {
                cmbTuesday.SelectedIndex = -1;
            }

        }
        private void OpenWednesday()
        {
            if (chkOpenWed.Enabled == false)
            {
                return;
            }

            cmbWednesday.Enabled = !chkOpenWed.Checked;
            if (chkOpenWed.Checked)
            {
                cmbWednesday.SelectedIndex = -1;
            }

        }
        private void OpenThursday()
        {
            if (chkOpenThu.Enabled == false)
            {
                return;
            }

            cmbThursday.Enabled = !chkOpenThu.Checked;
            if (chkOpenThu.Checked)
            {
                cmbThursday.SelectedIndex = -1;
            }

        }
        private void OpenFriday()
        {
            if (chkOpenFri.Enabled == false)
            {
                return;
            }

            cmbFriday.Enabled = !chkOpenFri.Checked;
            if (chkOpenFri.Checked)
            {
                cmbFriday.SelectedIndex = -1;
            }

        }
        private void OpenSaturday()
        {

            if (chkOpenSat.Enabled == false)
            {
                return;
            }

            cmbSaturday.Enabled = !chkOpenSat.Checked;

            if (chkOpenSat.Checked)
            {
                cmbSaturday.SelectedIndex = -1;
            }

        }
        private void OpenSunday()
        {

            if (chkOpenSun.Enabled == false)
            {
                return;
            }

            cmbSunday.Enabled = !chkOpenSun.Checked;


            if (chkOpenSun.Checked)
            {
                cmbSunday.SelectedIndex = -1;
            }

        }
        private void chkOpenMon_CheckedChanged(object sender, EventArgs e)
        {
            OpenMonday();
        }
        private void cmbMonday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonday.SelectedIndex == -1)
            {
                lblMonday_IN_AM.Text = "";
                lblMonday_OUT_LUNCH.Text = "";
                lblMonday_IN_LUNCH.Text = "";
                lblMonday_OUT_BREAK.Text = "";
                lblMonday_IN_BREAK.Text = "";
                lblMonday_OUT_PM.Text = "";

                lblMonday_LUNCH.Text = "";
                lblMonday_BREAK.Text = "";

                chkFixedMon.Checked = false;

            }
            else
            {
                MondayShift();
                if (cmbMonday.SelectedIndex > -1)
                {
                    chkOpenMon.Checked = false;
                }

            }
        }
        private void chkOpenTue_CheckedChanged(object sender, EventArgs e)
        {
            OpenTuesday();
        }
        private void cmbTuesday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTuesday.SelectedIndex == -1)
            {
                lblTuesday_IN_AM.Text = "";
                lblTuesday_OUT_LUNCH.Text = "";
                lblTuesday_IN_LUNCH.Text = "";
                lblTuesday_OUT_BREAK.Text = "";
                lblTuesday_IN_BREAK.Text = "";
                lblTuesday_OUT_PM.Text = "";

                lblTuesday_LUNCH.Text = "";
                lblTuesday_BREAK.Text = "";

                chkFixedTue.Checked = false;

            }
            else
            {
                TuesdayShift();

                if (cmbTuesday.SelectedIndex > -1)
                {
                    chkOpenTue.Checked = false;
                }
            }
        }
        private void chkOpenWed_CheckedChanged(object sender, EventArgs e)
        {
            OpenWednesday();
        }
        private void cmbWednesday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWednesday.SelectedIndex == -1)
            {
                lblWednesday_IN_AM.Text = "";
                lblWednesday_OUT_LUNCH.Text = "";
                lblWednesday_IN_LUNCH.Text = "";
                lblWednesday_OUT_BREAK.Text = "";
                lblWednesday_IN_BREAK.Text = "";
                lblWednesday_OUT_PM.Text = "";

                lblWednesday_LUNCH.Text = "";
                lblWednesday_BREAK.Text = "";

                chkFixedWed.Checked = false;

            }
            else
            {
                WednesdayShift();
                if (cmbWednesday.SelectedIndex > -1)
                {
                    chkOpenWed.Checked = false;
                }
            }
        }
        private void chkOpenThu_CheckedChanged(object sender, EventArgs e)
        {
            OpenThursday();
        }
        private void cmbThursday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThursday.SelectedIndex == -1)
            {
                lblThursday_IN_AM.Text = "";
                lblThursday_OUT_LUNCH.Text = "";
                lblThursday_IN_LUNCH.Text = "";
                lblThursday_OUT_BREAK.Text = "";
                lblThursday_IN_BREAK.Text = "";
                lblThursday_OUT_PM.Text = "";

                lblThursday_LUNCH.Text = "";
                lblThursday_BREAK.Text = "";

                chkFixedThu.Checked = false;

            }
            else
            {
                ThusdayShift();
                if (cmbThursday.SelectedIndex > -1)
                {
                    chkOpenThu.Checked = false;
                }
            }
        }
        private void chkOpenFri_CheckedChanged(object sender, EventArgs e)
        {
            OpenFriday();
        }
        private void cmbFriday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFriday.SelectedIndex == -1)
            {
                lblFriday_IN_AM.Text = "";
                lblFriday_OUT_LUNCH.Text = "";
                lblFriday_IN_LUNCH.Text = "";
                lblFriday_OUT_BREAK.Text = "";
                lblFriday_IN_BREAK.Text = "";
                lblFriday_OUT_PM.Text = "";

                lblFriday_LUNCH.Text = "";
                lblFriday_BREAK.Text = "";

                chkFixedFri.Checked = false;

            }
            else
            {
                FridayShift();
                if (cmbFriday.SelectedIndex > -1)
                {
                    chkOpenFri.Checked = false;
                }
            }
        }
        private void chkOpenSat_CheckedChanged(object sender, EventArgs e)
        {
            OpenSaturday();
        }
        private void cmbSaturday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSaturday.SelectedIndex == -1)
            {
                lblSaturday_IN_AM.Text = "";
                lblSaturday_OUT_LUNCH.Text = "";
                lblSaturday_IN_LUNCH.Text = "";
                lblSaturday_OUT_BREAK.Text = "";
                lblSaturday_IN_BREAK.Text = "";
                lblSaturday_OUT_PM.Text = "";

                lblSaturday_LUNCH.Text = "";
                lblSaturday_BREAK.Text = "";

                chkFixedSat.Checked = false;

            }
            else
            {
                SaturdayShift();
                if (cmbSaturday.SelectedIndex > -1)
                {
                    chkOpenSat.Checked = false;
                }
            }
        }
        private void chkOpenSun_CheckedChanged(object sender, EventArgs e)
        {
            OpenSunday();
        }
        private void cmbSunday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSunday.SelectedIndex == -1)
            {
                lblSunday_IN_AM.Text = "";
                lblSunday_OUT_LUNCH.Text = "";
                lblSunday_IN_LUNCH.Text = "";
                lblSunday_OUT_BREAK.Text = "";
                lblSunday_IN_BREAK.Text = "";
                lblSunday_OUT_PM.Text = "";

                lblSunday_LUNCH.Text = "";
                lblSunday_BREAK.Text = "";

                chkFixedSun.Checked = false;

            }
            else
            {
                SundayShift();
                if (cmbSunday.SelectedIndex > -1)
                {
                    chkOpenSun.Checked = false;
                }
            }
        }
        private void MondayShift()
        {
            int selectedId;
            if (int.TryParse(cmbMonday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblMonday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblMonday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblMonday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblMonday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblMonday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblMonday_LUNCH.Text = data["Lunch"].ToString();
                    lblMonday_BREAK.Text = data["BreakTime"].ToString();
                    lblMonday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedMon.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }

        }
        private void TuesdayShift()
        {
            int selectedId;
            if (int.TryParse(cmbTuesday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblTuesday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblTuesday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblTuesday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblTuesday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblTuesday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblTuesday_LUNCH.Text = data["Lunch"].ToString();
                    lblTuesday_BREAK.Text = data["BreakTime"].ToString();
                    lblTuesday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedTue.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }
        }
        private void WednesdayShift()
        {
            int selectedId;
            if (int.TryParse(cmbWednesday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblWednesday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblWednesday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblWednesday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblWednesday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblWednesday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblWednesday_LUNCH.Text = data["Lunch"].ToString();
                    lblWednesday_BREAK.Text = data["BreakTime"].ToString();
                    lblWednesday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedWed.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }
        }
        private void ThusdayShift()
        {
            int selectedId;
            if (int.TryParse(cmbThursday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblThursday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblThursday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblThursday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblThursday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblThursday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblThursday_LUNCH.Text = data["Lunch"].ToString();
                    lblThursday_BREAK.Text = data["BreakTime"].ToString();
                    lblThursday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedThu.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }
        }
        private void FridayShift()
        {
            int selectedId;
            if (int.TryParse(cmbFriday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblFriday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblFriday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblFriday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblFriday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblFriday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblFriday_LUNCH.Text = data["Lunch"].ToString();
                    lblFriday_BREAK.Text = data["BreakTime"].ToString();
                    lblFriday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedFri.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }
        }
        private void SaturdayShift()
        {
            int selectedId;
            if (int.TryParse(cmbSaturday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblSaturday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblSaturday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblSaturday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblSaturday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblSaturday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblSaturday_LUNCH.Text = data["Lunch"].ToString();
                    lblSaturday_BREAK.Text = data["BreakTime"].ToString();
                    lblSaturday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedSat.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }
        }
        private void SundayShift()
        {
            int selectedId;
            if (int.TryParse(cmbSunday.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblSunday_IN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblSunday_OUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblSunday_IN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblSunday_OUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblSunday_IN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblSunday_LUNCH.Text = data["Lunch"].ToString();
                    lblSunday_BREAK.Text = data["BreakTime"].ToString();
                    lblSunday_OUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixedSun.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }
        }
        private void chkRestday1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday1.Checked)
            {
                chkOpenMon.Checked = false;
                //RestDayResetter(1);
            }
        }
        private void chkRestday2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday2.Checked)
            {
                chkOpenTue.Checked = false;
                //RestDayResetter(2);
            }
        }
        private void chkRestday3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday3.Checked)
            {
                chkOpenWed.Checked = false;
                //RestDayResetter(3);
            }
        }
        private void chkRestday4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday4.Checked)
            {
                chkOpenThu.Checked = false;
                //RestDayResetter(4);
            }
        }
        private void chkRestday5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday5.Checked)
            {
                chkOpenFri.Checked = false;
                //RestDayResetter(5);
            }
        }
        private void chkRestday6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday6.Checked)
            {
                chkOpenSat.Checked = false;
                //RestDayResetter(6);
            }
        }
        private void chkRestday7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday7.Checked)
            {
                chkOpenSun.Checked = false;
                //RestDayResetter(7);
            }
        }

        private void tsFind_Click(object sender, EventArgs e)
        {
            frmFind.ShowDialog();

            if (frmFind.isYes == true)
            {
                frmFind.isYes = false;
                clsComponentControl.ClearValue(this);
                lblPK.Text = frmFind.PK;
                RefreshData();
            }
        }
        private void DataRecord(string squery)
        {
            var data = clsBiometrics.GetFirstRecord(squery);
            if (data != null)
            {
                clsComponentControl.AssignValue(this, data);

                string[] RS = data["DayOff"].ToString().Split(',');

                foreach (var r in RS)
                {
                    switch (r)
                    {
                        case "1": chkRestday1.Checked = true; break;
                        case "2": chkRestday2.Checked = true; break;
                        case "3": chkRestday3.Checked = true; break;
                        case "4": chkRestday4.Checked = true; break;
                        case "5": chkRestday5.Checked = true; break;
                        case "6": chkRestday6.Checked = true; break;
                        case "7": chkRestday7.Checked = true; break;
                        default: break;
                    }
                }


            }


        }

        private void chkFixedMon_Click(object sender, EventArgs e)
        {
            chkFixedMon.Checked = !chkFixedMon.Checked;
        }

        private void chkFixedTue_Click(object sender, EventArgs e)
        {
            chkFixedTue.Checked = !chkFixedTue.Checked;
        }

        private void chkFixedWed_Click(object sender, EventArgs e)
        {
            chkFixedWed.Checked = !chkFixedWed.Checked;
        }

        private void chkFixedThu_Click(object sender, EventArgs e)
        {
            chkFixedThu.Checked = !chkFixedThu.Checked;
        }

        private void chkFixedFri_Click(object sender, EventArgs e)
        {
            chkFixedFri.Checked = !chkFixedFri.Checked;
        }

        private void chkFixedSat_Click(object sender, EventArgs e)
        {
            chkFixedSat.Checked = !chkFixedSat.Checked;
        }

        private void chkFixedSun_Click(object sender, EventArgs e)
        {
            chkFixedSun.Checked = !chkFixedSun.Checked;
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {

                if (!clsAccessControl.AccessRight(this.AccessibleDescription, "DELETE"))
                {
                    return;
                }

                if (clsMessage.MessageQuestionWarning("ARE YOU SURE IN DELETING THIS RECORD? "))
                {
                    clsBiometrics.ExecuteNonQuery($@"Delete From EmployeeShifting WHERE EmployeeShifting.PK = {lblPK.Text}");
                    clsComponentControl.ClearValue(this);
                }


            }
        }

        private void checkOpen()
        {

            chkOpenMon.Checked = (cmbMonday.Text.ToString().Trim().Length > 0 ? false : true);
            chkOpenTue.Checked = (cmbTuesday.Text.Trim().Length > 0 ? false : true);
            chkOpenWed.Checked = (cmbWednesday.Text.Trim().Length > 0 ? false : true);
            chkOpenThu.Checked = (cmbThursday.Text.Trim().Length > 0 ? false : true);
            chkOpenFri.Checked = (cmbFriday.Text.Trim().Length > 0 ? false : true);
            chkOpenSat.Checked = (cmbSaturday.Text.Trim().Length > 0 ? false : true);
            chkOpenSun.Checked = (cmbSunday.Text.Trim().Length > 0 ? false : true);
        }
        private void RestDayResetter(string[] ID)
        {   
            if(ID == null)
            {

                return;
            }

            if (numMachineID.Enabled == false && ID.Length == 0)
            {
                return;
            }


            CheckBox[] chkRest = { chkRestday1, chkRestday2, chkRestday3, chkRestday4, chkRestday5, chkRestday6, chkRestday7 };
            int r = 0;
            foreach (var chk in chkRest)
            {
                r++;

                if (r == int.Parse(ID[r]))
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
        }

        private void cmbMonday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbMonday.SelectedValue = frm.PK;

                }
            }
        }

        private void cmbTuesday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbTuesday.SelectedValue = frm.PK;

                }
            }
        }

        private void cmbWednesday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbWednesday.SelectedValue = frm.PK;

                }
            }
        }

        private void cmbThursday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbThursday.SelectedValue = frm.PK;

                }
            }
        }

        private void cmbFriday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbFriday.SelectedValue = frm.PK;

                }
            }
        }

        private void cmbSaturday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbSaturday.SelectedValue = frm.PK;

                }
            }
        }

        private void cmbSunday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmFind frm = new FrmFind($@"SELECT PK,ShiftName From ShiftingSchedule");
                frm.ShowDialog();

                if (frm.isYes == true)
                {
                    cmbSunday.SelectedValue = frm.PK;

                }
            }
        }

        private void lblEmployeeName_Click(object sender, EventArgs e)
        {
            clsMenu.OpenProifile(lblEMP_PK.Text);
        }

        private void FrmAssignSchedule_KeyDown(object sender, KeyEventArgs e)
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

                    break;

                case Keys.PageDown:

                    break;
                case Keys.Home:

                    break;
                case Keys.End:

                    break;
                case Keys.F9:

                    break;
                case Keys.F8:

                    break;
                default:
                    // Nothing
                    break;

            }
        }
        private void CorrectValueText(ComboBox cmb)
        {
            if (cmb.Enabled)
            {
                int index = cmb.FindStringExact(cmb.Text);
                if (index != -1)
                {
                    cmb.SelectedIndex = index;
                    cmb.SelectionStart = cmb.Text.Length;
                    cmb.SelectionLength = 0;
                }
            }
        }
        private void cmbMonday_TextChanged(object sender, EventArgs e)
        {

            CorrectValueText(cmbMonday);
        }

        private void cmbTuesday_TextChanged(object sender, EventArgs e)
        {
            CorrectValueText(cmbTuesday);
        }

        private void cmbWednesday_TextChanged(object sender, EventArgs e)
        {
            CorrectValueText(cmbWednesday);
        }

        private void cmbThursday_TextChanged(object sender, EventArgs e)
        {
            CorrectValueText(cmbThursday);
        }

        private void cmbFriday_TextChanged(object sender, EventArgs e)
        {
            CorrectValueText(cmbFriday);
        }

        private void cmbSaturday_TextChanged(object sender, EventArgs e)
        {
            CorrectValueText(cmbSaturday);
        }

        private void cmbSunday_TextChanged(object sender, EventArgs e)
        {
            CorrectValueText(cmbSunday);
        }

        private void cmbMonday_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
