using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsComponentControl
    {
        public static void InactiveHeaderMenu(ToolStrip tsControl)
        {

   

            foreach (ToolStripItem item in tsControl.Items)
            {
                if (item is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)item;

                    switch (btn.Text)
                    {
                        case "Add":
                            btn.Enabled = true;
                            break;

                        case "Edit":
                            btn.Enabled = true;
                            break;

                        case "Delete":
                            btn.Enabled = true;
                            break;

                        case "Save":
                            btn.Enabled = false;
                            break;

                        case "Undo":
                            btn.Enabled = false;
                            break;

                        case "Find":
                            btn.Enabled = true;
                            break;

                        case "Close":
                            btn.Enabled = true;
                            break;

                        default:
                            // do nothing
                            break;
                    }
                }




            }

        }
        public static void ActiveHeaderMenu(ToolStrip tsControl)
        {

         

            foreach (ToolStripItem item in tsControl.Items)
            {
                if (item is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)item;

                    switch (btn.Text)
                    {
                        case "Add":
                            btn.Enabled = false;
                            break;

                        case "Edit":
                            btn.Enabled = false;
                            break;

                        case "Delete":
                            btn.Enabled = false;
                            break;

                        case "Save":
                            btn.Enabled = true;
                            break;

                        case "Undo":
                            btn.Enabled = true;
                            break;

                        case "Find":
                            btn.Enabled = false;
                            break;

                        case "Close":
                            btn.Enabled = false;
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
                string strName = item.Name.ToString().Trim().ToLower().Substring(0,3);
                switch (strName)
                {
                    case "txt":
                        TextBox txt = (TextBox)item;
                        txt.ReadOnly = !isEnable;
                        break;

                    case "num":
                        NumericUpDown num = (NumericUpDown)item;
                        num.ReadOnly = !isEnable;
                        break;

                    case "cmb":
                        ComboBox cmb = (ComboBox)item;
                        cmb.Enabled = isEnable;
                        break;

                    case "chk":
                        CheckBox chk = (CheckBox)item;
                        chk.Enabled = isEnable;
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
    }
}
