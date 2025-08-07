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
    public partial class FrmChangeDayoff : Form
    {

        bool isExchangeEntry = false;

        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 CD_nID as ID ,nCtrlNo,dTransDate,sEmpName,sReason FROM [tbl_CHANGERESTDAY]  ");
        const string sSelectSql = "SELECT TOP 1 [CD_nID], [nCtrlNo], [dTransDate], tbl_CHANGERESTDAY.[EmpPK], [sEmpName], [sReqDayFrom], [sReqDayTo], [dReqDateFrom], [dReqDateTo], [sExDayFrom], [sExDayTo], [dExDateFrom], [dExDateTo], [RestDayFrom], [RestDay], [sReason], [sCoordinated], [sRecmAppBy], [sNotedBy], [sApprovBy], [sLastUpdatedBy], [nPosted], [sExWith], [EmpPKWith], [nCancelled], [sReasonCanc], [RefCD_nID],[R_EMP].EmpID as [EMPLOYEE_NO],[E_EMP].EmpID as [EX_EMPLOYEE_NO] FROM [tbl_CHANGERESTDAY] LEFT JOIN  EmployeeName as [R_EMP] ON tbl_CHANGERESTDAY.EmpPK = R_EMP.EmpPK LEFT JOIN  EmployeeName as [E_EMP] ON tbl_CHANGERESTDAY.EmpPKWith = [E_EMP].EmpPK ";

        public FrmChangeDayoff()
        {
            InitializeComponent();
        }
        private void LoadWeekDays()
        {
            DataTable dt = clsTool.WeekDayList();


        }
        private void FrmExchangeDayOff_Load(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (this.Tag != null)
            {
                //view
                lblCD_nID.Text = this.Tag.ToString();
                RefreshData();

            }

            if (this.AccessibleName != null)
            {
                // create
                if (SetNewData(this.AccessibleName.ToString()))
                {
                    isExchangeEntry = false;
                    dtpdExDateFrom.Enabled = false;
                    dtpdExDateTo.Enabled = false;
                    getLatestRestDayRequest();
                }

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


                lblEMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                lblsEmpName.Text = empData["Name"].ToString();
                lblEmpPK.Text = empData["PK"].ToString();

                tsPosted.Visible = false;
                tsPost.Text = "Post";

                tsPosted.Text = "POSTED";
                xlblCancel.Visible = false;

                return true;
            }

            return false;
        }
        private void tsAdd_Click(object sender, EventArgs e)
        {
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "ADD"))
            {
                return;
            }


            isExchangeEntry = clsMessage.MessageQuestion("Is This An Exchange Restday?", "Question");

            if (isExchangeEntry)
            {
                if (RequestEmp())
                {
                    if (ExchangeEmp())
                    {
                        swapDate();


                        xlblCancel.Visible = false;
                        return;
                    }
                }

            }
            else
            {
                if (RequestEmp())
                {
                    dtpdExDateFrom.Enabled = false;
                    dtpdExDateTo.Enabled = false;

                    getLatestRestDayRequest();


                    return;
                }
            }


            clsMessage.MessageShowInfo("New entry canceled");
            tsCancel.PerformClick();

        }
        private bool RequestEmp()
        {
            FrmEmployeeList frm = new FrmEmployeeList("Requested");
            frm.ShowDialog();

            if (frm.VALUE != "")
            {
                return SetNewData(frm.VALUE);
            }

            return false;
        }

        private bool ExchangeEmp()
        {
            FrmEmployeeList frm = new FrmEmployeeList("Exchange to");
            frm.ShowDialog();

            if (frm.VALUE != "")
            {
                string strSelect = $@"SELECT PK, 
                                    EEmployeeIDNo,
                                    ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS Name,
                                    ELastName, 
                                    ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS EActive, 
                                    ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS Hired
                                    FROM tbl_Profile_IDNumber 
                                    WHERE PK = {frm.VALUE} ";

                var empData = clsPayrollSystem.GetFirstRecord(strSelect);
                if (empData != null)
                {
                    lblEX_EMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                    lblsExWith.Text = empData["Name"].ToString();
                    lblEmpPKWith.Text = empData["PK"].ToString();
                    return true;
                }
            }
            return false;
        }
        private void getLatestRestDayRequest()
        {
            if (lblEmpPK.Text.Length == 0)
            {
                return;
            }

            DateTime now = DateTime.Now;
            int emptID = int.Parse(lblEmpPK.Text);
            int rdId = getRestDayId(emptID);

            if (rdId == 0)
            {
                return;
            }

            int dayOfWeek = rdId;


            int daysFromMonday = ((int)now.DayOfWeek + 6) % 7;
            DateTime daySet = now.AddDays(-daysFromMonday);
            // Get the target day
            DateTime targetDate = daySet.AddDays(dayOfWeek - 1);
            dtpdReqDateFrom.Value = targetDate;

        }
        private int getRestDayId(int empId)
        {
            var data = clsBiometrics.GetFirstRecord($"SELECT TOP 1  EmployeeShifting.RestDay FROM EmployeeShifting where EmpNo={empId}");

            if (data != null)
            {
                return int.Parse(data["RestDay"].ToString());
            }

            return 0;
        }
        private void getLastestRestDayExchange()
        {
            if (lblEmpPKWith.Text.Length == 0)
            {
                return;
            }

            DateTime now = DateTime.Now;
            int emptID = int.Parse(lblEmpPKWith.Text);
            int rdId = getRestDayId(emptID);

            if (rdId == 0)
            {
                return;
            }


            int dayOfWeek = rdId;


            int daysFromMonday = ((int)now.DayOfWeek + 6) % 7;
            DateTime daySet = now.AddDays(-daysFromMonday);
            // Get the target day
            DateTime targetDate = daySet.AddDays(dayOfWeek - 1);
            dtpdExDateFrom.Value = targetDate;
        }
        private void swapDate()
        {
            getLatestRestDayRequest();
            getLastestRestDayExchange();

            dtpdReqDateTo.Value = dtpdExDateFrom.Value;
            dtpdExDateTo.Value = dtpdReqDateFrom.Value;
        }
        private void tsEdit_Click(object sender, EventArgs e)
        {
            if (lblCD_nID.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "EDIT"))
            {
                return;
            }

            isExchangeEntry = (lblEmpPKWith.Text.Length == 0 ? false : true);
            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);

            if (!isExchangeEntry)
            {
                dtpdExDateFrom.Enabled = false;
                dtpdExDateTo.Enabled = false;
                dtpdExDateFrom.Checked = false;
                dtpdExDateTo.Checked = false;
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (lblCD_nID.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "DELETE"))
            {
                return;
            }

            if (clsMessage.MessageQuestionWarning("ARE YOU SURE IN DELETING THIS RECORD? "))
            {
                clsBiometrics.ExecuteNonQuery($@"Delete From tbl_CHANGERESTDAY WHERE CD_nID = {lblCD_nID.Text}");
                clsComponentControl.ClearValue(this);
            }
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblCD_nID.Text.Length > 0)
            {
                RefreshData();
            }
            else
            {
                clsComponentControl.ClearValue(this);
            }
        }
        private void RefreshData()
        {
            string squery = $@"{sSelectSql} WHERE CD_nID = {lblCD_nID.Text}";
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


                int cancelValue = int.Parse(data["nCancelled"].ToString());

                if (cancelValue == 1)
                {
                    tsPosted.Text = "CANCELLED";
                    tsVoid.Enabled = false;
                    xlblCancel.Visible = true;
                    tsPost.Enabled = false;
                }
                else
                {
                    tsVoid.Enabled = postValue == 1 ? true : false;
                    tsPosted.Text = "POSTED";
                    xlblCancel.Visible = false;
                    tsPost.Enabled = true;
                }
            }
        }

        private void dtpdReqDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpdReqDateFrom.Enabled)
            {
                return;
            }

            lblsReqDayFrom.Text = clsTool.getWeekName(clsTool.getDayWeekValue(dtpdReqDateFrom));
        }

        private void dtpdReqDateTo_ValueChanged(object sender, EventArgs e)
        {

            if (!dtpdReqDateTo.Enabled)
            {
                return;
            }

            lblsReqDayTo.Text = clsTool.getWeekName(clsTool.getDayWeekValue(dtpdReqDateTo));
        }

        private void dtpdExDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpdExDateFrom.Enabled)
            {
                return;
            }

            lblsExDayFrom.Text = clsTool.getWeekName(clsTool.getDayWeekValue(dtpdExDateFrom));
        }

        private void dtpdExDateTo_ValueChanged(object sender, EventArgs e)
        {

            if (!dtpdExDateTo.Enabled)
            {
                return;
            }
            lblsExDayTo.Text = clsTool.getWeekName(clsTool.getDayWeekValue(dtpdExDateTo));
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
                lblCD_nID.Text = frmFind.PK;
                RefreshData();


            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (lblEmpPK.Text.Length == 0) { clsMessage.MessageShowWarning("Please Select Employee Request !"); return; };
            if (dtpdReqDateFrom.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date From Request!"); return; }
            if (dtpdReqDateTo.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date To Request!"); return; }

            if (isExchangeEntry)
            {
                if (lblEmpPKWith.Text.Length == 0) { clsMessage.MessageShowWarning("Please Select Employee Exchange!"); return; };
                if (dtpdExDateFrom.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date From Exchange!"); return; }
                if (dtpdExDateTo.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date To Exchange!"); return; }
            }

            if (txtsReason.Text.Length == 0) { clsMessage.MessageShowWarning("Please Enter an Reason!"); return; }

            if (lblCD_nID.Text.Length == 0)
            {
                var data = clsBiometrics.GetFirstRecord($"select top 1 nCtrlNo from tbl_CHANGERESTDAY order by nCtrlNo desc");
                if (data != null)
                {
                    object ID = clsBiometrics.ExecuteScalarQuery($@"INSERT INTO tbl_CHANGERESTDAY 
                                    ([nCtrlNo], [dTransDate], [EmpPK], [sEmpName], [sReqDayFrom], [sReqDayTo], [dReqDateFrom], [dReqDateTo], [sExDayFrom], [sExDayTo], [dExDateFrom], [dExDateTo], [RestDayFrom], [RestDay], [sReason], [sCoordinated], [sRecmAppBy], [sNotedBy], [sApprovBy], [sLastUpdatedBy], [nPosted], [sExWith], [EmpPKWith]) 
                                    VALUES ({ int.Parse(data["nCtrlNo"].ToString()) + 1},'{dtpdTransDate.Value}',
                                    {lblEmpPK.Text},'{lblsEmpName.Text}','{lblsReqDayFrom.Text}','{lblsReqDayTo.Text}',
                                    {clsMisc.SQL_Date(dtpdReqDateFrom)},{clsMisc.SQL_Date(dtpdReqDateTo)},'{lblsExDayFrom.Text}',
                                    '{lblsExDayTo.Text}',{clsMisc.SQL_Date(dtpdExDateFrom)},{clsMisc.SQL_Date(dtpdExDateTo)},
                                    {clsTool.getDayWeekValue(dtpdReqDateFrom)},{clsTool.getDayWeekValue(dtpdReqDateTo)},
                                    '{ clsMisc.SQL_Text(txtsReason)}','{clsMisc.SQL_Text(txtsCoordinated)}','{clsMisc.SQL_Text(txtsRecmAppBy)}',
                                    '{clsMisc.SQL_Text(txtsNotedBy)}','{clsMisc.SQL_Text(txtsApprovBy)}','{clsDateTime.LastModify()}',0,'{lblsExWith.Text}',
                                    {(lblEmpPKWith.Text.Length == 0 ? "0" : lblEmpPKWith.Text)}) ");


                    if (ID == null)
                    {
                        return;
                    }

                    lblCD_nID.Text = ID.ToString();
                    tsCancel.PerformClick();

                }


            }
            else
            {



                bool saveSuccess = clsBiometrics.ExecuteNonQueryBool($@"UPDATE tbl_CHANGERESTDAY SET 
                                    [sReqDayFrom]='{lblsReqDayFrom.Text}', [sReqDayTo]='{lblsReqDayTo.Text}', [dReqDateFrom]={clsMisc.SQL_Date(dtpdReqDateFrom)}, 
                                    [dReqDateTo]={clsMisc.SQL_Date(dtpdReqDateTo)}, [sExDayFrom]='{lblsExDayFrom.Text}', [sExDayTo]='{lblsExDayTo.Text}', 
                                    [dExDateFrom]={clsMisc.SQL_Date(dtpdExDateFrom)}, [dExDateTo]={clsMisc.SQL_Date(dtpdExDateTo)}, [RestDayFrom]={clsTool.getDayWeekValue(dtpdReqDateFrom)}, [RestDay]={clsTool.getDayWeekValue(dtpdReqDateTo)},
                                    [sReason]='{clsMisc.SQL_Text(txtsReason)}', [sCoordinated]='{clsMisc.SQL_Text(txtsCoordinated)}', [sRecmAppBy]='{clsMisc.SQL_Text(txtsRecmAppBy)}', 
                                    [sNotedBy]='{clsMisc.SQL_Text(txtsNotedBy)}', [sApprovBy]='{clsMisc.SQL_Text(txtsApprovBy)}', [sLastUpdatedBy]='{clsDateTime.LastModify()}' 
                                    WHERE CD_nID = {lblCD_nID.Text}");

                if (!saveSuccess)
                {
                    return;
                }

                tsCancel.PerformClick();

            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsPost_Click(object sender, EventArgs e)
        {
            if (lblCD_nID.Text.Length == 0)
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

            clsBiometrics.ExecuteNonQueryBool($"UPDATE tbl_CHANGERESTDAY SET nPosted = {(tsPosted.Visible ? 0 : 1)} WHERE (CD_nID = {lblCD_nID.Text} ) ");
            RefreshData();
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {

        }

        private void tsVoid_Click(object sender, EventArgs e)
        {
            if (lblCD_nID.Text.Trim().Length == 0)
            {
                return;
            }

            FrmInputBox frm = new FrmInputBox("DISCARD LEAVE/UNDERTIME", "REASON");
            frm.ShowDialog();
            if (frm.isYes)
            {
                clsBiometrics.ExecuteNonQueryBool($"UPDATE tbl_CHANGERESTDAY SET nCancelled=1,sReasonCanc='{frm.InpuText}'  WHERE (CD_nID = {lblCD_nID.Text} ) ");
                RefreshData();
            }

            frm.Dispose();
        }

        private void FrmChangeDayoff_KeyDown(object sender, KeyEventArgs e)
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

        private void lblsEmpName_Click(object sender, EventArgs e)
        {
            clsMenu.OpenProifile(lblEmpPK.Text);
        }

        private void lblsExWith_Click(object sender, EventArgs e)
        {
            clsMenu.OpenProifile(lblEmpPKWith.Text);
        }
    }
}
