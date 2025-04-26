using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsComponentControl
    {
        public static void HeaderMenu(ToolStrip tsControl, bool isActive)
        {

            foreach (ToolStripItem item in tsControl.Items)
            {
                if (item is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)item;

                    switch (btn.Text)
                    {
                        case "Add":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "Edit":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "Delete":
                            btn.Enabled = isActive ? true : false;
                            break;

                        case "Save":
                            btn.Enabled = isActive ? false : true;
                            break;

                        case "Undo":
                            btn.Enabled = isActive ? false : true;
                            break;

                        case "Find":
                            btn.Enabled = isActive ? true : false;
                            break;

                        case "Close":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "First":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "Last":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "Back":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "Next":
                            btn.Enabled = isActive ? true : false;
                            break;

                        case "Print":
                            btn.Enabled = isActive ? true : false;
                            break;
                        case "Post":
                            btn.Enabled = isActive ? true : false;
                            break;
                        default:
                            // do nothing
                            break;
                    }
                }




            }

        }

        public static void ObjectEnable(Control ctl, bool isEnable)
        {
            foreach (Control item in ctl.Controls)
            {
                string strName = item.Name.ToString().Trim().ToLower().Substring(0, 3);
                switch (strName)
                {
                    case "txt":
                        TextBox txt = (TextBox)item;
                        txt.ReadOnly = !isEnable;
                        break;

                    case "num":
                        NumericUpDown num = (NumericUpDown)item;
                        num.Enabled = isEnable;
                        break;

                    case "cmd":
                        Button cmd = (Button)item;
                        cmd.Enabled = isEnable;
                        break;
                    case "cmb":
                        ComboBox cmb = (ComboBox)item;
                        cmb.Enabled = isEnable;
                        break;

                    case "chk":
                        CheckBox chk = (CheckBox)item;
                        chk.Enabled = isEnable;
                        break;

                    case "rdb":
                        RadioButton rdb = (RadioButton)item;
                        rdb.Enabled = isEnable;
                        break;
                    case "dtp":
                        DateTimePicker dtp = (DateTimePicker)item;
                        dtp.Enabled = isEnable;
                        break;
                    case "tab":
                        TabControl tab = (TabControl)item;
                        ObjectEnable(tab, isEnable);
                        break;
                    case "tbp":
                        TabPage tbp = (TabPage)item;
                        ObjectEnable(tbp, isEnable);
                        break;
                }

            }

        }

        public static void AssignValue(Control ctl, Dictionary<string, object> data)
        {

            foreach (var row in data)
            {
                foreach (Control item in ctl.Controls)
                {
                    string strName = item.Name.ToString().Trim().ToLower().Substring(0, 3);
                    switch (strName)
                    {
                        case "txt":
                            TextBox txt = (TextBox)item;

                            if (txt.Name.Substring(3).Trim() == row.Key)
                            {
                                txt.Text = row.Value.ToString();
                            }

                            break;
                        case "lbl":

                            Label lbl = (Label)item;

                            if (lbl.Name.Substring(3).Trim() == row.Key)
                            {
                                lbl.Text = row.Value.ToString();
                            }

                            break;
                        case "num":
                            NumericUpDown num = (NumericUpDown)item;
                            if (num.Name.Substring(3).Trim() == row.Key)
                            {
                                num.Value = decimal.Parse(row.Value.ToString());
                            }
                            break;

                        case "cmb":
                            ComboBox cmb = (ComboBox)item;
                            if (cmb.Name.Substring(3).Trim() == row.Key)
                            {
                                cmb.SelectedValue = row.Value;
                            }
                            break;

                        case "chk":
                            CheckBox chk = (CheckBox)item;

                            if (chk.Name.Substring(3).Trim() == row.Key)
                            {
                                if (row.Value.ToString() == "0")
                                {
                                    chk.Checked = false;
                                }
                                else
                                {
                                    chk.Checked = true; // Or set to a default value
                                }
                            }

                            break;

                        case "dtp":
                            DateTimePicker dtp = (DateTimePicker)item;
                            if (dtp.Name.Substring(3).Trim() == row.Key)
                            {
                                if (row.Value.ToString() != "")
                                {
                                    dtp.Value = DateTime.Parse(row.Value.ToString());
                                    dtp.Checked = true;
                                }
                                else
                                {
                                    dtp.Checked = false;
                                }

                            }


                            break;
                        case "tab":
                            TabControl tab = (TabControl)item;
                            AssignValue(tab, data);
                            break;
                        case "tbp":
                            TabPage tbp = (TabPage)item;
                            AssignValue(tbp, data);
                            break;

                        case "pnl":
                            Panel pnl = (Panel)item;
                            AssignValue(pnl, data);
                            break;


                    }
                }



            }
        }

        public static void ClearValue(Control ctl)
        {


            foreach (Control item in ctl.Controls)
            {
                string strName = item.Name.ToString().Trim().ToLower().Substring(0, 3);
                switch (strName)
                {
                    case "txt":
                        TextBox txt = (TextBox)item;
                        txt.Text = "";

                        break;
                    case "lbl":

                        Label lbl = (Label)item;
                        lbl.Text = "";

                        break;
                    case "num":
                        NumericUpDown num = (NumericUpDown)item;
                        num.Value = 0;

                        break;
                    case "cmb":
                        ComboBox cmb = (ComboBox)item;

                        if (cmb.Tag == null || cmb.Tag.ToString() != "EnterHooked")
                        {
                            cmb.Enter += new EventHandler(cmbAutoDropdown_Enter);
                            cmb.Tag = "EnterHooked"; // flag it as already hooked
                        }
                        cmb.SelectedValue = -1;
                        break;

                    case "chk":
                        CheckBox chk = (CheckBox)item;
                        chk.Checked = false;
                        break;

                    case "dtp":
                        DateTimePicker dtp = (DateTimePicker)item;

                        if (dtp.ShowCheckBox)
                        {
                            dtp.Value = clsDateTime.GetDefault();
                            dtp.Checked = false;
                        }
                        else
                        {
                            dtp.Value = clsDateTime.NowDay();
                        }

                     
                        break;
                    case "tab":
                        TabControl tab = (TabControl)item;
                        ClearValue(tab);
                        break;
                    case "tbp":
                        TabPage tbp = (TabPage)item;
                        ClearValue(tbp);
                        break;

                    case "pnl":
                        Panel pnl = (Panel)item;
                        ClearValue(pnl);
                        break;


                }

            }
        }


        private static void cmbAutoDropdown_Enter(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            cmb.DroppedDown = true;
        }
    }
}
