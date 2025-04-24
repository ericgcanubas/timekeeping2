namespace TimeKeepingII
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptbMinimize = new System.Windows.Forms.PictureBox();
            this.ptbClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbMenuBurger = new System.Windows.Forms.PictureBox();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tsPrimary = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.assignBiometricsIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toEnableDisableEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.downloadDataFromMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repostTimeRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeShiftingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDayOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overtimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overtimeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.undertimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveOfAbsentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissionToReportForWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAdjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelDutyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearingNEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripDropDownButton();
            this.timeRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeChangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTimeSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUnupdatedTimeSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.generateDeductionsForAbsencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripDropDownButton();
            this.monthlyDailyTimeSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyTimeSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerialTimeSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenuBurger)).BeginInit();
            this.pnlSideMenu.SuspendLayout();
            this.tsPrimary.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.ptbMinimize);
            this.pnlHeader.Controls.Add(this.ptbClose);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.ptbMenuBurger);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1242, 42);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = global::TimeKeepingII.Properties.Resources.time_icon;
            this.pictureBox1.Location = new System.Drawing.Point(76, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ptbMinimize
            // 
            this.ptbMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMinimize.BackColor = System.Drawing.SystemColors.Highlight;
            this.ptbMinimize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbMinimize.Image = global::TimeKeepingII.Properties.Resources.minimized_icon;
            this.ptbMinimize.Location = new System.Drawing.Point(1157, 1);
            this.ptbMinimize.Name = "ptbMinimize";
            this.ptbMinimize.Size = new System.Drawing.Size(40, 40);
            this.ptbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMinimize.TabIndex = 3;
            this.ptbMinimize.TabStop = false;
            this.ptbMinimize.Click += new System.EventHandler(this.ptbMinimize_Click);
            // 
            // ptbClose
            // 
            this.ptbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.ptbClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbClose.Image = global::TimeKeepingII.Properties.Resources.x_mark;
            this.ptbClose.Location = new System.Drawing.Point(1200, 1);
            this.ptbClose.Name = "ptbClose";
            this.ptbClose.Size = new System.Drawing.Size(40, 40);
            this.ptbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbClose.TabIndex = 2;
            this.ptbClose.TabStop = false;
            this.ptbClose.Click += new System.EventHandler(this.ptbClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(119, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Keeping II";
            // 
            // ptbMenuBurger
            // 
            this.ptbMenuBurger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbMenuBurger.Image = global::TimeKeepingII.Properties.Resources.burger_bar;
            this.ptbMenuBurger.Location = new System.Drawing.Point(1, -1);
            this.ptbMenuBurger.Name = "ptbMenuBurger";
            this.ptbMenuBurger.Size = new System.Drawing.Size(58, 40);
            this.ptbMenuBurger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMenuBurger.TabIndex = 0;
            this.ptbMenuBurger.TabStop = false;
            this.ptbMenuBurger.Click += new System.EventHandler(this.ptbMenuBurger_Click);
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.Controls.Add(this.flowLayoutPanel1);
            this.pnlSideMenu.Controls.Add(this.tsPrimary);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 42);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(280, 558);
            this.pnlSideMenu.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 558);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tsPrimary
            // 
            this.tsPrimary.BackColor = System.Drawing.Color.Transparent;
            this.tsPrimary.CanOverflow = false;
            this.tsPrimary.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrimary.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.tsPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton7,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripButton8});
            this.tsPrimary.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsPrimary.Location = new System.Drawing.Point(0, 0);
            this.tsPrimary.Name = "tsPrimary";
            this.tsPrimary.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrimary.Size = new System.Drawing.Size(280, 397);
            this.tsPrimary.TabIndex = 0;
            this.tsPrimary.Text = "toolStrip1";
            this.tsPrimary.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignBiometricsIDToolStripMenuItem,
            this.assignScheduleToolStripMenuItem,
            this.toEnableDisableEmployeeToolStripMenuItem});
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = global::TimeKeepingII.Properties.Resources.employee;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton1.Text = "Employee Setup && Management";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // assignBiometricsIDToolStripMenuItem
            // 
            this.assignBiometricsIDToolStripMenuItem.Name = "assignBiometricsIDToolStripMenuItem";
            this.assignBiometricsIDToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.assignBiometricsIDToolStripMenuItem.Text = "Assign Biometrics ID";
            // 
            // assignScheduleToolStripMenuItem
            // 
            this.assignScheduleToolStripMenuItem.Name = "assignScheduleToolStripMenuItem";
            this.assignScheduleToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.assignScheduleToolStripMenuItem.Text = "Assign Schedule";
            this.assignScheduleToolStripMenuItem.Click += new System.EventHandler(this.assignScheduleToolStripMenuItem_Click);
            // 
            // toEnableDisableEmployeeToolStripMenuItem
            // 
            this.toEnableDisableEmployeeToolStripMenuItem.Name = "toEnableDisableEmployeeToolStripMenuItem";
            this.toEnableDisableEmployeeToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toEnableDisableEmployeeToolStripMenuItem.Text = "To Enable / Disable Employee";
            this.toEnableDisableEmployeeToolStripMenuItem.Click += new System.EventHandler(this.toEnableDisableEmployeeToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadDataFromMachineToolStripMenuItem,
            this.repostTimeRecordToolStripMenuItem});
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Image = global::TimeKeepingII.Properties.Resources.data_sync;
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton4.Text = "Data Synchronization";
            this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // downloadDataFromMachineToolStripMenuItem
            // 
            this.downloadDataFromMachineToolStripMenuItem.Name = "downloadDataFromMachineToolStripMenuItem";
            this.downloadDataFromMachineToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.downloadDataFromMachineToolStripMenuItem.Text = "Download Data From Machine";
            // 
            // repostTimeRecordToolStripMenuItem
            // 
            this.repostTimeRecordToolStripMenuItem.Name = "repostTimeRecordToolStripMenuItem";
            this.repostTimeRecordToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.repostTimeRecordToolStripMenuItem.Text = "Repost Time Record";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeShiftingToolStripMenuItem,
            this.changeDayOffToolStripMenuItem,
            this.overtimeToolStripMenuItem,
            this.guardToolStripMenuItem});
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Image = global::TimeKeepingII.Properties.Resources.schedule;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton3.Text = "Schedule && Shift Adjustments";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // changeShiftingToolStripMenuItem
            // 
            this.changeShiftingToolStripMenuItem.Name = "changeShiftingToolStripMenuItem";
            this.changeShiftingToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.changeShiftingToolStripMenuItem.Text = "Change Shifting";
            // 
            // changeDayOffToolStripMenuItem
            // 
            this.changeDayOffToolStripMenuItem.Name = "changeDayOffToolStripMenuItem";
            this.changeDayOffToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.changeDayOffToolStripMenuItem.Text = "Change Day Off";
            // 
            // overtimeToolStripMenuItem
            // 
            this.overtimeToolStripMenuItem.Name = "overtimeToolStripMenuItem";
            this.overtimeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.overtimeToolStripMenuItem.Text = " ";
            // 
            // guardToolStripMenuItem
            // 
            this.guardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overtimeToolStripMenuItem1,
            this.backupToolStripMenuItem});
            this.guardToolStripMenuItem.Name = "guardToolStripMenuItem";
            this.guardToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.guardToolStripMenuItem.Text = "Guard";
            // 
            // overtimeToolStripMenuItem1
            // 
            this.overtimeToolStripMenuItem1.Name = "overtimeToolStripMenuItem1";
            this.overtimeToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.overtimeToolStripMenuItem1.Text = "Overtime";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undertimeToolStripMenuItem,
            this.leaveOfAbsentToolStripMenuItem,
            this.suspensionToolStripMenuItem,
            this.permissionToReportForWorkToolStripMenuItem,
            this.timeAdjustmentToolStripMenuItem,
            this.travelDutyToolStripMenuItem});
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = global::TimeKeepingII.Properties.Resources.attendances;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton2.Text = "Attendance Management";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // undertimeToolStripMenuItem
            // 
            this.undertimeToolStripMenuItem.Name = "undertimeToolStripMenuItem";
            this.undertimeToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.undertimeToolStripMenuItem.Text = "Undertime";
            // 
            // leaveOfAbsentToolStripMenuItem
            // 
            this.leaveOfAbsentToolStripMenuItem.Name = "leaveOfAbsentToolStripMenuItem";
            this.leaveOfAbsentToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.leaveOfAbsentToolStripMenuItem.Text = "Leave of Absent";
            // 
            // suspensionToolStripMenuItem
            // 
            this.suspensionToolStripMenuItem.Name = "suspensionToolStripMenuItem";
            this.suspensionToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.suspensionToolStripMenuItem.Text = "Suspension";
            // 
            // permissionToReportForWorkToolStripMenuItem
            // 
            this.permissionToReportForWorkToolStripMenuItem.Name = "permissionToReportForWorkToolStripMenuItem";
            this.permissionToReportForWorkToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.permissionToReportForWorkToolStripMenuItem.Text = "Permission to Report for Work";
            // 
            // timeAdjustmentToolStripMenuItem
            // 
            this.timeAdjustmentToolStripMenuItem.Name = "timeAdjustmentToolStripMenuItem";
            this.timeAdjustmentToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.timeAdjustmentToolStripMenuItem.Text = "Time Adjustment";
            // 
            // travelDutyToolStripMenuItem
            // 
            this.travelDutyToolStripMenuItem.Name = "travelDutyToolStripMenuItem";
            this.travelDutyToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.travelDutyToolStripMenuItem.Text = "Travel Duty";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearingToolStripMenuItem,
            this.clearingNEWToolStripMenuItem});
            this.toolStripButton7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton7.ForeColor = System.Drawing.Color.White;
            this.toolStripButton7.Image = global::TimeKeepingII.Properties.Resources.clear_validation;
            this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton7.Text = "Clearing && Validation";
            this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clearingToolStripMenuItem
            // 
            this.clearingToolStripMenuItem.Name = "clearingToolStripMenuItem";
            this.clearingToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.clearingToolStripMenuItem.Text = "Clearing";
            // 
            // clearingNEWToolStripMenuItem
            // 
            this.clearingNEWToolStripMenuItem.Name = "clearingNEWToolStripMenuItem";
            this.clearingNEWToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.clearingNEWToolStripMenuItem.Text = "Clearing (NEW)";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeRecordToolStripMenuItem,
            this.timeChangerToolStripMenuItem,
            this.updateTimeSummaryToolStripMenuItem,
            this.checkUnupdatedTimeSummaryToolStripMenuItem});
            this.toolStripButton6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton6.ForeColor = System.Drawing.Color.White;
            this.toolStripButton6.Image = global::TimeKeepingII.Properties.Resources.time_record_handling;
            this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton6.Text = "Time Record Handling";
            this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeRecordToolStripMenuItem
            // 
            this.timeRecordToolStripMenuItem.Name = "timeRecordToolStripMenuItem";
            this.timeRecordToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.timeRecordToolStripMenuItem.Text = "Time Record";
            // 
            // timeChangerToolStripMenuItem
            // 
            this.timeChangerToolStripMenuItem.Name = "timeChangerToolStripMenuItem";
            this.timeChangerToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.timeChangerToolStripMenuItem.Text = "Time Changer";
            // 
            // updateTimeSummaryToolStripMenuItem
            // 
            this.updateTimeSummaryToolStripMenuItem.Name = "updateTimeSummaryToolStripMenuItem";
            this.updateTimeSummaryToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.updateTimeSummaryToolStripMenuItem.Text = "Update Time Summary";
            // 
            // checkUnupdatedTimeSummaryToolStripMenuItem
            // 
            this.checkUnupdatedTimeSummaryToolStripMenuItem.Name = "checkUnupdatedTimeSummaryToolStripMenuItem";
            this.checkUnupdatedTimeSummaryToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.checkUnupdatedTimeSummaryToolStripMenuItem.Text = "Check Unupdated Time Summary";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateDeductionsForAbsencesToolStripMenuItem,
            this.adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem});
            this.toolStripButton5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton5.ForeColor = System.Drawing.Color.White;
            this.toolStripButton5.Image = global::TimeKeepingII.Properties.Resources.deductionAdjustment;
            this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton5.Text = "Deductions && Adjustments";
            this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // generateDeductionsForAbsencesToolStripMenuItem
            // 
            this.generateDeductionsForAbsencesToolStripMenuItem.Name = "generateDeductionsForAbsencesToolStripMenuItem";
            this.generateDeductionsForAbsencesToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.generateDeductionsForAbsencesToolStripMenuItem.Text = "Generate Deductions for Absences";
            // 
            // adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem
            // 
            this.adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem.Name = "adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem";
            this.adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem.Size = new System.Drawing.Size(384, 22);
            this.adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem.Text = "Adjustment of Time Summary (for Monthly Only)";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlyDailyTimeSummaryToolStripMenuItem,
            this.weeklyTimeSummaryToolStripMenuItem,
            this.managerialTimeSummaryToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.toolStripButton8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton8.ForeColor = System.Drawing.Color.White;
            this.toolStripButton8.Image = global::TimeKeepingII.Properties.Resources.summary_reports;
            this.toolStripButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(278, 44);
            this.toolStripButton8.Text = "Summaries && Reports";
            this.toolStripButton8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // monthlyDailyTimeSummaryToolStripMenuItem
            // 
            this.monthlyDailyTimeSummaryToolStripMenuItem.Name = "monthlyDailyTimeSummaryToolStripMenuItem";
            this.monthlyDailyTimeSummaryToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.monthlyDailyTimeSummaryToolStripMenuItem.Text = "Monthly / Daily Time Summary";
            // 
            // weeklyTimeSummaryToolStripMenuItem
            // 
            this.weeklyTimeSummaryToolStripMenuItem.Name = "weeklyTimeSummaryToolStripMenuItem";
            this.weeklyTimeSummaryToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.weeklyTimeSummaryToolStripMenuItem.Text = "Weekly Time Summary";
            // 
            // managerialTimeSummaryToolStripMenuItem
            // 
            this.managerialTimeSummaryToolStripMenuItem.Name = "managerialTimeSummaryToolStripMenuItem";
            this.managerialTimeSummaryToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.managerialTimeSummaryToolStripMenuItem.Text = "Managerial Time Summary";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 600);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1242, 24);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.pnlMain.Controls.Add(this.tabControl1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 42);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(962, 558);
            this.pnlMain.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(962, 558);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabGlassGradient = true;
            this.tabControl1.TabIconSize = new System.Drawing.Size(0, 0);
            this.tabControl1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 624);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSideMenu);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Keeping II";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenuBurger)).EndInit();
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlSideMenu.PerformLayout();
            this.tsPrimary.ResumeLayout(false);
            this.tsPrimary.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox ptbMenuBurger;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbMinimize;
        private System.Windows.Forms.PictureBox ptbClose;
        private MdiTabControl.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip tsPrimary;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem assignBiometricsIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toEnableDisableEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem downloadDataFromMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repostTimeRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem changeShiftingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDayOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overtimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overtimeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem undertimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveOfAbsentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissionToReportForWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeAdjustmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelDutyToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem clearingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearingNEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem timeRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeChangerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTimeSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUnupdatedTimeSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem generateDeductionsForAbsencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentOfTimeSummaryforMonthlyOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem monthlyDailyTimeSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeklyTimeSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerialTimeSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

