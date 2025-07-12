namespace TimeKeepingII
{
    partial class FrmHoliday
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
            this.tsHeaderControl = new System.Windows.Forms.ToolStrip();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.tsPosted = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.lblsLastUpdatedBy = new System.Windows.Forms.Label();
            this.lblLU_nID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbHolidyType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpHolidayDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblnCtrlNo = new System.Windows.Forms.Label();
            this.lvEmployee = new System.Windows.Forms.ListView();
            this.Employee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Department = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Section = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Division = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PkId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDivision = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.lnkAll = new System.Windows.Forms.LinkLabel();
            this.txtDESCRIPTION = new System.Windows.Forms.TextBox();
            this.lnkAllRD = new System.Windows.Forms.LinkLabel();
            this.tsHeaderControl.SuspendLayout();
            this.pnlMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHeaderControl
            // 
            this.tsHeaderControl.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.tsHeaderControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdd,
            this.toolStripSeparator1,
            this.tsEdit,
            this.toolStripSeparator2,
            this.tsDelete,
            this.toolStripSeparator3,
            this.tsSave,
            this.toolStripSeparator4,
            this.tsCancel,
            this.toolStripSeparator11,
            this.tsFirst,
            this.toolStripSeparator10,
            this.tsBack,
            this.toolStripSeparator9,
            this.tsNext,
            this.toolStripSeparator8,
            this.tsLast,
            this.toolStripSeparator5,
            this.tsFind,
            this.toolStripSeparator6,
            this.tsClose,
            this.tsPosted,
            this.toolStripSeparator7});
            this.tsHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.tsHeaderControl.Name = "tsHeaderControl";
            this.tsHeaderControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsHeaderControl.Size = new System.Drawing.Size(1210, 52);
            this.tsHeaderControl.TabIndex = 3;
            this.tsHeaderControl.Text = "toolStrip1";
            // 
            // tsAdd
            // 
            this.tsAdd.Image = global::TimeKeepingII.Properties.Resources.add_icon;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(34, 49);
            this.tsAdd.Text = "Add";
            this.tsAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tsEdit
            // 
            this.tsEdit.Image = global::TimeKeepingII.Properties.Resources.edit_icon;
            this.tsEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(34, 49);
            this.tsEdit.Text = "Edit";
            this.tsEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // tsDelete
            // 
            this.tsDelete.Image = global::TimeKeepingII.Properties.Resources.delete_icon;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(44, 49);
            this.tsDelete.Text = "Delete";
            this.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // tsSave
            // 
            this.tsSave.Image = global::TimeKeepingII.Properties.Resources.save_icon;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(35, 49);
            this.tsSave.Text = "Save";
            this.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // tsCancel
            // 
            this.tsCancel.Image = global::TimeKeepingII.Properties.Resources.cancel_icon;
            this.tsCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCancel.Name = "tsCancel";
            this.tsCancel.Size = new System.Drawing.Size(40, 49);
            this.tsCancel.Text = "Undo";
            this.tsCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsCancel.Click += new System.EventHandler(this.tsCancel_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 52);
            // 
            // tsFirst
            // 
            this.tsFirst.Image = global::TimeKeepingII.Properties.Resources.first_icon;
            this.tsFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFirst.Name = "tsFirst";
            this.tsFirst.Size = new System.Drawing.Size(34, 49);
            this.tsFirst.Text = "First";
            this.tsFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsFirst.Click += new System.EventHandler(this.tsFirst_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 52);
            // 
            // tsBack
            // 
            this.tsBack.Image = global::TimeKeepingII.Properties.Resources.back_icon;
            this.tsBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBack.Name = "tsBack";
            this.tsBack.Size = new System.Drawing.Size(36, 49);
            this.tsBack.Text = "Back";
            this.tsBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBack.Click += new System.EventHandler(this.tsBack_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 52);
            // 
            // tsNext
            // 
            this.tsNext.Image = global::TimeKeepingII.Properties.Resources.next_icon;
            this.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(36, 49);
            this.tsNext.Text = "Next";
            this.tsNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsNext.Click += new System.EventHandler(this.tsNext_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 52);
            // 
            // tsLast
            // 
            this.tsLast.Image = global::TimeKeepingII.Properties.Resources.last_icon;
            this.tsLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLast.Name = "tsLast";
            this.tsLast.Size = new System.Drawing.Size(34, 49);
            this.tsLast.Text = "Last";
            this.tsLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsLast.Click += new System.EventHandler(this.tsLast_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // tsFind
            // 
            this.tsFind.Image = global::TimeKeepingII.Properties.Resources.search_icon;
            this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(34, 49);
            this.tsFind.Text = "Find";
            this.tsFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsFind.Click += new System.EventHandler(this.tsFind_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 52);
            // 
            // tsClose
            // 
            this.tsClose.Image = global::TimeKeepingII.Properties.Resources.close_icon;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(40, 49);
            this.tsClose.Text = "Close";
            this.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsClose.Click += new System.EventHandler(this.tsClose_Click);
            // 
            // tsPosted
            // 
            this.tsPosted.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsPosted.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPosted.ForeColor = System.Drawing.Color.Red;
            this.tsPosted.Name = "tsPosted";
            this.tsPosted.Size = new System.Drawing.Size(106, 49);
            this.tsPosted.Text = "POSTED";
            this.tsPosted.Visible = false;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 52);
            // 
            // pnlMode
            // 
            this.pnlMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMode.Controls.Add(this.lblsLastUpdatedBy);
            this.pnlMode.Controls.Add(this.lblLU_nID);
            this.pnlMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMode.Location = new System.Drawing.Point(0, 506);
            this.pnlMode.Name = "pnlMode";
            this.pnlMode.Size = new System.Drawing.Size(1210, 22);
            this.pnlMode.TabIndex = 241;
            // 
            // lblsLastUpdatedBy
            // 
            this.lblsLastUpdatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblsLastUpdatedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblsLastUpdatedBy.Location = new System.Drawing.Point(105, 0);
            this.lblsLastUpdatedBy.Name = "lblsLastUpdatedBy";
            this.lblsLastUpdatedBy.Size = new System.Drawing.Size(1103, 20);
            this.lblsLastUpdatedBy.TabIndex = 14;
            // 
            // lblLU_nID
            // 
            this.lblLU_nID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLU_nID.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLU_nID.Location = new System.Drawing.Point(0, 0);
            this.lblLU_nID.Name = "lblLU_nID";
            this.lblLU_nID.Size = new System.Drawing.Size(105, 20);
            this.lblLU_nID.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 243;
            this.label7.Text = "HOLIDAY TYPE :";
            // 
            // cmbHolidyType
            // 
            this.cmbHolidyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHolidyType.FormattingEnabled = true;
            this.cmbHolidyType.Location = new System.Drawing.Point(127, 65);
            this.cmbHolidyType.Name = "cmbHolidyType";
            this.cmbHolidyType.Size = new System.Drawing.Size(134, 21);
            this.cmbHolidyType.TabIndex = 242;
            this.cmbHolidyType.SelectedIndexChanged += new System.EventHandler(this.cmbHolidyType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 247;
            this.label5.Text = "HOLIDAY DATE :";
            // 
            // dtpHolidayDate
            // 
            this.dtpHolidayDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHolidayDate.Location = new System.Drawing.Point(589, 65);
            this.dtpHolidayDate.Name = "dtpHolidayDate";
            this.dtpHolidayDate.Size = new System.Drawing.Size(134, 20);
            this.dtpHolidayDate.TabIndex = 246;
            this.dtpHolidayDate.ValueChanged += new System.EventHandler(this.dtpHolidayDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 245;
            this.label4.Text = "CONTROL NO. :";
            // 
            // lblnCtrlNo
            // 
            this.lblnCtrlNo.BackColor = System.Drawing.Color.White;
            this.lblnCtrlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblnCtrlNo.Location = new System.Drawing.Point(358, 66);
            this.lblnCtrlNo.Name = "lblnCtrlNo";
            this.lblnCtrlNo.Size = new System.Drawing.Size(117, 21);
            this.lblnCtrlNo.TabIndex = 244;
            this.lblnCtrlNo.Text = " ";
            this.lblnCtrlNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvEmployee
            // 
            this.lvEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEmployee.CheckBoxes = true;
            this.lvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Employee,
            this.Department,
            this.Section,
            this.Position,
            this.Division,
            this.Remarks,
            this.PkId});
            this.lvEmployee.FullRowSelect = true;
            this.lvEmployee.GridLines = true;
            this.lvEmployee.HideSelection = false;
            this.lvEmployee.Location = new System.Drawing.Point(12, 127);
            this.lvEmployee.MultiSelect = false;
            this.lvEmployee.Name = "lvEmployee";
            this.lvEmployee.Size = new System.Drawing.Size(1186, 373);
            this.lvEmployee.TabIndex = 248;
            this.lvEmployee.UseCompatibleStateImageBehavior = false;
            this.lvEmployee.View = System.Windows.Forms.View.Details;
            this.lvEmployee.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvEmployee_ItemChecked);
            this.lvEmployee.SelectedIndexChanged += new System.EventHandler(this.lvEmployee_SelectedIndexChanged);
            this.lvEmployee.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvEmployee_MouseClick);
            // 
            // Employee
            // 
            this.Employee.Text = "Employee";
            this.Employee.Width = 289;
            // 
            // Department
            // 
            this.Department.Text = "Department";
            this.Department.Width = 216;
            // 
            // Section
            // 
            this.Section.Text = "Section";
            this.Section.Width = 224;
            // 
            // Position
            // 
            this.Position.Text = "Position";
            this.Position.Width = 196;
            // 
            // Division
            // 
            this.Division.Text = "Area";
            this.Division.Width = 120;
            // 
            // Remarks
            // 
            this.Remarks.Text = "Remarks";
            this.Remarks.Width = 116;
            // 
            // PkId
            // 
            this.PkId.Text = "PkId";
            this.PkId.Width = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(729, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 250;
            this.label1.Text = "DESCRIPTION :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 252;
            this.label3.Text = "AREA :";
            // 
            // cmbDivision
            // 
            this.cmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDivision.FormattingEnabled = true;
            this.cmbDivision.Location = new System.Drawing.Point(56, 100);
            this.cmbDivision.Name = "cmbDivision";
            this.cmbDivision.Size = new System.Drawing.Size(132, 21);
            this.cmbDivision.TabIndex = 251;
            this.cmbDivision.SelectedIndexChanged += new System.EventHandler(this.cmbDivision_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 254;
            this.label6.Text = "DEPARTMENT :";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(288, 100);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(200, 21);
            this.cmbDepartment.TabIndex = 253;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 256;
            this.label8.Text = "SECTION :";
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(560, 100);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(189, 21);
            this.cmbSection.TabIndex = 255;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // lnkAll
            // 
            this.lnkAll.AutoSize = true;
            this.lnkAll.Location = new System.Drawing.Point(805, 103);
            this.lnkAll.Name = "lnkAll";
            this.lnkAll.Size = new System.Drawing.Size(101, 13);
            this.lnkAll.TabIndex = 257;
            this.lnkAll.TabStop = true;
            this.lnkAll.Text = "All Check/Uncheck";
            this.lnkAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAll_LinkClicked);
            // 
            // txtDESCRIPTION
            // 
            this.txtDESCRIPTION.Location = new System.Drawing.Point(821, 61);
            this.txtDESCRIPTION.Name = "txtDESCRIPTION";
            this.txtDESCRIPTION.Size = new System.Drawing.Size(246, 20);
            this.txtDESCRIPTION.TabIndex = 258;
            // 
            // lnkAllRD
            // 
            this.lnkAllRD.AutoSize = true;
            this.lnkAllRD.Location = new System.Drawing.Point(991, 103);
            this.lnkAllRD.Name = "lnkAllRD";
            this.lnkAllRD.Size = new System.Drawing.Size(167, 13);
            this.lnkAllRD.TabIndex = 259;
            this.lnkAllRD.TabStop = true;
            this.lnkAllRD.Text = "Check/Uncheck All RD && Leaves";
            this.lnkAllRD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAllRD_LinkClicked);
            // 
            // FrmHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 528);
            this.Controls.Add(this.lnkAllRD);
            this.Controls.Add(this.txtDESCRIPTION);
            this.Controls.Add(this.lnkAll);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDivision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvEmployee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpHolidayDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblnCtrlNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbHolidyType);
            this.Controls.Add(this.pnlMode);
            this.Controls.Add(this.tsHeaderControl);
            this.Name = "FrmHoliday";
            this.Text = "Holiday Form";
            this.Load += new System.EventHandler(this.FrmHoliday_Load);
            this.tsHeaderControl.ResumeLayout(false);
            this.tsHeaderControl.PerformLayout();
            this.pnlMode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsHeaderControl;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripLabel tsPosted;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.Label lblsLastUpdatedBy;
        private System.Windows.Forms.Label lblLU_nID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbHolidyType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpHolidayDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblnCtrlNo;
        private System.Windows.Forms.ListView lvEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDivision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ColumnHeader Employee;
        private System.Windows.Forms.ColumnHeader Department;
        private System.Windows.Forms.ColumnHeader Section;
        private System.Windows.Forms.ColumnHeader Position;
        private System.Windows.Forms.ColumnHeader Division;
        private System.Windows.Forms.ColumnHeader Remarks;
        private System.Windows.Forms.ColumnHeader PkId;
        private System.Windows.Forms.LinkLabel lnkAll;
        private System.Windows.Forms.TextBox txtDESCRIPTION;
        private System.Windows.Forms.LinkLabel lnkAllRD;
    }
}