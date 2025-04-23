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
        private void gotCompute()
        {
            string LunchIN = dtpIN_Lunch.Value.ToString("HH:mm");
            string LunchOut = dtpOUT_Lunch.Value.ToString("HH:mm");


            DateTime lunchInTime = DateTime.ParseExact(LunchIN, "HH:mm", null);
            DateTime lunchOutTime = DateTime.ParseExact(LunchOut, "HH:mm", null);

            TimeSpan lunchDuration = lunchInTime - lunchOutTime;

            // Get the total minutes
            decimal totalMinutes = (decimal)lunchDuration.TotalMinutes;
            numLunch.Value = totalMinutes;





            string BreakIn = dtpIN_Break.Value.ToString("HH:mm");
            string BreakOut = dtpOUT_Break.Value.ToString("HH:mm");

            DateTime breakInTime = DateTime.ParseExact(BreakIn, "HH:mm", null);
            DateTime breakOutTime = DateTime.ParseExact(BreakOut, "HH:mm", null);

            TimeSpan breakDuration = breakInTime - breakOutTime;

            decimal totalMinutes2 = (decimal)breakDuration.TotalMinutes;
            numBreakTime.Value = totalMinutes2;

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
            if (txtShiftName.Text.Length == 0)
            {
                clsMessage.MessageShowInfo("Shift name is required.");
                return;
            }

            if (cmbShiftType.SelectedIndex == -1)
            {
                clsMessage.MessageShowInfo("Please Select Shift Type...");
                return;
            }

            if (numLunch.Value == 0)
            {

                if (dtpIN_Lunch.Value.ToString("HH:mm") == "00:00" && dtpOUT_Lunch.Value.ToString("HH:mm") == "00:00")
                {
                    clsMessage.MessageShowInfo("Please Supply how many minutes should Lunch Time be...      ");
                    return;
                }
            }
            else if (numLunch.Value > 0)
            {
                if (dtpIN_Lunch.Value.ToString("HH:mm") == "00:00" || dtpOUT_Lunch.Value.ToString("HH:mm") == "00:00")
                {
                    clsMessage.MessageShowInfo("Please Supply Time should Lunch Time be...      ");
                    return;
                }
            }
            else
            {
                clsMessage.MessageShowInfo("Please Check Value ...     ");
                return;

            }

            if (numBreakTime.Value == 0)
            {
                if (dtpOUT_Break.Value.ToString("HH:mm") != "00:00" && dtpIN_Break.Value.ToString("HH:mm") != "00:00")
                {
                    clsMessage.MessageShowInfo("Please Supply how many minutes should Break Time be...      ");
                    return;
                }
            }
            else if (numBreakTime.Value > 0)
            {
                if (dtpOUT_Break.Value.ToString("HH:mm") == "00:00" || dtpIN_Break.Value.ToString("HH:mm") == "00:00")
                {
                    clsMessage.MessageShowInfo("Please Supply Time should Break Time be...         ");
                    return;
                }
            }
            else
            {
                clsMessage.MessageShowInfo("Please Check Value ...     ");
                return;
            }




            string LastModifiedBy = DateTime.Now.ToString() + " " + clsAccessControl.gsUsername;

            try
            {
                if (lblPK.Text.Length == 0)
                {
                    // INSERT

                    int PK = clsBiometrics.ExecuteNonQuery($@"INSERT INTO ShiftingSchedule 
                                                                   (ShiftName,IN_AM,OUT_Lunch,
                                                                    IN_Lunch,OUT_Break,
                                                                    IN_Break,OUT_PM,LastModifiedBy,
                                                                    Fixed,Lunch,BreakTime,Add_Edit,ShiftType)
                                                                    VALUES('{txtShiftName.Text.Replace("'", "`")}',
                                                                            '{"1990-01-01 " + dtpIN_AM.Value.ToString("HH:mm")}',
                                                                            '{"1990-01-01 " + dtpOUT_Lunch.Value.ToString("HH:mm")}',
                                                                            '{"1990-01-01 " + dtpIN_Lunch.Value.ToString("HH:mm")}',
                                                                            '{"1990-01-01 " + dtpOUT_Break.Value.ToString("HH:mm")}',
                                                                            '{"1990-01-01 " + dtpIN_Break.Value.ToString("HH:mm")}',
                                                                            '{"1990-01-01 " + dtpOUT_PM.Value.ToString("HH:mm")}',
                                                                            '{LastModifiedBy}',
                                                                            {(chkFixed.Checked == true ? 1 : 0)},
                                                                            {numLunch.Value},
                                                                            {numBreakTime.Value},
                                                                            0,
                                                                            {cmbShiftType.SelectedValue}) ");


                    if (PK > 0)
                    {
                        return;
                    }

                    string squery = $@"{sSelectSql}  WHERE ShiftingSchedule.PK = {PK} ORDER BY ShiftingSchedule.PK ";
                    DataRecord(squery);
                }
                else
                {
                    // UPDATE

                    if (!clsBiometrics.ExecuteNonQueryBool($@"UPDATE ShiftingSchedule SET ShiftName='{txtShiftName.Text.Replace("'", "`")}',IN_AM='{"1990-01-01 " + dtpIN_AM.Value.ToString("HH:mm")}',OUT_Lunch='{"1990-01-01 " + dtpOUT_Lunch.Value.ToString("HH:mm")}',IN_Lunch='{"1990-01-01 " + dtpIN_Lunch.Value.ToString("HH:mm")}',OUT_Break='{"1990-01-01 " + dtpOUT_Break.Value.ToString("HH:mm")}',IN_Break='{"1990-01-01 " + dtpIN_Break.Value.ToString("HH:mm")}',OUT_PM='{"1990-01-01 " + dtpOUT_PM.Value.ToString("HH:mm")}',LastModifiedBy='{LastModifiedBy}',Fixed={(chkFixed.Checked == true ? 1 : 0)},Lunch={numLunch.Value},BreakTime={numBreakTime.Value},Add_Edit=0, ShiftType={cmbShiftType.SelectedValue} WHERE PK = {lblPK.Text}"))
                    {
                        return;
                    }
                }



                clsComponentControl.HeaderMenu(tsHeaderControl, true);
                clsComponentControl.ObjectEnable(this, false);
            }
            catch (Exception ex)
            {

                clsMessage.MessageShowError(ex.Message);
            }


        }
        private void SaveEntry()
        {

        }
        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblPK.Text.Length > 0)
            {
                string squery = $@"{sSelectSql}  WHERE ShiftingSchedule.PK = {lblPK.Text} ORDER BY ShiftingSchedule.PK ";
                DataRecord(squery);
            }
            else
            {
                clsComponentControl.ClearValue(this);
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
            if (lblPK.Text.Length == 0)
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


            clsComponentControl.ClearValue(this); // clear
        }

        private void tsFind_Click(object sender, EventArgs e)
        {
            FrmFind frm = new FrmFind($@"SELECT TOP 1000 ShiftingSchedule.PK, ShiftingSchedule.ShiftName, ShiftingType.ShiftType  FROM ShiftingSchedule LEFT OUTER JOIN  ShiftingType ON ShiftingSchedule.ShiftType = ShiftingType.PK ");
            frm.ShowDialog();

            if (frm.isYes == true)
            {
                lblPK.Text = frm.PK;
                string squery = $@"{sSelectSql}  WHERE ShiftingSchedule.PK = {lblPK.Text} ORDER BY ShiftingSchedule.PK  ";
                DataRecord(squery);
            }
        }

        private void FrmShiftingSchedule_KeyDown(object sender, KeyEventArgs e)
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
                default:
                    // Nothing
                    break;
            }

        }

        private void FrmShiftingSchedule_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void dtpOUT_Lunch_ValueChanged(object sender, EventArgs e)
        {
            gotCompute();
        }

        private void dtpIN_Lunch_ValueChanged(object sender, EventArgs e)
        {
            gotCompute();
        }

        private void dtpOUT_Break_ValueChanged(object sender, EventArgs e)
        {
            gotCompute();
        }

        private void dtpIN_Break_ValueChanged(object sender, EventArgs e)
        {
            gotCompute();
        }
        private void dtpIN_AM_Leave(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {
                return;
            }
            dtpOUT_Lunch.Checked = true;
            dtpOUT_Lunch.Value = dtpIN_AM.Value.AddHours(1);
        }
        private void dtpOUT_Lunch_Leave(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {
                return;
            }
            dtpIN_Lunch.Checked = true;
            dtpIN_Lunch.Value = dtpOUT_Lunch.Value.AddHours(1);
        }
        private void dtpIN_Lunch_Leave(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {
                return;
            }
            dtpOUT_Break.Checked = true;
            dtpOUT_Break.Value = dtpIN_Lunch.Value.AddHours(1);
        }
        private void dtpOUT_Break_Leave(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {
                return;
            }
            dtpIN_Break.Checked = true;
            dtpIN_Break.Value = dtpOUT_Break.Value.AddMinutes(30);
        }
        private void dtpIN_Break_Leave(object sender, EventArgs e)
        {
            if (lblPK.Text.Length > 0)
            {
                return;
            }

            dtpOUT_PM.Value = dtpIN_Break.Value.AddMinutes(30);
        }
    }
}
