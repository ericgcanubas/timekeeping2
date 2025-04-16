namespace TimeKeepingII
{
    partial class FrmShiftingSchedule
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
            this.tsLocked = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShiftType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpIN_AM = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpIN_Lunch = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpIN_Break = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpOUT_PM = new System.Windows.Forms.DateTimePicker();
            this.dtpOUT_Break = new System.Windows.Forms.DateTimePicker();
            this.dtpOUT_Lunch = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.numLunch = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numBreakTime = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.lblLastModifiedBy = new System.Windows.Forms.Label();
            this.lblPK = new System.Windows.Forms.Label();
            this.chkFixed = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tsHeaderControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreakTime)).BeginInit();
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
            this.tsLocked,
            this.toolStripSeparator7});
            this.tsHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.tsHeaderControl.Name = "tsHeaderControl";
            this.tsHeaderControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsHeaderControl.Size = new System.Drawing.Size(648, 52);
            this.tsHeaderControl.TabIndex = 1;
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
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
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
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
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
            // tsLocked
            // 
            this.tsLocked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLocked.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLocked.ForeColor = System.Drawing.Color.Red;
            this.tsLocked.Name = "tsLocked";
            this.tsLocked.Size = new System.Drawing.Size(106, 49);
            this.tsLocked.Text = "LOCKED";
            this.tsLocked.Visible = false;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 52);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SHIFT NAME :";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(112, 74);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(261, 20);
            this.txtShiftName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SHIFT TYPE : ";
            // 
            // cmbShiftType
            // 
            this.cmbShiftType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftType.FormattingEnabled = true;
            this.cmbShiftType.Location = new System.Drawing.Point(112, 100);
            this.cmbShiftType.Name = "cmbShiftType";
            this.cmbShiftType.Size = new System.Drawing.Size(261, 21);
            this.cmbShiftType.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "MORNING :";
            // 
            // dtpIN_AM
            // 
            this.dtpIN_AM.Checked = false;
            this.dtpIN_AM.CustomFormat = "h:mm tt";
            this.dtpIN_AM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIN_AM.Location = new System.Drawing.Point(112, 152);
            this.dtpIN_AM.Name = "dtpIN_AM";
            this.dtpIN_AM.ShowUpDown = true;
            this.dtpIN_AM.Size = new System.Drawing.Size(90, 20);
            this.dtpIN_AM.TabIndex = 11;
            this.dtpIN_AM.Value = new System.DateTime(2025, 4, 15, 2, 14, 0, 0);
            this.dtpIN_AM.Leave += new System.EventHandler(this.dtpIN_AM_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "LUNCH / BREAK :";
            // 
            // dtpIN_Lunch
            // 
            this.dtpIN_Lunch.Checked = false;
            this.dtpIN_Lunch.CustomFormat = "h:mm tt";
            this.dtpIN_Lunch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIN_Lunch.Location = new System.Drawing.Point(112, 178);
            this.dtpIN_Lunch.Name = "dtpIN_Lunch";
            this.dtpIN_Lunch.ShowCheckBox = true;
            this.dtpIN_Lunch.ShowUpDown = true;
            this.dtpIN_Lunch.Size = new System.Drawing.Size(90, 20);
            this.dtpIN_Lunch.TabIndex = 13;
            this.dtpIN_Lunch.ValueChanged += new System.EventHandler(this.dtpIN_Lunch_ValueChanged);
            this.dtpIN_Lunch.Leave += new System.EventHandler(this.dtpIN_Lunch_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "EVENING :";
            // 
            // dtpIN_Break
            // 
            this.dtpIN_Break.Checked = false;
            this.dtpIN_Break.CustomFormat = "h:mm tt";
            this.dtpIN_Break.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIN_Break.Location = new System.Drawing.Point(112, 204);
            this.dtpIN_Break.Name = "dtpIN_Break";
            this.dtpIN_Break.ShowCheckBox = true;
            this.dtpIN_Break.ShowUpDown = true;
            this.dtpIN_Break.Size = new System.Drawing.Size(90, 20);
            this.dtpIN_Break.TabIndex = 15;
            this.dtpIN_Break.ValueChanged += new System.EventHandler(this.dtpIN_Break_ValueChanged);
            this.dtpIN_Break.Leave += new System.EventHandler(this.dtpIN_Break_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(148, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "IN";
            // 
            // dtpOUT_PM
            // 
            this.dtpOUT_PM.Checked = false;
            this.dtpOUT_PM.CustomFormat = "h:mm tt";
            this.dtpOUT_PM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOUT_PM.Location = new System.Drawing.Point(266, 204);
            this.dtpOUT_PM.Name = "dtpOUT_PM";
            this.dtpOUT_PM.ShowUpDown = true;
            this.dtpOUT_PM.Size = new System.Drawing.Size(90, 20);
            this.dtpOUT_PM.TabIndex = 17;
            // 
            // dtpOUT_Break
            // 
            this.dtpOUT_Break.Checked = false;
            this.dtpOUT_Break.CustomFormat = "h:mm tt";
            this.dtpOUT_Break.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOUT_Break.Location = new System.Drawing.Point(266, 178);
            this.dtpOUT_Break.Name = "dtpOUT_Break";
            this.dtpOUT_Break.ShowCheckBox = true;
            this.dtpOUT_Break.ShowUpDown = true;
            this.dtpOUT_Break.Size = new System.Drawing.Size(90, 20);
            this.dtpOUT_Break.TabIndex = 14;
            this.dtpOUT_Break.ValueChanged += new System.EventHandler(this.dtpOUT_Break_ValueChanged);
            this.dtpOUT_Break.Leave += new System.EventHandler(this.dtpOUT_Break_Leave);
            // 
            // dtpOUT_Lunch
            // 
            this.dtpOUT_Lunch.Checked = false;
            this.dtpOUT_Lunch.CustomFormat = "h:mm tt";
            this.dtpOUT_Lunch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOUT_Lunch.Location = new System.Drawing.Point(266, 152);
            this.dtpOUT_Lunch.Name = "dtpOUT_Lunch";
            this.dtpOUT_Lunch.ShowCheckBox = true;
            this.dtpOUT_Lunch.ShowUpDown = true;
            this.dtpOUT_Lunch.Size = new System.Drawing.Size(90, 20);
            this.dtpOUT_Lunch.TabIndex = 12;
            this.dtpOUT_Lunch.ValueChanged += new System.EventHandler(this.dtpOUT_Lunch_ValueChanged);
            this.dtpOUT_Lunch.Leave += new System.EventHandler(this.dtpOUT_Lunch_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(294, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "OUT";
            // 
            // numLunch
            // 
            this.numLunch.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numLunch.InterceptArrowKeys = false;
            this.numLunch.Location = new System.Drawing.Point(112, 247);
            this.numLunch.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numLunch.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numLunch.Name = "numLunch";
            this.numLunch.ReadOnly = true;
            this.numLunch.Size = new System.Drawing.Size(90, 20);
            this.numLunch.TabIndex = 22;
            this.numLunch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLunch.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "LUNCH :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "BREAK :";
            // 
            // numBreakTime
            // 
            this.numBreakTime.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numBreakTime.InterceptArrowKeys = false;
            this.numBreakTime.Location = new System.Drawing.Point(112, 274);
            this.numBreakTime.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numBreakTime.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numBreakTime.Name = "numBreakTime";
            this.numBreakTime.ReadOnly = true;
            this.numBreakTime.Size = new System.Drawing.Size(90, 20);
            this.numBreakTime.TabIndex = 25;
            this.numBreakTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBreakTime.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Minutes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(206, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Minutes";
            // 
            // pnlMode
            // 
            this.pnlMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMode.Controls.Add(this.lblLastModifiedBy);
            this.pnlMode.Controls.Add(this.lblPK);
            this.pnlMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMode.Location = new System.Drawing.Point(0, 413);
            this.pnlMode.Name = "pnlMode";
            this.pnlMode.Size = new System.Drawing.Size(648, 22);
            this.pnlMode.TabIndex = 32;
            // 
            // lblLastModifiedBy
            // 
            this.lblLastModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastModifiedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastModifiedBy.Location = new System.Drawing.Point(105, 0);
            this.lblLastModifiedBy.Name = "lblLastModifiedBy";
            this.lblLastModifiedBy.Size = new System.Drawing.Size(541, 20);
            this.lblLastModifiedBy.TabIndex = 14;
            // 
            // lblPK
            // 
            this.lblPK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPK.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPK.Location = new System.Drawing.Point(0, 0);
            this.lblPK.Name = "lblPK";
            this.lblPK.Size = new System.Drawing.Size(105, 20);
            this.lblPK.TabIndex = 13;
            // 
            // chkFixed
            // 
            this.chkFixed.AutoSize = true;
            this.chkFixed.Location = new System.Drawing.Point(112, 311);
            this.chkFixed.Name = "chkFixed";
            this.chkFixed.Size = new System.Drawing.Size(118, 17);
            this.chkFixed.TabIndex = 33;
            this.chkFixed.Text = "FIXED SCHEDULE";
            this.chkFixed.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(384, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "MORNING :";
            // 
            // FrmShiftingSchedule
            // 
            this.AccessibleDescription = "SHIFTING SCHEDULE";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 435);
            this.ControlBox = false;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numLunch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkFixed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlMode);
            this.Controls.Add(this.numBreakTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpOUT_PM);
            this.Controls.Add(this.dtpOUT_Break);
            this.Controls.Add(this.dtpOUT_Lunch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpIN_Break);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpIN_Lunch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpIN_AM);
            this.Controls.Add(this.cmbShiftType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsHeaderControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShiftingSchedule";
            this.ShowIcon = false;
            this.Text = "Shifting Schedule";
            this.Load += new System.EventHandler(this.FrmShiftingSchedule_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmShiftingSchedule_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmShiftingSchedule_PreviewKeyDown);
            this.tsHeaderControl.ResumeLayout(false);
            this.tsHeaderControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreakTime)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripLabel tsLocked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbShiftType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpIN_AM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpIN_Lunch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpIN_Break;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpOUT_PM;
        private System.Windows.Forms.DateTimePicker dtpOUT_Break;
        private System.Windows.Forms.DateTimePicker dtpOUT_Lunch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numLunch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numBreakTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsLast;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.Label lblLastModifiedBy;
        private System.Windows.Forms.Label lblPK;
        private System.Windows.Forms.CheckBox chkFixed;
        private System.Windows.Forms.Label label12;
    }
}