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
            clsTopHeaderControl.Inactive(tsHeaderControl);
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            clsTopHeaderControl.Active(tsHeaderControl);
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsTopHeaderControl.Inactive(tsHeaderControl);
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            clsTopHeaderControl.Inactive(tsHeaderControl);
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            clsTopHeaderControl.Active(tsHeaderControl);
        }
    }
}
