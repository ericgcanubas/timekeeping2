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
            if (!dtpDDate.Enabled)
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

            if (this.Tag != null)
            {
                //Viewing
                lblPRW_nID.Text = this.Tag.ToString();
                RefreshData();

            }

            if (this.AccessibleName != null)
            {
                // New
                SetNewData(this.AccessibleName.ToString());

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
            if (!string.IsNullOrWhiteSpace(lblsALDates.Text))
            {
                string[] dates = lblsALDates.Text.Split(',');
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
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "ADD"))
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
            this.Close();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            if (lblPRW_nID.Text.Length == 0)
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

        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (lblPRW_nID.Text.Length == 0)
            {
                return;
            }
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "DELETE"))
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


            if (lblPRW_nID.Text.Length == 0)
            {

            }
            else
            {

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
    }
}
