namespace TimeKeepingII
{
    partial class FrmSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBIO_SERVER = new System.Windows.Forms.TextBox();
            this.txtPAYROLL_SERVER = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFinalSetup = new System.Windows.Forms.Label();
            this.lblConnectionCheck = new System.Windows.Forms.Label();
            this.lblConnectionSetup = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlSetup = new System.Windows.Forms.Panel();
            this.pnlTest = new System.Windows.Forms.Panel();
            this.chkFinal = new System.Windows.Forms.CheckBox();
            this.chkPayroll = new System.Windows.Forms.CheckBox();
            this.chkBiometrics = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlSetupComplete = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBIO_DATABASE = new System.Windows.Forms.TextBox();
            this.txtBIO_USERNAME = new System.Windows.Forms.TextBox();
            this.txtBIO_PASSWORD = new System.Windows.Forms.TextBox();
            this.txtPAYROLL_DATABASE = new System.Windows.Forms.TextBox();
            this.txtPAYROLL_USERNAME = new System.Windows.Forms.TextBox();
            this.txtPAYTROLL_PASSWORD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSetup.SuspendLayout();
            this.pnlTest.SuspendLayout();
            this.pnlSetupComplete.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection :";
            // 
            // txtBIO_SERVER
            // 
            this.txtBIO_SERVER.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIO_SERVER.Location = new System.Drawing.Point(174, 46);
            this.txtBIO_SERVER.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBIO_SERVER.Name = "txtBIO_SERVER";
            this.txtBIO_SERVER.Size = new System.Drawing.Size(158, 22);
            this.txtBIO_SERVER.TabIndex = 1;
            // 
            // txtPAYROLL_SERVER
            // 
            this.txtPAYROLL_SERVER.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAYROLL_SERVER.Location = new System.Drawing.Point(174, 210);
            this.txtPAYROLL_SERVER.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPAYROLL_SERVER.Name = "txtPAYROLL_SERVER";
            this.txtPAYROLL_SERVER.Size = new System.Drawing.Size(158, 22);
            this.txtPAYROLL_SERVER.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connection :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblFinalSetup);
            this.panel1.Controls.Add(this.lblConnectionCheck);
            this.panel1.Controls.Add(this.lblConnectionSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 362);
            this.panel1.TabIndex = 4;
            // 
            // lblFinalSetup
            // 
            this.lblFinalSetup.AutoSize = true;
            this.lblFinalSetup.ForeColor = System.Drawing.Color.White;
            this.lblFinalSetup.Location = new System.Drawing.Point(25, 116);
            this.lblFinalSetup.Name = "lblFinalSetup";
            this.lblFinalSetup.Size = new System.Drawing.Size(71, 17);
            this.lblFinalSetup.TabIndex = 2;
            this.lblFinalSetup.Text = "Final Setup";
            // 
            // lblConnectionCheck
            // 
            this.lblConnectionCheck.AutoSize = true;
            this.lblConnectionCheck.ForeColor = System.Drawing.Color.White;
            this.lblConnectionCheck.Location = new System.Drawing.Point(25, 73);
            this.lblConnectionCheck.Name = "lblConnectionCheck";
            this.lblConnectionCheck.Size = new System.Drawing.Size(111, 17);
            this.lblConnectionCheck.TabIndex = 1;
            this.lblConnectionCheck.Text = "Connection Check";
            // 
            // lblConnectionSetup
            // 
            this.lblConnectionSetup.AutoSize = true;
            this.lblConnectionSetup.ForeColor = System.Drawing.Color.White;
            this.lblConnectionSetup.Location = new System.Drawing.Point(25, 34);
            this.lblConnectionSetup.Name = "lblConnectionSetup";
            this.lblConnectionSetup.Size = new System.Drawing.Size(110, 17);
            this.lblConnectionSetup.TabIndex = 0;
            this.lblConnectionSetup.Text = "Connection Setup";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 362);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(576, 39);
            this.panel2.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(487, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(312, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 28);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(395, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 28);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlSetup
            // 
            this.pnlSetup.Controls.Add(this.label11);
            this.pnlSetup.Controls.Add(this.label10);
            this.pnlSetup.Controls.Add(this.label9);
            this.pnlSetup.Controls.Add(this.label8);
            this.pnlSetup.Controls.Add(this.label7);
            this.pnlSetup.Controls.Add(this.label5);
            this.pnlSetup.Controls.Add(this.label4);
            this.pnlSetup.Controls.Add(this.label3);
            this.pnlSetup.Controls.Add(this.txtPAYTROLL_PASSWORD);
            this.pnlSetup.Controls.Add(this.txtPAYROLL_USERNAME);
            this.pnlSetup.Controls.Add(this.txtPAYROLL_DATABASE);
            this.pnlSetup.Controls.Add(this.txtBIO_PASSWORD);
            this.pnlSetup.Controls.Add(this.txtBIO_USERNAME);
            this.pnlSetup.Controls.Add(this.txtBIO_DATABASE);
            this.pnlSetup.Controls.Add(this.txtBIO_SERVER);
            this.pnlSetup.Controls.Add(this.label1);
            this.pnlSetup.Controls.Add(this.txtPAYROLL_SERVER);
            this.pnlSetup.Controls.Add(this.label2);
            this.pnlSetup.Location = new System.Drawing.Point(188, 22);
            this.pnlSetup.Name = "pnlSetup";
            this.pnlSetup.Size = new System.Drawing.Size(374, 334);
            this.pnlSetup.TabIndex = 6;
            this.pnlSetup.Visible = false;
            // 
            // pnlTest
            // 
            this.pnlTest.Controls.Add(this.chkFinal);
            this.pnlTest.Controls.Add(this.chkPayroll);
            this.pnlTest.Controls.Add(this.chkBiometrics);
            this.pnlTest.Location = new System.Drawing.Point(218, 119);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(314, 111);
            this.pnlTest.TabIndex = 7;
            this.pnlTest.Visible = false;
            // 
            // chkFinal
            // 
            this.chkFinal.AutoSize = true;
            this.chkFinal.Location = new System.Drawing.Point(68, 78);
            this.chkFinal.Name = "chkFinal";
            this.chkFinal.Size = new System.Drawing.Size(168, 21);
            this.chkFinal.TabIndex = 2;
            this.chkFinal.Text = "Success Connection Test";
            this.chkFinal.UseVisualStyleBackColor = true;
            // 
            // chkPayroll
            // 
            this.chkPayroll.AutoSize = true;
            this.chkPayroll.Location = new System.Drawing.Point(68, 51);
            this.chkPayroll.Name = "chkPayroll";
            this.chkPayroll.Size = new System.Drawing.Size(207, 21);
            this.chkPayroll.TabIndex = 1;
            this.chkPayroll.Text = "Connecting Payroll System Test";
            this.chkPayroll.UseVisualStyleBackColor = true;
            // 
            // chkBiometrics
            // 
            this.chkBiometrics.AutoSize = true;
            this.chkBiometrics.Location = new System.Drawing.Point(68, 24);
            this.chkBiometrics.Name = "chkBiometrics";
            this.chkBiometrics.Size = new System.Drawing.Size(183, 21);
            this.chkBiometrics.TabIndex = 0;
            this.chkBiometrics.Text = "Connecting Biometrics Test";
            this.chkBiometrics.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlSetupComplete
            // 
            this.pnlSetupComplete.Controls.Add(this.label6);
            this.pnlSetupComplete.Location = new System.Drawing.Point(216, 113);
            this.pnlSetupComplete.Name = "pnlSetupComplete";
            this.pnlSetupComplete.Size = new System.Drawing.Size(314, 123);
            this.pnlSetupComplete.TabIndex = 8;
            this.pnlSetupComplete.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(74, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Setup Complete...";
            // 
            // txtBIO_DATABASE
            // 
            this.txtBIO_DATABASE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIO_DATABASE.Location = new System.Drawing.Point(174, 69);
            this.txtBIO_DATABASE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBIO_DATABASE.Name = "txtBIO_DATABASE";
            this.txtBIO_DATABASE.Size = new System.Drawing.Size(158, 22);
            this.txtBIO_DATABASE.TabIndex = 4;
            // 
            // txtBIO_USERNAME
            // 
            this.txtBIO_USERNAME.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIO_USERNAME.Location = new System.Drawing.Point(174, 92);
            this.txtBIO_USERNAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBIO_USERNAME.Name = "txtBIO_USERNAME";
            this.txtBIO_USERNAME.Size = new System.Drawing.Size(158, 22);
            this.txtBIO_USERNAME.TabIndex = 5;
            // 
            // txtBIO_PASSWORD
            // 
            this.txtBIO_PASSWORD.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIO_PASSWORD.Location = new System.Drawing.Point(174, 116);
            this.txtBIO_PASSWORD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBIO_PASSWORD.Name = "txtBIO_PASSWORD";
            this.txtBIO_PASSWORD.PasswordChar = '*';
            this.txtBIO_PASSWORD.Size = new System.Drawing.Size(158, 22);
            this.txtBIO_PASSWORD.TabIndex = 6;
            // 
            // txtPAYROLL_DATABASE
            // 
            this.txtPAYROLL_DATABASE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAYROLL_DATABASE.Location = new System.Drawing.Point(174, 235);
            this.txtPAYROLL_DATABASE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPAYROLL_DATABASE.Name = "txtPAYROLL_DATABASE";
            this.txtPAYROLL_DATABASE.Size = new System.Drawing.Size(158, 22);
            this.txtPAYROLL_DATABASE.TabIndex = 7;
            // 
            // txtPAYROLL_USERNAME
            // 
            this.txtPAYROLL_USERNAME.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAYROLL_USERNAME.Location = new System.Drawing.Point(174, 260);
            this.txtPAYROLL_USERNAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPAYROLL_USERNAME.Name = "txtPAYROLL_USERNAME";
            this.txtPAYROLL_USERNAME.Size = new System.Drawing.Size(158, 22);
            this.txtPAYROLL_USERNAME.TabIndex = 8;
            // 
            // txtPAYTROLL_PASSWORD
            // 
            this.txtPAYTROLL_PASSWORD.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAYTROLL_PASSWORD.Location = new System.Drawing.Point(174, 286);
            this.txtPAYTROLL_PASSWORD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPAYTROLL_PASSWORD.Name = "txtPAYTROLL_PASSWORD";
            this.txtPAYTROLL_PASSWORD.PasswordChar = '*';
            this.txtPAYTROLL_PASSWORD.Size = new System.Drawing.Size(158, 22);
            this.txtPAYTROLL_PASSWORD.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Database :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "User ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Database : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "User ID :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Password :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(110, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Payroll";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(91, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Biometrics";
            // 
            // FrmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(576, 401);
            this.Controls.Add(this.pnlSetupComplete);
            this.Controls.Add(this.pnlTest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSetup);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSetup";
            this.Load += new System.EventHandler(this.FrmSetup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlSetup.ResumeLayout(false);
            this.pnlSetup.PerformLayout();
            this.pnlTest.ResumeLayout(false);
            this.pnlTest.PerformLayout();
            this.pnlSetupComplete.ResumeLayout(false);
            this.pnlSetupComplete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBIO_SERVER;
        private System.Windows.Forms.TextBox txtPAYROLL_SERVER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFinalSetup;
        private System.Windows.Forms.Label lblConnectionCheck;
        private System.Windows.Forms.Label lblConnectionSetup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlSetup;
        private System.Windows.Forms.Panel pnlTest;
        private System.Windows.Forms.CheckBox chkFinal;
        private System.Windows.Forms.CheckBox chkPayroll;
        private System.Windows.Forms.CheckBox chkBiometrics;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlSetupComplete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPAYTROLL_PASSWORD;
        private System.Windows.Forms.TextBox txtPAYROLL_USERNAME;
        private System.Windows.Forms.TextBox txtPAYROLL_DATABASE;
        private System.Windows.Forms.TextBox txtBIO_PASSWORD;
        private System.Windows.Forms.TextBox txtBIO_USERNAME;
        private System.Windows.Forms.TextBox txtBIO_DATABASE;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}