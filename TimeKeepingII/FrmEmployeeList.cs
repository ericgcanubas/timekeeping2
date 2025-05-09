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
    public partial class FrmEmployeeList : Form
    {


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string titleHeader;
        public string VALUE = "";
        public FrmEmployeeList(string title = "Search Employees")
        {
            InitializeComponent();

            this.titleHeader = title;
        }

      
        private void SearchLoad()
        {

            DataTable dataList = clsPayrollSystem.dataList($@"SELECT Top 100 PK as ID, 
                        EEmployeeIDNo as [EMPLOYEE NO.], 
                        ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS NAME,
                        ELastName as LASTNAME
                        FROM tbl_Profile_IDNumber 
                        WHERE ( ELastName like '%{clsMisc.FormatSQL(txtSearch.Text)}%' OR EFirstName like '%{clsMisc.FormatSQL(txtSearch.Text)}%'  OR  EMiddleName like '%{clsMisc.FormatSQL(txtSearch.Text)}%' OR  EEmployeeIDNo like '%{clsMisc.FormatSQL(txtSearch.Text)}%' )  

                    ORDER BY ELastName + ',  ' + EFirstName + '  ' + EMiddleName, EEmployeeIDNo");

            clsListView.LoadListView(lvList, dataList);
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



        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ptbClose_Click_1(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchLoad();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchLoad();
            }
        }

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            lblHeaderTitle.Text = titleHeader;
            SearchLoad();
        }
    }
}
