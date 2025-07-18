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
    public partial class FrmFind : Form
    {


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public string PK;
        public bool isYes;
        public string strQuery;
        public string tableName;
        private string sqlBase;
        private bool isBioData = false;
        private string sTitle;
        public FrmFind(string strQuery, bool isBio = true, string _Title = "Find")
        {
            InitializeComponent();

            this.strQuery = strQuery;
            this.isBioData = isBio;
            this.sTitle = _Title;

        }
        private string cutString(string column)
        {
            return column.Contains(".")
                     ? column.Split('.').Last().Trim()
                     : column.Trim();
        }
        private void FrmFind_Load(object sender, EventArgs e)
        {
            lblTitle.Text = sTitle;

            cmbFind.Items.Clear();
            this.PK = "";
            this.isYes = false;

            string[] getcol = clsMisc.strColumn(strQuery);
            foreach (string column in getcol)
            {
                string columnName = cutString(column);
                cmbFind.Items.Add(columnName);

            }
            this.sqlBase = strQuery;
            cmbFind.SelectedIndex = 1;
            Filter();
        }
        private DataTable dataLoad()
        {

            if (txtFind.Text.Trim().Length > 0)
            {
                string[] getcol = clsMisc.strColumn(strQuery);
                foreach (string column in getcol)
                {
                    string columnName = cutString(column);
                    if (columnName == cmbFind.Text)
                    {
                        if (isBioData)
                        {
                            return clsBiometrics.dataList($@"{sqlBase} WHERE {column} {getSearch(txtFind.Text)}");
                        }
                        else
                        {
                            return clsPayrollSystem.dataList($@"{sqlBase} WHERE {column} {getSearch(txtFind.Text)}");
                        }

                    }
                }
                return null;

            }
            else
            {
                if (isBioData)
                {
                    return clsBiometrics.dataList(sqlBase);
                }
                else
                {
                    return clsPayrollSystem.dataList(sqlBase);
                }

            }
        }
        private string getSearch(string value)
        {
            if (cmbFind.SelectedIndex == 0)
            {
                return $" = {value.Replace("'", "`")}";
            }

            return $" LIKE '%{value.Replace("'", "`")}%'";
        }
        private void Filter()
        {

            clsListView.LoadListView(lvFind, dataLoad());
            lblTotal.Text = lvFind.Items.Count.ToString();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (PK.Length == 0)
            {

                return;
            }

            this.isYes = true;
            this.Close();

        }

        private void lvFind_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (lvFind.FocusedItem != null)
                {
                    this.PK = lvFind.FocusedItem.Text;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                PK = "";
            }

        }

        private void lvFind_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnFilter.PerformClick();
                    break;
                case Keys.Down:
                    if (lvFind.Items.Count > 0)
                    {
                        lvFind.Select();
                    }
                    break;
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
                case Keys.F5:
                    btnOK.PerformClick();
                    break;
                default:
                    break;
            }
        }
        private void lvFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                txtFind.Select();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
