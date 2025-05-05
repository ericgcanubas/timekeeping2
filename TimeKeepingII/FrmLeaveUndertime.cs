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
        DataTable dtEmployee;



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
            dtEmployee = clsPayrollSystem.dataList(clsGlobal.EmployeeFind);
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
            }
        }
        private void setType(int type)
        {
            if (type == 1)
            {
                dtpDATE_FROM.Format = DateTimePickerFormat.Short;
                dtpDATE_TO.Format = DateTimePickerFormat.Short;
                dtpsResumeToWork.Format = DateTimePickerFormat.Short;
            }
            else
            {
                dtpDATE_FROM.Format = DateTimePickerFormat.Custom;
                dtpDATE_TO.Format = DateTimePickerFormat.Custom;
                dtpsResumeToWork.Format = DateTimePickerFormat.Custom;

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
            FrmList frm = new FrmList(dtEmployee, "Requested");
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
                        return;
                    }
                    lblsNoOfDaysMin.Text = $"{dayCount + 1} Day ";
                    return;
                }
                lblsNoOfDaysMin.Text = "";


            }


            if (rdbUndertime.Checked)
            {
                lblsNoOfDaysMin.Text = clsDateTime.TimeDisplay(dtpDATE_FROM.Value, dtpDATE_TO.Value);
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
    }

}
