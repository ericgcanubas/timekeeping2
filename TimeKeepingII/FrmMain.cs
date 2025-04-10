﻿using System;
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

    public partial class FrmMain : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public bool burdger = true;
        public int menuSideDefaultActive = 280;
        public int menuSideDefaultInActive = 70;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Set the form border style to none if you want a clean fullscreen look
            // this.FormBorderStyle = FormBorderStyle.None;

            // Get the screen size
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            // Set location to top-left
            this.Location = new Point(screen.Left, screen.Top);

            // Set the form size to screen working area
            this.Size = new Size(screen.Width, screen.Height);
            pnlSideMenu.Size = new Size(menuSideDefaultInActive, pnlSideMenu.Size.Height); 


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int CurrentWidth = pnlSideMenu.Width;
            if ( burdger == true)
            {
              
              if(pnlSideMenu.Width < menuSideDefaultActive)
                {
                    pnlSideMenu.Size = new Size(CurrentWidth + 10, pnlSideMenu.Size.Height);
                    tsPrimary.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                }

          



            }
            else
            {
                if (pnlSideMenu.Width > menuSideDefaultInActive)
                {
                    pnlSideMenu.Size = new Size(CurrentWidth - 10, pnlSideMenu.Size.Height);
                    tsPrimary.LayoutStyle = ToolStripLayoutStyle.Table;
                }

            }
        }

        private void ptbMenuBurger_Click(object sender, EventArgs e)
        {
            burdger = burdger ? false : true;


            if(burdger)
            {
                ptbMenuBurger.Image = Properties.Resources.burger_bar;
            }
            else
            {
                ptbMenuBurger.Image = Properties.Resources.right_arrow;
            }

        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void assignScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssignSchedule frm = new FrmAssignSchedule();
            tabControl1.TabPages.Add(frm);
              
        }

        private void toEnableDisableEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public void MenuSubShow(bool emp, bool dataSyn, bool  sched, bool attendance )
        {
            pnlSubEmployeeSetup.Visible = emp;
            pnlSubDataSync.Visible = dataSyn;
            pnlSubSchedule.Visible = sched;
            pnlSubAttendanceManagement.Visible = attendance;
        }
        private void btnEmployeeSetup_Click(object sender, EventArgs e)
        {
            MenuSubShow(true, false, false, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuSubShow(false, true, false, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MenuSubShow(false, false, true, false);
        }

        private void btnAssignSchedule_Click(object sender, EventArgs e)
        {
            FrmAssignSchedule frm = new FrmAssignSchedule();
            tabControl1.TabPages.Add(frm);
        }

        private void btnAttendanceMgt_Click(object sender, EventArgs e)
        {

            MenuSubShow(false, false, false, true);
        }
    }
}
