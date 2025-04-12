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

    public partial class FrmLogin : Form
    {

        public int userId = 0;
        public bool isLogin = false;


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            lblUsername.Text = "";

            LoadUser();
            selectListUser();


            var config = clsFile.getDirectory();
            lblUsername.Text = config["savelogin"].ToString();
            if (lblUsername.Text.Length > 0)
            {
                var item = lstUser.FindItemWithText(lblUsername.Text);
                if (item.Text.Length > 0)
                {
                    tabControl1.SelectTab(1);
                    txtPassword.SelectAll();
                }
            }

        }
        private void LoadUser()
        {


            lstUser.Items.Clear();
            DataTable dt = clsPayrollSystem.dataList("SELECT UserName From [UserAccount_New] ORDER BY UserName");
            foreach (DataRow item in dt.Rows)
            {
                int Imgky = 0;
              
                lstUser.Items.Add(item["UserName"].ToString(), Imgky);

            }
        }
        private void selectListUser()
        {
            lblUsername.Text = "";
            txtPassword.Clear();
            if (lstUser.Items.Count > 0)
            {
                lstUser.Select();

            }
            tabControl1.SelectTab(0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string entryPassword = clsMisc.Encrypt(clsMisc.FormatSQL(txtPassword.Text.Trim()));
            var dt = clsPayrollSystem.GetFirstRecord($@"SELECT UserAccount_New.* From UserAccount_New WHERE UserName = '{lblUsername.Text}'  AND Password = '{entryPassword}' ");
            if (dt != null)
            {
                userId = (int)dt["PK"];
                clsFile.UpdateIniFile("[users]", "savelogin", lblUsername.Text);
                isLogin = true;
                clsAccessControl.gsUsername = lblUsername.Text;
                clsAccessControl.gsPassword = entryPassword;
                Close();
            }
            else
            {
                txtPassword.SelectAll();
                MessageBox.Show("Invalid username or password", "System message");
            }
        }

        private void lstUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectUser();
            }
        }
        private void selectUser()
        {
            if (lstUser.Items.Count > 0)
            {
                lstUser.Select();
                lblUsername.Text = lstUser.FocusedItem.Text;
            }

            if (lblUsername.Text.Length > 0)
            {
                tabControl1.SelectTab(1);
                txtPassword.SelectAll();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            selectListUser();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keys.Back == e.KeyCode)
            {
                if (txtPassword.Text.Length == 0)
                {
                    selectListUser();
                }

            }

            if (Keys.Enter == e.KeyCode)
            {
                btnLogin.PerformClick();
            }
        }

        private void lstUser_DoubleClick(object sender, EventArgs e)
        {
            selectUser();
        }
    }
}
