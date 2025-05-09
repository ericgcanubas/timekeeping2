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


    public partial class FrmLeaveUndertime : Form
    {


        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 LU_nID as ID,sEmpName ,nCtrlNo,dTransDate,sReason FROM [tbl_LEAVE_UNDERTIME]  ");
        const string sSelectSql = "SELECT TOP 1  [LU_nID], [nCtrlNo], [dTransDate], [nType], [EmpPK], [sEmpName], [sSection], [sBrand], [dEffectDate], [EffectDates], [sResumeToWork], [sReason], [sCoordinated], [sCheckBy], [sFiledBy], [sNotedBy], [sVerifiedBy], [sApprovedBy], [sLastUpdatedBy], [nPosted], [sNoOfDaysMin], [nCancelled], [sReasonCanc] FROM [tbl_LEAVE_UNDERTIME] ";

        string[] effectDates = null;
        public FrmLeaveUndertime()
        {
            InitializeComponent();
        }

        private void FrmLeaveUndertime_Load(object sender, EventArgs e)
        {



            dtpDATE_FROM.CustomFormat = "h:mm tt";
            dtpDATE_TO.CustomFormat = "h:mm tt";
            dtpsResumeToWork.CustomFormat = "h:mm tt";

            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

        }

        private void loadType(int inType, string EffectDates)
        {
            if (inType == 1)
            {
                rdbLeave.Checked = true;

                effectDates = EffectDates.Split(',');
            }
            else
            {

                rdbUndertime.Checked = true;
                effectDates = EffectDates.Split('-');
            }
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "ADD"))
            {
                return;
            }

            RequestEmp();

        }
        private void RefreshData()
        {
            string squery = $@"{sSelectSql} WHERE LU_nID = {lblLU_nID.Text}";
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


                setDate(type, data["EffectDates"].ToString());


                int cancelValue = int.Parse(data["nCancelled"].ToString());

                if (cancelValue == 1)
                {
                    tsPosted.Text = "CANCELLED";
                    tsVoid.Enabled = false;
                    xlblCancel.Visible = true;
                }
                else
                {
                    tsVoid.Enabled = postValue == 1 ? true : false;
                    tsPosted.Text = "POSTED";
                    xlblCancel.Visible = false;
                }
            }
        }
        private void setType(int type)
        {
            if (type == 1)
            {
                dtpDATE_FROM.Format = DateTimePickerFormat.Short;
                dtpDATE_TO.Format = DateTimePickerFormat.Short;
                dtpsResumeToWork.Format = DateTimePickerFormat.Short;

                dtpDATE_TO.ShowUpDown = false;
                dtpDATE_TO.ShowUpDown = false;
                dtpsResumeToWork.ShowUpDown = false;

                xlblFROM.Text = "DATE FROM :";
                xlblTO.Text = "DATE TO :";
                xlblResume.Text = "DATE RESUME :";
            }
            else
            {
                dtpDATE_FROM.Format = DateTimePickerFormat.Custom;
                dtpDATE_TO.Format = DateTimePickerFormat.Custom;
                dtpsResumeToWork.Format = DateTimePickerFormat.Custom;
                dtpDATE_TO.ShowUpDown = true;
                dtpDATE_TO.ShowUpDown = true;
                dtpsResumeToWork.ShowUpDown = true;

                xlblFROM.Text = "TIME FROM :";
                xlblTO.Text = "TIME TO :";
                xlblResume.Text = "TIME RESUME :";

            }
        }
        private void setDate(int type, string EffectDates)
        {

            if (type == 1)
            {
                rdbLeave.Checked = true;
                effectDates = EffectDates.Split(',');
            }
            else
            {

                rdbUndertime.Checked = true;
                effectDates = EffectDates.Split('-');
            }
            setType(type);
            try
            {
                string dt_from = effectDates.Length > 0 ? effectDates[0] : string.Empty;
                if (dt_from.Length == 0)
                {
                    dtpDATE_FROM.Checked = false;
                }
                else
                {
                    dtpDATE_FROM.Checked = true;
                    dtpDATE_FROM.Value = DateTime.Parse(dt_from);
                }

                string dt_to = effectDates.Length > 0 ? effectDates[effectDates.Length - 1] : string.Empty;
                if (dt_to == "")
                {
                    dtpDATE_TO.Checked = false;
                }
                else
                {
                    dtpDATE_TO.Checked = true;
                    dtpDATE_TO.Value = DateTime.Parse(dt_to);
                }
            }
            catch (Exception)
            {

                if (type == 1)
                {

                    setDate(2, EffectDates);
                }
                else
                {
                    setDate(1, EffectDates);
                }
            }
        }
        private bool RequestEmp()
        {
            FrmEmployeeList frm = new FrmEmployeeList();
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

                    clsComponentControl.ClearValue(this);
                    clsComponentControl.HeaderMenu(tsHeaderControl, false);
                    clsComponentControl.ObjectEnable(this, true);

                    lblsEmpName.Text = $"{empData["EEmployeeIDNo"].ToString()} - {empData["Name"].ToString()}";
                    lblEmpPK.Text = empData["PK"].ToString();

                    tsPosted.Visible = false;
                    tsPost.Text = "Post";

                    rdbLeave.Checked = false;
                    rdbUndertime.Checked = false;
                    rdbLeave.Checked = true;
                    xlblCancel.Visible = false;

                    return true;
                }
            }

            return false;
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblLU_nID.Text.Length > 0)
            {
                RefreshData();
            }
            else
            {
                clsComponentControl.ClearValue(this);
                tsPosted.Visible = false;
                tsPost.Text = "Post";

                rdbLeave.Checked = false;
                rdbUndertime.Checked = false;
                rdbLeave.Checked = true;
                xlblCancel.Visible = false;
            }
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            if (lblLU_nID.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "EDIT"))
            {
                return;
            }


            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);


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

        private void rdbLeave_CheckedChanged(object sender, EventArgs e)
        {
            setType(1);

            if (rdbLeave.Enabled)
            {

                dtpDATE_FROM.Value = clsDateTime.GetDefault();
                dtpDATE_TO.Value = clsDateTime.GetDefault();

                getDayMinCount();
            }
        }

        private void rdbUndertime_CheckedChanged(object sender, EventArgs e)
        {

            setType(2);

            if (rdbUndertime.Enabled)
            {
                dtpDATE_FROM.Value = clsDateTime.GetDefault();
                dtpDATE_TO.Value = clsDateTime.GetDefault();
                getDayMinCount();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsFind_Click(object sender, EventArgs e)
        {


            frmFind.ShowDialog();
            if (frmFind.isYes == true)
            {
                frmFind.isYes = false;
                clsComponentControl.ClearValue(this);
                lblLU_nID.Text = frmFind.PK;
                RefreshData();
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (lblLU_nID.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "DELETE"))
            {
                return;
            }

            if (clsMessage.MessageQuestionWarning("ARE YOU SURE IN DELETING THIS RECORD? "))
            {
                clsBiometrics.ExecuteNonQuery($@"Delete From tbl_LEAVE_UNDERTIME WHERE LU_nID = {lblLU_nID.Text}");
                clsComponentControl.ClearValue(this);
            }
        }
        private void getDayMinCount()
        {

            if (rdbLeave.Checked)
            {
                int dayCount = clsDateTime.GetDiffCountDays(dtpDATE_FROM.Value, dtpDATE_TO.Value);
                if (dayCount >= 0)
                {
                    if (dayCount > 1)
                    {
                        lblsNoOfDaysMin.Text = $"{dayCount + 1} Days ";
                        ResumeOn();
                        return;
                    }
                    lblsNoOfDaysMin.Text = $"{dayCount + 1} Day ";
                    ResumeOn();
                    return;
                }
                lblsNoOfDaysMin.Text = "";
            }

            if (rdbUndertime.Checked)
            {
                lblsNoOfDaysMin.Text = clsDateTime.TimeDisplay(dtpDATE_FROM.Value, dtpDATE_TO.Value);
                ResumeOn();
            }



        }
        private void dtpDATE_FROM_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDATE_FROM.Enabled == false)
            {
                return;
            }

            getDayMinCount();
        }

        private void dtpDATE_TO_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDATE_TO.Enabled == false)
            {
                return;
            }

            getDayMinCount();
        }
        private void ResumeOn()
        {
            if (rdbLeave.Checked == true)
            {
                DateTime dt = dtpDATE_TO.Value;
                dtpsResumeToWork.Value = dt.AddDays(1);
            }

            if (rdbUndertime.Checked == true)
            {
                dtpsResumeToWork.Value = dtpDATE_TO.Value;
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (lblEmpPK.Text.Length == 0) { clsMessage.MessageShowWarning("Please Select Employee Request !"); return; };
            if (txtsReason.Text.Length == 0) { clsMessage.MessageShowWarning("Please Enter an Reason!"); return; }
            string sSection = "";
            string sBrand = "";
            int nType = 0;
            string sFormat = "";
            string sEffectDates = "";
            if (rdbLeave.Checked)
            {
                if (dtpDATE_FROM.Value > dtpDATE_TO.Value)
                {
                    clsMessage.MessageShowError("Invalid Date Range From/To ");
                    return;
                }

                nType = 1;
                sFormat = "MM/dd/yyyy";
                sEffectDates = clsDateTime.DateRangeOutput(dtpDATE_FROM.Value.Date, dtpDATE_TO.Value.Date);
            }
            if (rdbUndertime.Checked)
            {
                if (dtpDATE_FROM.Value > dtpDATE_TO.Value)
                {

                    clsMessage.MessageShowError("Invalid Time Range From/To ");
                    return;
                }

                nType = 2;
                sFormat = "h:mm tt";

                sEffectDates = $@"{dtpDATE_FROM.Value.ToString(sFormat)}-{dtpDATE_TO.Value.ToString(sFormat)}";
            }

            if (lblLU_nID.Text.Length == 0)
            {
                int nCtrlNo = 1;
                var data = clsBiometrics.GetFirstRecord($"select top 1 nCtrlNo from tbl_LEAVE_UNDERTIME order by nCtrlNo desc");
                if (data != null)
                {
                    nCtrlNo = int.Parse(data["nCtrlNo"].ToString()) + 1;
                }


                object ID = clsBiometrics.ExecuteScalarQuery($@"INSERT INTO [tbl_LEAVE_UNDERTIME] ([nCtrlNo], [dTransDate], [nType], [EmpPK], [sEmpName], [sSection], [sBrand], [dEffectDate], [EffectDates], [sResumeToWork], [sReason], [sCoordinated], [sCheckBy], [sFiledBy], [sNotedBy], [sVerifiedBy], [sApprovedBy], [sLastUpdatedBy], [nPosted], [sNoOfDaysMin], [nCancelled], [sReasonCanc]) 
                VALUES ({nCtrlNo}, '{dtpdTransDate.Value.ToString("MM/dd/yyyy")}', {nType}, {lblEmpPK.Text}, '{lblsEmpName.Text}','{sSection}', '{sBrand}', '{dtpdEffectDate.Value.ToString("MM/dd/yyyy")}','{sEffectDates}', '{dtpsResumeToWork.Value.ToString(sFormat)}', '{txtsReason.Text}','{txtsCoordinated.Text}', '', '{txtsFiledBy.Text}', '{txtsNotedBy.Text}', '{txtsVerifiedBy.Text}', '{txtsApprovBy.Text}', '{clsDateTime.LastModify()}', 0, '{lblsNoOfDaysMin.Text}', 0, '') ");
                if (ID != null)
                {
                    lblLU_nID.Text = ID.ToString();
                    tsCancel.PerformClick();
                }
            }
            else
            {
                if (clsBiometrics.ExecuteNonQueryBool($@"UPDATE [tbl_LEAVE_UNDERTIME] SET [nType] = {nType}, [dEffectDate]='{dtpdEffectDate.Value.ToString("MM/dd/yyyy")}', [EffectDates]='{sEffectDates}', [sResumeToWork]='{dtpsResumeToWork.Value.ToString(sFormat)}', [sReason]='{txtsReason.Text}', [sCoordinated]='{txtsCoordinated.Text}', [sFiledBy]='{txtsFiledBy.Text}', [sNotedBy]='{txtsNotedBy.Text}', [sVerifiedBy]='{txtsVerifiedBy.Text}', [sApprovedBy]='{txtsApprovBy.Text}', [sLastUpdatedBy]='{clsDateTime.LastModify()}', [sNoOfDaysMin]='{lblsNoOfDaysMin.Text}' WHERE LU_nID={lblLU_nID.Text}"))
                {
                    tsCancel.PerformClick();
                }
            }



        }

        private void dtpdEffectDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpdEffectDate.Enabled == false)
            {
                return;
            }

            dtpDATE_FROM.Value = dtpdEffectDate.Value;
            dtpDATE_TO.Value = dtpdEffectDate.Value;

            getDayMinCount();
        }

        private void tsPost_Click(object sender, EventArgs e)
        {
            if (lblLU_nID.Text.Length == 0)
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

            clsBiometrics.ExecuteNonQueryBool($"UPDATE tbl_LEAVE_UNDERTIME SET nPosted = {(tsPosted.Visible ? 0 : 1)} WHERE (LU_nID = {lblLU_nID.Text} ) ");
            RefreshData();
        }

        private void tsVoid_Click(object sender, EventArgs e)
        {
            if (lblLU_nID.Text.Trim().Length == 0)
            {
                return;
            }

            FrmInputBox frm = new FrmInputBox("DISCARD LEAVE/UNDERTIME", "REASON");
            frm.ShowDialog();
            if (frm.isYes)
            {
                clsBiometrics.ExecuteNonQueryBool($"UPDATE tbl_LEAVE_UNDERTIME SET nCancelled=1,sReasonCanc='{frm.InpuText}'  WHERE (LU_nID = {lblLU_nID.Text} ) ");
                RefreshData();
            }

            frm.Dispose();


        }

        private void FrmLeaveUndertime_KeyDown(object sender, KeyEventArgs e)
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
    }

}
