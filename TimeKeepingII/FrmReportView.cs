using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeKeepingII
{
    public partial class FrmReportView : Form
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt;
        string title = string.Empty;    
        public FrmReportView( CrystalDecisions.CrystalReports.Engine.ReportDocument report, string Title )
        {
            InitializeComponent();
            rpt = report;
            title = Title;
        }

        private void FrmReportView_Load(object sender, EventArgs e)
        {
            this.Text = title;
            if (rpt != null)
            {
                crystalReportViewer1.ReportSource = rpt;

            }
        }
    }
}
