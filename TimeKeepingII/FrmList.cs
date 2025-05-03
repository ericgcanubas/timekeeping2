using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    public partial class FrmList : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        DataTable dataList;
        string titleHeader; 
        public string VALUE = "";
        public FrmList(DataTable dt, string title = "List")
        {
            InitializeComponent();
            this.dataList = dt;
            this.titleHeader = title;
        }

        private void FrmList_Load(object sender, EventArgs e)
        {
            lblHeaderTitle.Text = titleHeader;
            SearchLoad();
        }
        private void SearchLoad()
        {

            DataTable newData = dataList.Clone();

            foreach (DataRow data in dataList.Rows)
            {
                // Adjust column index or name according to your data
                if (data.ItemArray.Any(field => field.ToString().IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    newData.ImportRow(data);
                }
            }


            clsListView.LoadListView(lvList, newData);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchLoad();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            VALUE = "";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvList.Items.Count == 0)
            {

                clsMessage.MessageShowInfo("Record not found");

                return;
            }


            try
            {
                lvList.Select();

                VALUE = lvList.FocusedItem.Text;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
