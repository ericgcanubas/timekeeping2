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
            this.pictureBox1.Location = new System.Drawing.Point(73, 0);
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
            this.label1.Size = new System.Drawing.Size(172, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Keeping";
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
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 42);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(280, 572);
            this.pnlSideMenu.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(112)))), ((int)(((byte)(170)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 572);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 614);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1242, 10);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.pnlMain.Controls.Add(this.tabControl1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 42);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(962, 572);
            this.pnlMain.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(962, 572);
            this.tabControl1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabHeight = 30;
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
        private MdiTabControl.TabControl tabControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox ptbClose;
    }
}

