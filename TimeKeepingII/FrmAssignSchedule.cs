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
        DataTable dtEmployee;
        public FrmAssignSchedule()
        {
            InitializeComponent();
        }

        private void FrmAssignSchedule_Load(object sender, EventArgs e)
        {


            string str = $@"SELECT PK, 
                        EEmployeeIDNo, 
                        ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS Name, ELastName, 
                        ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS EActive, 
                        ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS Hired
                        FROM tbl_Profile_IDNumber 
                        WHERE (ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND 
                        (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) <> 4)  
                        AND (ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) = 1) 
                        ORDER BY ELastName + ',  ' + EFirstName + '  ' + EMiddleName, EEmployeeIDNo
                        ";
            dtEmployee = clsPayrollSystem.dataList(str);
            LoadShift();
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            clsComponentControl.ClearValue(this);

            OpenLoad();
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
                        OpenLoad();
                        lblEMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                        lblEmployeeName.Text = empData["Name"].ToString();
                        lblEMP_PK.Text = empData["PK"].ToString();

                    }

                }
            }
        }
        private void LoadShift()
        {


            string ShiftingSchedule = $@"SELECT [PK],[ShiftName] From ShiftingSchedule";

            DataTable dt = clsBiometrics.dataList(ShiftingSchedule);


            ComboBox[] dayCombos = { cmbMonday, cmbTuesday, cmbWednesday, cmbThursday, cmbFriday, cmbSaturday, cmbSunday };

            foreach (var cmb in dayCombos)
            {
                DataTable copy = dt.Copy();
                cmb.DataSource = copy;
                cmb.DisplayMember = "ShiftName";
                cmb.ValueMember = "PK";
            }



        }
        private void tsCancel_Click(object sender, EventArgs e)
        {

            if (lblPK.Text.Length > 0)
            {


            }
            else
            {
                clsComponentControl.ClearValue(this);
            }

            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);

            OpenLoad();
        }

        private void OpenMonday()
        {

            if(chkOpenMon.Enabled == false)
            {
                return;
            }

            cmbMonday.Enabled = chkOpenMon.Checked;
            chkFixedMon.Enabled = chkOpenMon.Checked;
            if (!chkOpenMon.Checked)
            {
                cmbMonday.SelectedIndex = -1;
            }
            else
            {
                chkRestday1.Checked = false;
            }


        }
        private void OpenTuesday()
        {   

            if(chkOpenTue.Enabled == false)
            {
                return;
            }

            cmbTuesday.Enabled = chkOpenTue.Checked;

            chkFixedTue.Enabled = chkOpenTue.Checked;
            if (!chkOpenTue.Checked)
            {
                cmbTuesday.SelectedIndex = -1;
            }
            else
            {
                chkRestday2.Checked = false;
            }
        }
        private void OpenWednesday()
        {
            if(chkOpenWed.Enabled == false)
            {

                return;
            }


            cmbWednesday.Enabled = chkOpenWed.Checked;
            chkFixedWed.Enabled = chkOpenWed.Checked;
            if (!chkOpenWed.Checked)
            {
                cmbWednesday.SelectedIndex = -1;
            }
            else
            {
                chkRestday3.Checked = false;
            }
        }
        private void OpenThursday()
        {
            if(chkOpenThu.Enabled == false)
            {
                return;
            }

            cmbThursday.Enabled = chkOpenThu.Checked;

            chkFixedThu.Enabled = chkOpenThu.Checked;
            if (!chkOpenThu.Checked)
            {
                cmbThursday.SelectedIndex = -1;
            }
            else
            {
                chkRestday4.Checked = false;
            }
        }
        private void OpenFriday()
        {
            if (chkOpenFri.Enabled == false)
            {
                return;
            }


            cmbFriday.Enabled = chkOpenFri.Checked;

            chkFixedFri.Enabled = chkOpenFri.Checked;
            if (!chkOpenFri.Checked)
            {
                cmbFriday.SelectedIndex = -1;
            }
            else
            {
                chkRestday5.Checked = false;
            }
        }
        private void OpenSaturday()
        {

            if (chkOpenSat.Enabled == false)
            {
                return;
            }

            cmbSaturday.Enabled = chkOpenSat.Checked;
            chkFixedSat.Enabled = chkOpenSat.Checked;
            if (!chkOpenSat.Checked)
            {
                cmbSaturday.SelectedIndex = -1;
            }
            else
            {
                chkRestday6.Checked = false;
            }
        }
        private void OpenSunday()
        {

            if (chkOpenSun.Enabled == false)
            {
                return;
            }

            cmbSunday.Enabled = chkOpenSun.Checked;

            chkFixedSun.Enabled = chkOpenSun.Checked;
            if (!chkOpenSun.Checked)
            {
                cmbSunday.SelectedIndex = -1;
            }
            else
            {
                chkRestday7.Checked = false;
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
            }
        }

        private void chkRestday2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday2.Checked)
            {
                chkOpenTue.Checked = false;
            }
        }

        private void chkRestday3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday3.Checked)
            {
                chkOpenWed.Checked = false;
            }
        }

        private void chkRestday4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday4.Checked)
            {
                chkOpenThu.Checked = false;
            }
        }

        private void chkRestday5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday5.Checked)
            {
                chkOpenFri.Checked = false;
            }
        }

        private void chkRestday6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday6.Checked)
            {
                chkOpenSat.Checked = false;
            }
        }

        private void chkRestday7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestday7.Checked)
            {
                chkOpenSun.Checked = false;
            }
        }
    }
}
