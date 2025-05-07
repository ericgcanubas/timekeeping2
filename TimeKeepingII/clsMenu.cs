using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsMenu
    {
        public static MdiTabControl.TabControl myTab;

        public static Form callForm(string formName)
        {
            Type formType = Type.GetType("TimeKeepingII." + formName);

            if (formType != null && formType.IsSubclassOf(typeof(Form)))
            {
                Form frm = (Form)Activator.CreateInstance(formType);
                return frm;
            }
            else
            {
                MessageBox.Show("Module not found.");
                return null;
            }
        }
        public static void OpenForm(object sender, EventArgs e)
        {
            LinkLabel btn = sender as LinkLabel;
            Form frm = callForm(btn.AccessibleDescription);
            if (frm != null)
            {
                int i = 0;
                foreach (MdiTabControl.TabPage tp in myTab.TabPages)
                {
                    Form tabForm = new Form();
                    tabForm = (Form)tp.Form;

                    if (frm.Name == tabForm.Name)
                    {
                        tabForm.Activate();
                        myTab.TabPages[i].Select();
                        return;
                    }
                    i++;
                }

            
                if (clsAccessControl.AccessRight(frm.AccessibleDescription, "OPEN"))
                {

                    myTab.TabPages.Add(frm);
                }
                else
                {
                    MessageBox.Show("INSUFICIENT RIGHTS TO PERFORM THIS OPERATION.", "ACCESS DENIED! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

        }
        private static void onClickSubMenu(object sender, EventArgs e)
        {

            Label lbl = sender as Label;
            if (lbl != null)
            {

                Form frm = lbl.FindForm();
                // Find the panel named "pnlSubMenuEmployeeSetup"
                if (frm != null)
                {
                    Control[] foundControls = frm.Controls.Find(lbl.AccessibleDescription, true); // true = search all children
                    if (foundControls.Length > 0)
                    {
                        Panel pnl = foundControls[0] as Panel;

                        if (pnl != null)
                        {
                            if (pnl.Visible == true)
                            {
                                pnl.Visible = false;
                            }
                            else
                            {
                                pnl.Visible = true;
                            }
                        }
                    }
                }
                return;
            }
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {

                Form frm = pic.FindForm();
                // Find the panel named "pnlSubMenuEmployeeSetup"
                if (frm != null)
                {
                    Control[] foundControls = frm.Controls.Find(pic.AccessibleDescription, true); // true = search all children
                    if (foundControls.Length > 0)
                    {
                        Panel pnl = foundControls[0] as Panel;


                        if (pnl.Visible == true)
                        {
                            pnl.Visible = false;
                        }
                        else
                        {
                            pnl.Visible = true;
                        }
                    }
                }

                return;
            }

        }

        public static void buildPrimaryMenu(FlowLayoutPanel mainPanel, MdiTabControl.TabControl tab)
        {

            myTab = tab;
            mainPanel.Controls.Clear();

            // Employee Setup
            Panel pnlEmployee = buildPanel("pnlEmployeeSetup");
            PictureBox picEmployee = buildPicture("picEmployeeSetup", "pnlSubMenuEmployeeSetup");
            Label lblEmployee = buildLabelClick("btnEmployeeSetup", "Employee Setup && Management", "pnlSubMenuEmployeeSetup");
            picEmployee.Image = Properties.Resources.employee;

            pnlEmployee.Controls.Add(picEmployee);
            pnlEmployee.Controls.Add(lblEmployee);
            mainPanel.Controls.Add(pnlEmployee);

            picEmployee.Click += new EventHandler(onClickSubMenu);
            lblEmployee.Click += new EventHandler(onClickSubMenu);

            Panel pnlSubMenuEmployee = CreateSubMenuPanel("pnlSubMenuEmployeeSetup", 100);
            mainPanel.Controls.Add(pnlSubMenuEmployee);
            //pnlSubMenuEmployee.Controls.Add(CreateSubMenuButton("btnEnableDisable", "To Enable / Disable Employee", "FrmEnableDisable"));

            pnlSubMenuEmployee.Controls.Add(CreateSubMenuButton("btnShiftingSchedule", "Shifting Schedule", "FrmShiftingSchedule"));
            pnlSubMenuEmployee.Controls.Add(CreateSubMenuButton("btnAssignBioID", "Assign Bio Id", "FrmAssignBioID"));
            pnlSubMenuEmployee.Controls.Add(CreateSubMenuButton("btnAssignSchedule", "Assign Schedule", "FrmAssignSchedule"));



            //Data Synchronization
            Panel pnlDataSync = buildPanel("pnlDataSync");
            PictureBox picDataSync = buildPicture("picDataSync", "pnlSubMenuDataSync");
            Label lblDataSync = buildLabelClick("lblDataSync", "Data Synchronization", "pnlSubMenuDataSync");
            picDataSync.Image = Properties.Resources.data_sync;

            pnlDataSync.Controls.Add(picDataSync);
            pnlDataSync.Controls.Add(lblDataSync);
            mainPanel.Controls.Add(pnlDataSync);
            picDataSync.Click += new EventHandler(onClickSubMenu);
            lblDataSync.Click += new EventHandler(onClickSubMenu);

            Panel pnlSubMenuDataSync = CreateSubMenuPanel("pnlSubMenuDataSync", 70);
            mainPanel.Controls.Add(pnlSubMenuDataSync);
            pnlSubMenuDataSync.Controls.Add(CreateSubMenuButton("btnDownloadFromMachine", "Download Data From Machine", "FrmDownloadDataFromMachine"));
            pnlSubMenuDataSync.Controls.Add(CreateSubMenuButton("btnRepostTimeRecord", "Repost Time Record", "FrmRepostTimeRecord"));



        
            // Schedule Shift Adjust
            Panel pnlScheduleShiftAdjust = buildPanel("pnlScheduleShiftAdjust");
            PictureBox picScheduleShiftAdjust = buildPicture("picScheduleShiftAdjust", "pnlSubMenuScheduleShiftAdjust");
            picScheduleShiftAdjust.Image = Properties.Resources.schedule;
            Label lblScheduleShiftAdjust = buildLabelClick("lblScheduleShiftAdjust", "Schedule && Shift Adjustments", "pnlSubMenuScheduleShiftAdjust");


            pnlScheduleShiftAdjust.Controls.Add(picScheduleShiftAdjust);
            pnlScheduleShiftAdjust.Controls.Add(lblScheduleShiftAdjust);
            mainPanel.Controls.Add(pnlScheduleShiftAdjust);
            picScheduleShiftAdjust.Click += new EventHandler(onClickSubMenu);
            lblScheduleShiftAdjust.Click += new EventHandler(onClickSubMenu);

            Panel pnlSubMenuScheduleShiftAdjust = CreateSubMenuPanel("pnlSubMenuScheduleShiftAdjust", 70);
            mainPanel.Controls.Add(pnlSubMenuScheduleShiftAdjust);
            //pnlSubMenuScheduleShiftAdjust.Controls.Add(CreateSubMenuButton("btnGuard", "Guard", "FrmGuard"));
            //pnlSubMenuScheduleShiftAdjust.Controls.Add(CreateSubMenuButton("btnOvertime", "Overtime", "FrmOvertime"));
            //pnlSubMenuScheduleShiftAdjust.Controls.Add(CreateSubMenuButton("btnChangeDayOff", "Change Day Off", "FrmChangeDayoff"));
            pnlSubMenuScheduleShiftAdjust.Controls.Add(CreateSubMenuButton("btnChangeDayOff", "Change Day Off", "FrmChangeDayoff"));
            pnlSubMenuScheduleShiftAdjust.Controls.Add(CreateSubMenuButton("btnChangeShifting", "Change Shifting", "FrmChangeShifting"));


            //Attendance Management

            Panel pnlAttendanceManagement = buildPanel("pnlAttendanceManagement");
            PictureBox piclAttendanceManagement = buildPicture("picAttendanceManagement", "pnlSubMenuAttendanceManagement");
            piclAttendanceManagement.Image = Properties.Resources.attendances;
            Label lblAttendanceManagement = buildLabelClick("lblAttendanceManagement", "Attendance Management", "pnlSubMenuAttendanceManagement");


            pnlAttendanceManagement.Controls.Add(piclAttendanceManagement);
            pnlAttendanceManagement.Controls.Add(lblAttendanceManagement);
            mainPanel.Controls.Add(pnlAttendanceManagement);
            piclAttendanceManagement.Click += new EventHandler(onClickSubMenu);
            lblAttendanceManagement.Click += new EventHandler(onClickSubMenu);


            Panel pnlSubMenuAttendanceManagement = CreateSubMenuPanel("pnlSubMenuAttendanceManagement", 70);
            mainPanel.Controls.Add(pnlSubMenuAttendanceManagement);
            //pnlSubMenuAttendanceManagement.Controls.Add(CreateSubMenuButton("btnTravelDuty", "Travel Duty", "FrmTravelDuty"));
            //pnlSubMenuAttendanceManagement.Controls.Add(CreateSubMenuButton("btnTimeAdjustment", "Time Adjustment", "FrmTimeAdjustment"));
            pnlSubMenuAttendanceManagement.Controls.Add(CreateSubMenuButton("btnPermisionToReport", "Permission To Report for Work", "FrmPRW"));
            pnlSubMenuAttendanceManagement.Controls.Add(CreateSubMenuButton("btnLeaveUndertime", "Leave/Undertime", "FrmLeaveUndertime"));
            //pnlSubMenuAttendanceManagement.Controls.Add(CreateSubMenuButton("btnUndertime", "Undertime", "FrmUndertime"));

            //Clearing and Validation
            Panel pnlClearingValidation = buildPanel("pnlClearingValidation");
            PictureBox picClearingValidation = buildPicture("picClearingValidation", "pnlSubMenuClearingValidation");
            picClearingValidation.Image = Properties.Resources.clear_validation;
            Label lblClearingValidation = buildLabelClick("lblClearingValidation", "Clearing && Validation", "pnlSubMenuClearingValidation");


            pnlClearingValidation.Controls.Add(picClearingValidation);
            pnlClearingValidation.Controls.Add(lblClearingValidation);
            mainPanel.Controls.Add(pnlClearingValidation);
            picClearingValidation.Click += new EventHandler(onClickSubMenu);
            lblClearingValidation.Click += new EventHandler(onClickSubMenu);

            Panel pnlSubMenuClearingValidation = CreateSubMenuPanel("pnlSubMenuClearingValidation", 70);
            mainPanel.Controls.Add(pnlSubMenuClearingValidation);
            pnlSubMenuClearingValidation.Controls.Add(CreateSubMenuButton("btnClearning", "Clearing", "FrmClearing"));
            pnlSubMenuClearingValidation.Controls.Add(CreateSubMenuButton("btnClearingNew", "Clearing New", "FrmClearingNew"));



            //Time Record Handling

            Panel pnlTimeRecordHandling = buildPanel("pnlTimeRecordHandling");
            PictureBox picTimeRecordHandling = buildPicture("picTimeRecordHandling", "pnlSubMenuTimeRecordHandling");
            picTimeRecordHandling.Image = Properties.Resources.time_record_handling;
            Label lblTimeRecordHandling = buildLabelClick("lblTimeRecordHandling", "Time Record Handling", "pnlSubMenuTimeRecordHandling");

            pnlTimeRecordHandling.Controls.Add(picTimeRecordHandling);
            pnlTimeRecordHandling.Controls.Add(lblTimeRecordHandling);
            mainPanel.Controls.Add(pnlTimeRecordHandling);
            picTimeRecordHandling.Click += new EventHandler(onClickSubMenu);
            lblTimeRecordHandling.Click += new EventHandler(onClickSubMenu);



            Panel pnlSubMenuTimeRecordHandling = CreateSubMenuPanel("pnlSubMenuTimeRecordHandling", 120);
            mainPanel.Controls.Add(pnlSubMenuTimeRecordHandling);
            pnlSubMenuTimeRecordHandling.Controls.Add(CreateSubMenuButton("btnCheckUnupdatedTimeSummary", "Check Unupdated Time Summary", "FrmCheckUnupdatedTimeSummary"));
            pnlSubMenuTimeRecordHandling.Controls.Add(CreateSubMenuButton("btnUpdateTimeSummary", "Update Time Summary", "FrmUpdateTimeSummary"));
            pnlSubMenuTimeRecordHandling.Controls.Add(CreateSubMenuButton("btnTimeCharger", "Time Charger", "FrmTimeCharger"));
            pnlSubMenuTimeRecordHandling.Controls.Add(CreateSubMenuButton("btnTimeRecord", "Time Record", "FrmTimeRecord"));



            // Deductions && Adjustments

            Panel pnlDeductions = buildPanel("pnlDeductions");
            PictureBox picDeductions = buildPicture("picDeductions", "pnlSubMenuDeductions");
            picDeductions.Image = Properties.Resources.deductionAdjustment;
            Label lblDeductions = buildLabelClick("lblDeductions", "Deductions && Adjustments", "pnlSubMenuDeductions");

            pnlDeductions.Controls.Add(picDeductions);
            pnlDeductions.Controls.Add(lblDeductions);
            mainPanel.Controls.Add(pnlDeductions);
            picDeductions.Click += new EventHandler(onClickSubMenu);
            lblDeductions.Click += new EventHandler(onClickSubMenu);



            Panel pnlSubMenuDeductions = CreateSubMenuPanel("pnlSubMenuDeductions", 70);
            mainPanel.Controls.Add(pnlSubMenuDeductions);
            pnlSubMenuDeductions.Controls.Add(CreateSubMenuButton("btnGenerateDeductionsForAbsences", "Generate Deductions for Absences", "FrmGenerate"));
            pnlSubMenuDeductions.Controls.Add(CreateSubMenuButton("btnAdjustmentOfTimeSummary", "Adjustment Of Time Summary(for Monthly Only)", "FrmClearingNew"));



            // Summaries & Reports
            Panel pnlSummaryReports = buildPanel("pnlSummaryReports");
            PictureBox picSummaryReports = buildPicture("picSummaryReports", "pnlSubMenuSummaryReports");
            picSummaryReports.Image = Properties.Resources.summary_reports;
            Label lblSummaryReports = buildLabelClick("lblSummaryReports", "Summaries & Reports", "pnlSubMenuSummaryReports");

            pnlSummaryReports.Controls.Add(picSummaryReports);
            pnlSummaryReports.Controls.Add(lblSummaryReports);
            mainPanel.Controls.Add(pnlSummaryReports);
            picSummaryReports.Click += new EventHandler(onClickSubMenu);
            lblSummaryReports.Click += new EventHandler(onClickSubMenu);


        }

        private static Panel buildPanel(string Name)
        {
            Panel pnl = new Panel();
            pnl.Name = Name;
            pnl.Dock = DockStyle.Top;
            pnl.Size = new System.Drawing.Size(274, 40);

            return pnl;
        }


        private static PictureBox buildPicture(string Name, string SubName)
        {
            PictureBox pic = new PictureBox();
            pic.Name = Name;
            pic.AccessibleDescription = SubName;
            pic.Dock = DockStyle.Left;
            pic.Size = new System.Drawing.Size(40, 40);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Cursor = Cursors.Hand;
            pic.MouseHover += new EventHandler(Pic_MouseHover);

            pic.MouseLeave += new EventHandler(Pic_MouseLeave);
            return pic;
        }

        private static void Pic_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {

                Control current = pic.Parent;
                while (current != null && !(current is Panel))
                {
                    current = current.Parent;

                }

                Panel pnlMain = current as Panel;

                if (pnlMain != null)
                {
                    // Now you can access pnlMain
                    pnlMain.BackColor = System.Drawing.Color.LightGray;
                }

            }

        }

        private static void Pic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {

                Control current = pic.Parent;
                while (current != null && !(current is Panel))
                {
                    current = current.Parent;

                }

                Panel pnlMain = current as Panel;

                if (pnlMain != null)
                {
                    // Now you can access pnlMain
                    pnlMain.BackColor = System.Drawing.Color.Transparent;
                }

            }

        }


        private static Label buildLabelClick(string Name, string Caption, string SubName)
        {
            Label lbl = new Label();
            lbl.AccessibleDescription = SubName;
            lbl.Name = Name;
            lbl.Dock = DockStyle.Right;
            lbl.Text = Caption;
            lbl.Cursor = Cursors.Hand;
            lbl.ForeColor = System.Drawing.Color.White;
            lbl.Size = new System.Drawing.Size(225, 40);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lbl.MouseHover += new EventHandler(Lbl_MouseHover);
            
            lbl.MouseLeave += new EventHandler(Lbl_MouseLeave);
            return lbl;
        }

        private static void Lbl_MouseHover(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {

                Control current = lbl.Parent;
                while (current != null && !(current is Panel))
                {
                    current = current.Parent;

                }

                Panel pnlMain = current as Panel;

                if (pnlMain != null)
                {
                    // Now you can access pnlMain
                    pnlMain.BackColor = System.Drawing.Color.LightGray;
                }

            }

        }

        private static void Lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {

                Control current = lbl.Parent;
                while (current != null && !(current is Panel))
                {
                    current = current.Parent;

                }

                Panel pnlMain = current as Panel;

                if (pnlMain != null)
                {
                    // Now you can access pnlMain
                    pnlMain.BackColor = System.Drawing.Color.Transparent;
                }

            }

        }

        private static Panel CreateSubMenuPanel(string Name, int myHeight)
        {
            Panel pnl = new Panel();
            pnl.Name = Name;
            pnl.Dock = DockStyle.Top;
            pnl.Size = new System.Drawing.Size(271, myHeight);
            pnl.Visible = false;

            pnl.BackColor = System.Drawing.Color.MidnightBlue;
            return pnl;
        }
        private static Label CreateSubMenuButton(string Name, string Caption, string FormName)
        {


            LinkLabel btn = new LinkLabel();
            btn.AccessibleDescription = FormName;
            btn.Name = Name;
            btn.Dock = DockStyle.Top;
            btn.Text = "                 " + Caption;
            btn.Cursor = Cursors.Hand;
            btn.Size = new System.Drawing.Size(271, 30);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.LinkBehavior = LinkBehavior.NeverUnderline;
            //btn.FlatStyle = FlatStyle.Popup;
            //btn.UseVisualStyleBackColor = true;
            btn.BackColor = System.Drawing.Color.MidnightBlue;
            btn.ForeColor = System.Drawing.Color.White;
            btn.LinkColor = System.Drawing.Color.Yellow;
            btn.Click += new EventHandler(OpenForm);
            return btn;
        }


    }
}
