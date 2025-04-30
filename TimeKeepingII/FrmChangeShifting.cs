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
    public partial class FrmChangeShifting : Form
    {

        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 ChangeShift.PK,CtrlNo,DDate,ShiftName,EmpID,EmpName,EffectDate,RefNo FROM [ChangeShift] LEFT JOIN  EmployeeName ON ChangeShift.EmpNo = EmployeeName.EmpPK LEFT JOIN ShiftingSchedule ON ChangeShift.Shift = ShiftingSchedule.PK ");

        const string sSelectSql = "SELECT [PK],[CtrlNo],[DDate],[EmpNo],[RefNo],[Shift],[EffectDate],[Remarks],[NotedBy],[ApprovedBy],[Posted],[Activate],[LastModified],[EmployeeName].EmpID as [EMPLOYEE_NO] , [EmployeeName].EmpName as [EmployeeName] FROM [ChangeShift] LEFT JOIN  EmployeeName ON ChangeShift.EmpNo = EmployeeName.EmpPK  ";
        DataTable dtEmployee;
        public FrmChangeShifting()
        {
            InitializeComponent();
        }

        private void FrmChangeShifting_Load(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            dtEmployee = clsPayrollSystem.dataList(clsGlobal.EmployeeFind);
            LoadShift();
        }

        private void LoadShift()
        {
            DataTable dt = clsBiometrics.dataList($@"SELECT [PK],[ShiftName] From ShiftingSchedule");
            clsTool.ComboBoxDataLoad(cmbShift, dt, "ShiftName", "PK");
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

                    bool isSuccess = clsBiometrics.ExecuteNonQueryBool($@"DELETE FROM ChangeShift WHERE PK = {lblPK.Text} ");
                    if (isSuccess)
                    {
                        clsComponentControl.ClearValue(this);
                    }
                }
            }
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
        private string CheckControlReference(string strCtrl)
        {
            string strValue = strCtrl;
            bool isExist = clsBiometrics.RecordExists($"SELECT ChangeShift.* FROM ChangeShift WHERE (CtrlNo = '{strValue}')");
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
            if (chkOpen.Checked == false && cmbShift.SelectedIndex == -1) { clsMessage.MessageShowWarning("Please Select Shifting Schedule!"); return; };
            if (dtpEffectDate.Checked == false) { clsMessage.MessageShowWarning("Please Supply Valid Date Effectively! "); return; }


            if (lblPK.Text.Length == 0) // INSERT
            {
                string strCtrl = "";
                var data = clsBiometrics.GetFirstRecord($"SELECT TOP 1 CtrlNo FROM ChangeShift WHERE (YEAR(DDate) = '{clsDateTime.NowYear()}') ORDER BY CtrlNo DESC ");
                if (data != null)
                {
                    strCtrl = int.Parse(data["CtrlNo"].ToString()).ToString("000000000#");
                }
                else
                {
                    strCtrl = clsDateTime.NowYear().ToString() + "000001";
                }
                strCtrl = CheckControlReference(strCtrl);


                object dataID = clsBiometrics.ExecuteScalarQuery($@"INSERT INTO ChangeShift (CtrlNo, EmpNo, DDate,
                                                                                Shift,EffectDate, Remarks, LastModified,NotedBy, ApprovedBy, RefNo)
                                                                                VALUES ('{strCtrl}',{lblEmpNo.Text},'{dtpDDate.Value}',
                                                                                { (chkOpen.Checked == false ? cmbShift.SelectedValue : 0) },'{dtpEffectDate.Value}','{txtRemarks.Text}',
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

                bool isSuccess = clsBiometrics.ExecuteNonQueryBool($@"UPDATE ChangeShift 
                                                            SET DDate = '{dtpDDate.Value}',
                                                            Shift ={(chkOpen.Checked == false ? cmbShift.SelectedValue : 0)},
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

        private void tsFirst_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql}  ORDER BY CtrlNo ";
            DataRecord(squery);
        }

        private void tsLast_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql}  ORDER BY CtrlNo desc ";
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
        private void GetShift()
        {
            int selectedId;
            if (int.TryParse(cmbShift.SelectedValue?.ToString(), out selectedId))
            {
                var data = clsBiometrics.GetFirstRecord($@"select * from [ShiftingSchedule] WHERE PK = {selectedId}");
                if (data != null)
                {
                    lblIN_AM.Text = clsMisc.FX_TIME(data["IN_AM"].ToString());
                    lblOUT_LUNCH.Text = clsMisc.FX_TIME(data["OUT_Lunch"].ToString());
                    lblIN_LUNCH.Text = clsMisc.FX_TIME(data["IN_Lunch"].ToString());
                    lblOUT_BREAK.Text = clsMisc.FX_TIME(data["OUT_Break"].ToString());
                    lblIN_BREAK.Text = clsMisc.FX_TIME(data["IN_Break"].ToString());
                    lblLUNCH.Text = data["Lunch"].ToString();
                    lblBREAK.Text = data["BreakTime"].ToString();
                    lblOUT_PM.Text = clsMisc.FX_TIME(data["OUT_PM"].ToString());
                    chkFixed.Checked = data["Fixed"].ToString() == "1" ? true : false;

                }
            }

        }
        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbShift.SelectedIndex == -1)
            {
                lblIN_AM.Text = "";
                lblOUT_LUNCH.Text = "";
                lblIN_LUNCH.Text = "";
                lblOUT_BREAK.Text = "";
                lblIN_BREAK.Text = "";
                lblOUT_PM.Text = "";
                lblLUNCH.Text = "";
                lblBREAK.Text = "";
                chkFixed.Checked = false;

            }
            else
            {
                GetShift();
                if (cmbShift.SelectedIndex > -1)
                {
                    chkOpen.Checked = false;
                }

            }
            GetShift();
        }

        private void chkFixed_Click(object sender, EventArgs e)
        {
            chkFixed.Checked = !chkFixed.Checked;
        }

        private void chkOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOpen.Enabled == false)
            {
                return;
            }
            cmbShift.Enabled = !chkOpen.Checked;
            if (chkOpen.Checked)
            {
                cmbShift.SelectedIndex = -1;
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshData()
        {
            string squery = $@"{sSelectSql} WHERE PK = {lblPK.Text}";
            DataRecord(squery);
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

            clsBiometrics.ExecuteNonQueryBool($"UPDATE ChangeShift SET Posted = {(tsPosted.Visible ? 0 : 1)} WHERE (PK = {lblPK.Text} ) ");
            RefreshData();

        }
    }
}
