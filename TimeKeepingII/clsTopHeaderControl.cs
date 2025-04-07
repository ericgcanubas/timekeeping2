using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsTopHeaderControl
    {
        public static void Inactive(ToolStrip tsControl)
        {

            List<ToolStripButton> buttons = new List<ToolStripButton>();

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
        public static void Active(ToolStrip tsControl)
        {

            List<ToolStripButton> buttons = new List<ToolStripButton>();

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
    }
}
