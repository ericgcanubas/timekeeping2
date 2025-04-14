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
    public partial class FrmShiftingSchedule : Form
    {

        private readonly string sSelectSql = "SELECT TOP 1 ShiftingSchedule.PK, ShiftingSchedule.ShiftName,  ShiftingSchedule.ShiftType, ShiftingType.ShiftType AS ShiftTypeName,  ShiftingSchedule.IN_AM, ShiftingSchedule.OUT_Lunch,  ShiftingSchedule.IN_Lunch, ShiftingSchedule.OUT_Break,  ShiftingSchedule.IN_Break, ShiftingSchedule.OUT_PM,  ShiftingSchedule.LastModifiedBy, ShiftingSchedule.Fixed,  ShiftingSchedule.Lunch, ShiftingSchedule.BreakTime  FROM ShiftingSchedule LEFT OUTER JOIN  ShiftingType ON ShiftingSchedule.ShiftType = ShiftingType.PK";
        public FrmShiftingSchedule()
        {
            InitializeComponent();
        }

        private void FrmShiftingSchedule_Load(object sender, EventArgs e)
        {

            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            DataTable dt = clsBiometrics.dataList("SELECT [PK],ShiftType FROM [ShiftingType] ");
            cmbShiftType.DataSource = dt;
            cmbShiftType.DisplayMember = "ShiftType";
            cmbShiftType.ValueMember = "PK";

            string LastOpenShiftName = "XMASFS";
            string squery = $@"{sSelectSql}  WHERE (ShiftingSchedule.ShiftName = '{LastOpenShiftName}')  ORDER BY ShiftingSchedule.ShiftName ";

            DataRecord(squery);
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            if (!clsAccessControl.AccessRight(this.AccessibleDescription, "ADD"))
            {
                return;
            }

            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);
            clsComponentControl.ClearValue(this);
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

        private void tsSave_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblPK.Text.Length > 0)
            {
                string squery = $@"{sSelectSql}  WHERE  ShiftingSchedule.PK = {lblPK.Text} ORDER BY ShiftingSchedule.PK  ";
                DataRecord(squery);
            }

        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataRecord(string squery)
        {

            var data = clsBiometrics.GetFirstRecord(squery);
            if (data != null)
            {
                clsComponentControl.AssignValue(this, data);
            }

        }

        private void tsFirst_Click(object sender, EventArgs e)
        {

            string squery = $@"{sSelectSql}  ORDER BY ShiftingSchedule.PK ";

            DataRecord(squery);
        }

        private void tsBack_Click(object sender, EventArgs e)
        {
            if(lblPK.Text.Length == 0)
            {
                return;
            }
            string squery = $@"{sSelectSql}  WHERE ShiftingSchedule.PK < {lblPK.Text}  ORDER BY ShiftingSchedule.PK DESC ";

            DataRecord(squery);
        }

        private void tsNext_Click(object sender, EventArgs e)
        {

            if (lblPK.Text.Length == 0)
            {
                return;
            }
            string squery = $@"{sSelectSql}  WHERE  ShiftingSchedule.PK > {lblPK.Text} ORDER BY ShiftingSchedule.PK  ";

            DataRecord(squery);
        }

        private void tsLast_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql}   ORDER BY ShiftingSchedule.PK  DESC";

            DataRecord(squery);
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
        }

        private void tsFind_Click(object sender, EventArgs e)
        {
            FrmFind frm = new FrmFind($@"SELECT TOP 1000 ShiftingSchedule.PK, ShiftingSchedule.ShiftName, ShiftingType.ShiftType  FROM ShiftingSchedule LEFT OUTER JOIN  ShiftingType ON ShiftingSchedule.ShiftType = ShiftingType.PK ");
            frm.ShowDialog();

            if(frm.isYes == true )
            {
                lblPK.Text = frm.PK;
                string squery = $@"{sSelectSql}  WHERE ShiftingSchedule.PK = {lblPK.Text} ORDER BY ShiftingSchedule.PK  ";
                DataRecord(squery);
            }
        }
    }
}
