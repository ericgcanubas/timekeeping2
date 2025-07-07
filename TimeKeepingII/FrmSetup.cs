using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    public partial class FrmSetup : Form
    {
        int checkCouning = 0;
        int stepNumber = 0;
        public FrmSetup()
        {
            InitializeComponent();
        }

        private void FrmSetup_Load(object sender, EventArgs e)
        {
            txtBIO_SERVER.Text = "DEVELOPER";
            txtPAYROLL_SERVER.Text = "DEVELOPER";

        }


        private bool isSetupProceed()
        {
            if (txtBIO_SERVER.Text.Length <= 3)
            {
                MessageBox.Show("Biometrics Server required", "System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (txtPAYROLL_SERVER.Text.Length <= 3)
            {
                MessageBox.Show("Payroll Server required", "System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            MakeDSN(clsBiometrics.DSN_BIO_SERVER, txtBIO_SERVER.Text, "Biometrics");
            MakeDSN(clsPayrollSystem.DSN_PAYROL_SERVER, txtPAYROLL_SERVER.Text, "PayrollSystem");


            return true;
        }


        private void ResetCheck()
        {
            chkBiometrics.Checked = false;
            chkPayroll.Checked = false;
            chkFinal.Checked = false;
            btnPrevious.Visible = false;
            btnNext.Visible = true;
            btnNext.Text = "&Next";
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (isSetupProceed() == true && this.stepNumber == 0)
            {
                this.stepNumber = 1;
                btnNext.Visible = false;
            }

            if (this.stepNumber == 2)
            {
                clsFile.makeConfig(txtBIO_SERVER.Text, txtPAYROLL_SERVER.Text);
                FrmMain frm = new FrmMain();
                frm.Show();
                this.Hide();
            }


        }
        private bool MakeDSN(string DSN, string SERVER_NAME, string DB_NAME)
        {

            try
            {
                string dsnName = DSN;  // Name of the DSN
                string server = SERVER_NAME;   // Change to your SQL Server
                string database = DB_NAME; // Change to your Database

                // DSN Registry Path (HKEY_CURRENT_USER for User DSN)
                string dsnRegistryPath = @"SOFTWARE\ODBC\ODBC.INI\" + dsnName;
                string odbcDriversPath = @"SOFTWARE\ODBC\ODBCINST.INI\ODBC Drivers";

                // ✅ Create DSN Key
                RegistryKey dsnKey = Registry.CurrentUser.CreateSubKey(dsnRegistryPath);
                if (dsnKey == null)
                {
                    MessageBox.Show("Failed to create DSN registry key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                dsnKey.SetValue("Driver", "SQLSRV32.DLL");  // ODBC SQL Server Driver
                dsnKey.SetValue("Server", server);
                dsnKey.SetValue("Database", database);
                dsnKey.SetValue("UID", "sa");  // Replace with actual username
                dsnKey.SetValue("PWD", "");  // Replace with actual password
                dsnKey.SetValue("Trusted_Connection", "No"); /// Use Windows Authentication
                dsnKey.Close();

                // ✅ Ensure "ODBC Drivers" key exists
                RegistryKey odbcKey = Registry.CurrentUser.OpenSubKey(odbcDriversPath, true);
                if (odbcKey == null)
                {
                    odbcKey = Registry.CurrentUser.CreateSubKey(odbcDriversPath);
                }

                odbcKey.SetValue(dsnName, "Installed");
                odbcKey.Close();

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.stepNumber == 0)
            {


                lblConnectionSetup.ForeColor = Color.Yellow;
                lblConnectionCheck.ForeColor = Color.White;
                lblFinalSetup.ForeColor = Color.White;


                pnlSetup.Visible = true;
                pnlTest.Visible = false;
                pnlSetupComplete.Visible = false;
                checkCouning = 0;
            }

            if (this.stepNumber == 1)
            {

                checkCouning++;
                lblConnectionSetup.ForeColor = Color.White;
                lblConnectionCheck.ForeColor = Color.Yellow;
                lblFinalSetup.ForeColor = Color.White;

                pnlSetup.Visible = false;
                pnlTest.Visible = true;
                pnlSetupComplete.Visible = false;


                Application.DoEvents();

                if (chkBiometrics.Checked == false)
                {
                    chkBiometrics.Checked = clsBiometrics.ConnectionTest();
                }
                else
                {
                    if (chkBiometrics.Checked == true && chkPayroll.Checked == false)
                    {
                        chkPayroll.Checked = clsPayrollSystem.ConnectionTest();
                    }
                    else
                    {
                        if (chkBiometrics.Checked == true && chkPayroll.Checked == true)
                        {
                            if (chkFinal.Checked == true)
                            {

                                this.stepNumber = 2;
                            }
                            else
                            {
                                chkFinal.Checked = true;

                            }

                        }
                        else
                        {

                        }
                    }
                }




                if (checkCouning == 5)
                {

                    ResetCheck();
                    this.stepNumber = 0;

                }
            }

            if (this.stepNumber == 2)
            {
                checkCouning = 0;

                lblConnectionSetup.ForeColor = Color.White;
                lblConnectionCheck.ForeColor = Color.White;
                lblFinalSetup.ForeColor = Color.Yellow;

                pnlSetup.Visible = false;
                pnlTest.Visible = false;
                pnlSetupComplete.Visible = true;


                btnNext.Text = "&Finish";
                btnNext.Visible = true;
                btnPrevious.Visible = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (lblFinalSetup.Visible == true)
            {
                // to save

                ResetCheck();
                this.stepNumber = 0;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
