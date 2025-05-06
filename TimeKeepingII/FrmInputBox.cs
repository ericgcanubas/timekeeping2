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
    public partial class FrmInputBox : Form
    {


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private string Title;
        private string Header;
        public bool isYes = false;
        public string InpuText;
        public FrmInputBox(string _Header, string _Title = "Input")
        {
            InitializeComponent();
            this.Title = _Title;
            this.Header = _Header;
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FrmInputBox_Load(object sender, EventArgs e)
        {
            lblTitle.Text = this.Title;
            lblHeader.Text = this.Header;
            InpuText = "";
            isYes = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isYes = false;
            InpuText = "";

            this.Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rtbInput.Text.Length == 0)
            {
                clsMessage.MessageShowInfo("Please fill-up message");
                return;
            }

            InpuText = rtbInput.Text;
            isYes = true;
            this.Close();
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }

        private void lblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
