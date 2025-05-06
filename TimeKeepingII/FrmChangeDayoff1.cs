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
    public partial class FrmChangeDayoff1 : Form
    {
        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 ChangeRD.PK,CtrlNo,DDate,EmpName,EffectDate,RefNo FROM [ChangeRD] LEFT JOIN  EmployeeName ON ChangeRD.EmpNo = EmployeeName.EmpPK  ");

        const string sSelectSql = "SELECT top 1 [PK],[CtrlNo],[DDate],[EmpNo],[RefNo],[RestDayFrom],[RestDay],[EffectDateFrom],[EffectDate],[Remarks],[NotedBy],[ApprovedBy],[Posted],[Activate],[LastModified],[EmployeeName].EmpID as [EMPLOYEE_NO] , [EmployeeName].EmpName as [EmployeeName] FROM [ChangeRD] LEFT JOIN  EmployeeName ON ChangeRD.EmpNo = EmployeeName.EmpPK  ";
        DataTable dtEmployee;

        public FrmChangeDayoff1()
        {
            InitializeComponent();
        }
        private void DataRecord(string squery)
        {
            var data = clsBiometrics.GetFirstRecord(squery);
            if (data != null)
            {
                clsComponentControl.AssignValue(this, data);
                int postValue = int.Parse(data["Posted"].ToString());
                tsPosted.Visible = postValue == 1 ? true : false;
                tsPost.Text = postValue == 1 ? "Unpost" : "Post";
                tsEdit.Enabled = postValue == 1 ? false : true;
                tsDelete.Enabled = postValue == 1 ? false : true;

            }
        }
        private void FrmChangeDayoff_Load(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            dtEmployee = clsPayrollSystem.dataList(clsGlobal.EmployeeFind);
            LoadWeekDays();


            cmbRestDayFrom.KeyDown += (s, eArgs) => eArgs.Handled = true;
            cmbRestDay.KeyDown += (s, eArgs) => eArgs.Handled = true;

        }
        private void LoadWeekDays()
        {
            DataTable dt = clsTool.WeekDayList();
            clsTool.ComboBoxDataLoad(cmbRestDayFrom, dt, "Text", "Value");
            clsTool.ComboBoxDataLoad(cmbRestDay, dt, "Text", "Value");




        }
        private string CheckControlReference(string strCtrl)
        {
            string strValue = strCtrl;
            bool isExist = clsBiometrics.RecordExists($"SELECT ChangeRD.* FROM ChangeRD WHERE (CtrlNo = '{strValue}')");
            if (isExist)
            {
                string dtValue = (Convert.ToDouble(strValue) + 1).ToString("000000000#");
                strValue = CheckControlReference(dtValue);
            }

            return strValue;
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            if (lblEmpNo.Text.Length == 0) { clsMessage.MessageShowWarning("Please Select Employee!"); return; };
            if (dtpEffectDateFrom.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date From! "); return; }
            if (dtpEffectDate.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date To! "); return; }

            if (lblPK.Text.Length == 0) // INSERT
            {
                string strCtrl = "";
                var data = clsBiometrics.GetFirstRecord($"SELECT TOP 1 CtrlNo FROM ChangeRD WHERE (YEAR(DDate) = '{clsDateTime.NowYear()}') ORDER BY CtrlNo DESC ");
                if (data != null)
                {
                    strCtrl = int.Parse(data["CtrlNo"].ToString()).ToString("000000000#");
                }
                else
                {
                    strCtrl = clsDateTime.NowYear().ToString() + "000001";
                }
                strCtrl = CheckControlReference(strCtrl);
                object dataID = clsBiometrics.ExecuteScalarQuery($@"INSERT INTO ChangeRD (CtrlNo, EmpNo, DDate,
                                                                                RestDayFrom, RestDay,
                                                                                EffectDateFrom,EffectDate, Remarks, 
                                                                                LastModified,NotedBy, ApprovedBy, RefNo)
                                                                                VALUES ('{strCtrl}',{lblEmpNo.Text},'{dtpDDate.Value}',
                                                                                {cmbRestDayFrom.SelectedValue},{cmbRestDay.SelectedValue},
                                                                                '{dtpEffectDateFrom.Value}','{dtpEffectDate.Value}','{txtRemarks.Text}',
                                                                                '{clsDateTime.LastModify()}','{txtNotedBy.Text}',
                                                                                '{txtApprovedBy.Text}','{txtRefNo.Text}')");

                if (dataID == null)
                {
                    return;
                }

                lblPK.Text = Convert.ToInt32(dataID).ToString();
                tsCancel.PerformClick();

            }
            else
            {
                // UPDATE

                bool isSuccess = clsBiometrics.ExecuteNonQueryBool($@"UPDATE ChangeRD 
                                                            SET DDate='{dtpDDate.Value}',
                                                            RestDayFrom={cmbRestDayFrom.SelectedValue},
                                                            RestDay={cmbRestDay.SelectedValue},
                                                            EffectDateFrom='{dtpEffectDate.Value}',
                                                            EffectDate='{dtpEffectDate.Value}',
                                                            Remarks='{txtRemarks.Text}',
                                                            LastModified='{clsDateTime.LastModify()}',
                                                            NotedBy='{txtNotedBy.Text}',
                                                            ApprovedBy='{txtApprovedBy.Text}',
                                                            RefNo='{txtRefNo.Text}' 
                                                            WHERE PK={lblPK.Text} ");
                if (!isSuccess)
                {
                    return;
                }

                tsCancel.PerformClick();

            }

            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (lblPK.Text.Length == 0)
            {
                return;
            }

            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "DELETE"))
            {
                return;
            }

            if (clsMessage.MessageQuestionWarning("ARE YOU SURE IN DELETING THIS RECORD? "))
            {
                clsBiometrics.ExecuteNonQuery($@"Delete From ChangeRD WHERE ChangeRD.PK = {lblPK.Text}");
                clsComponentControl.ClearValue(this);
            }
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "ADD"))
            {
                return;
            }

            if (dtEmployee != null)
            {
                FrmList frm = new FrmList(dtEmployee);
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

                        clsComponentControl.HeaderMenu(tsHeaderControl, false);
                        clsComponentControl.ObjectEnable(this, true);
                        clsComponentControl.ClearValue(this);

                        lblEMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                        lblEmployeeName.Text = empData["Name"].ToString();
                        lblEmpNo.Text = empData["PK"].ToString();

                        tsPosted.Visible = false;
                        tsPost.Text = "Post";
                    }


                }
            }
        }

        private void tsPost_Click(object sender, EventArgs e)
        {
            if (lblPK.Text.Length == 0)
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

            clsBiometrics.ExecuteNonQueryBool($"UPDATE ChangeRD SET Posted = {(tsPosted.Visible ? 0 : 1)} WHERE (PK = {lblPK.Text} ) ");
            RefreshData();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {

            if (lblPK.Text.Length == 0)
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
        private void RefreshData()
        {
            string squery = $@"{sSelectSql} WHERE PK = {lblPK.Text}";
            DataRecord(squery);
        }

        private void tsFirst_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql}  ORDER BY CtrlNo ";
            DataRecord(squery);
        }

        private void tsBack_Click(object sender, EventArgs e)
        {
            if (lblCtrlNo.Text.Length == 0)
            {
                tsFirst.PerformClick();
                return;
            }
            string squery = $@"{sSelectSql}  WHERE CtrlNo < '{lblCtrlNo.Text}'  ORDER BY CtrlNo DESC ";
            DataRecord(squery);
        }

        private void tsNext_Click(object sender, EventArgs e)
        {
            if (lblCtrlNo.Text.Length == 0)
            {
                tsLast.PerformClick();
                return;
            }
            string squery = $@"{sSelectSql}  WHERE  CtrlNo > '{lblCtrlNo.Text}' ORDER BY CtrlNo  ";

            DataRecord(squery);
        }

        private void tsLast_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql}  ORDER BY CtrlNo desc ";
            DataRecord(squery);
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

        private void FrmChangeDayoff_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void cmbRestDayFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmbRestDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void dtpEffectDateFrom_ValueChanged(object sender, EventArgs e)
        {

            int W = ((int)dtpEffectDateFrom.Value.DayOfWeek);
            if (W == 0)
            {
                cmbRestDayFrom.SelectedValue = 7;
            }
            else
            {
                cmbRestDayFrom.SelectedValue = W;
            }

        }

        private void dtpEffectDate_ValueChanged(object sender, EventArgs e)
        {
            int W = ((int)dtpEffectDate.Value.DayOfWeek);
            if (W == 0)
            {
                cmbRestDay.SelectedValue = 7;
            }
            else
            {
                cmbRestDay.SelectedValue = W;
            }

        }
    }

}
