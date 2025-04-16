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
        public FrmAssignSchedule()
        {
            InitializeComponent();
        }

        private void FrmAssignSchedule_Load(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            clsComponentControl.ClearValue(this);

            OpenLoad();



        }
        private void loadEmployeeList()
        {
            
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
            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);
            clsComponentControl.ClearValue(this);
            OpenLoad();
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
            cmbMonday.Enabled = chkOpenMon.Checked;
            chkRestday1.Enabled = chkOpenMon.Checked;
            chkFixedMon.Enabled = chkOpenMon.Checked;
            if (!chkOpenMon.Checked)
            {
                cmbMonday.SelectedIndex = -1;
            }


        }
        private void OpenTuesday()
        {
            cmbTuesday.Enabled = chkOpenTue.Checked;
            chkRestday2.Enabled = chkOpenTue.Checked;
            chkFixedTue.Enabled = chkOpenTue.Checked;
            if (!chkOpenTue.Checked)
            {
                cmbTuesday.SelectedIndex = -1;
            }
        }
        private void OpenWednesday()
        {
            cmbWednesday.Enabled = chkOpenWed.Checked;
            chkRestday3.Enabled = chkOpenWed.Checked;
            chkFixedWed.Enabled = chkOpenWed.Checked;
            if (!chkOpenWed.Checked)
            {
                cmbWednesday.SelectedIndex = -1;
            }
        }
        private void OpenThursday()
        {
            cmbThursday.Enabled = chkOpenThu.Checked;
            chkRestday4.Enabled = chkOpenThu.Checked;
            chkFixedThu.Enabled = chkOpenThu.Checked;
            if (!chkOpenThu.Checked)
            {
                cmbThursday.SelectedIndex = -1;
            }
        }
        private void OpenFriday()
        {
            cmbFriday.Enabled = chkOpenFri.Checked;
            chkRestday5.Enabled = chkOpenFri.Checked;
            chkFixedFri.Enabled = chkOpenFri.Checked;
            if (!chkOpenFri.Checked)
            {
                cmbFriday.SelectedIndex = -1;
            }
        }
        private void OpenSaturday()
        {
            cmbSaturday.Enabled = chkOpenSat.Checked;
            chkRestday6.Enabled = chkOpenSat.Checked;
            chkFixedSat.Enabled = chkOpenSat.Checked;
            if (!chkOpenSat.Checked)
            {
                cmbSaturday.SelectedIndex = -1;
            }
        }
        private void OpenSunday()
        {
            cmbSunday.Enabled = chkOpenSun.Checked;
            chkRestday7.Enabled = chkOpenSun.Checked;
            chkFixedSun.Enabled = chkOpenSun.Checked;
            if (!chkOpenSun.Checked)
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
                chkRestday1.Checked = false;
                chkFixedMon.Checked = false;

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
                chkRestday2.Checked = false;
                chkFixedTue.Checked = false;

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
                chkRestday3.Checked = false;
                chkFixedWed.Checked = false;

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
                chkRestday4.Checked = false;
                chkFixedThu.Checked = false;

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
                chkRestday5.Checked = false;
                chkFixedFri.Checked = false;

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
                chkRestday6.Checked = false;
                chkFixedSat.Checked = false;

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
                chkRestday7.Checked = false;
                chkFixedSun.Checked = false;

            }
        }
    }
}
