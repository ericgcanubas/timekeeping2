namespace TimeKeepingII
{
    partial class FrmAssignSchedule
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLocked = new System.Windows.Forms.ToolStripLabel();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsEdit = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsCancel = new System.Windows.Forms.ToolStripButton();
            this.tsFind = new System.Windows.Forms.ToolStripButton();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tsHeaderControl.SuspendLayout();
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
            this.toolStripSeparator5,
            this.tsFind,
            this.toolStripSeparator6,
            this.tsClose,
            this.tsLocked,
            this.toolStripSeparator7});
            this.tsHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.tsHeaderControl.Name = "tsHeaderControl";
            this.tsHeaderControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsHeaderControl.Size = new System.Drawing.Size(787, 52);
            this.tsHeaderControl.TabIndex = 0;
            this.tsHeaderControl.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 52);
            // 
            // tsLocked
            // 
            this.tsLocked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLocked.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLocked.ForeColor = System.Drawing.Color.Red;
            this.tsLocked.Name = "tsLocked";
            this.tsLocked.Size = new System.Drawing.Size(106, 49);
            this.tsLocked.Text = "LOCKED";
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
            // tsDelete
            // 
            this.tsDelete.Image = global::TimeKeepingII.Properties.Resources.delete_icon;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(44, 49);
            this.tsDelete.Text = "Delete";
            this.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // tsFind
            // 
            this.tsFind.Image = global::TimeKeepingII.Properties.Resources.search_icon;
            this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(34, 49);
            this.tsFind.Text = "Find";
            this.tsFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 52);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID NUMBER ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(307, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "EFFECTIVELY";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(138, 130);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // FrmAssignSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 432);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsHeaderControl);
            this.Name = "FrmAssignSchedule";
            this.Text = "Assigning Schedule";
            this.Load += new System.EventHandler(this.FrmAssignSchedule_Load);
            this.tsHeaderControl.ResumeLayout(false);
            this.tsHeaderControl.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}