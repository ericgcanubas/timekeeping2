using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    public partial class FrmProfile : Form
    {
        public FrmProfile()
        {
            InitializeComponent();
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsFind_Click(object sender, EventArgs e)
        {

            FrmEmployeeList frm = new FrmEmployeeList();
            frm.ShowDialog();

            if (frm.VALUE != "")
            {

                LoadEmpInfo(frm.VALUE);
            }
        }
        private void LoadEmpInfo(string PK)
        {

            string strSelect = $@"select top 1  a.* ,isnull(b.PPositionName,'')Position,
                                        isnull(c.SSectionName,'')Section,
                                        isnull(d.DDepartment,'')Department,
                                        e.Description Division from ( select a.ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,a.PkId,a.PPosition, a.PSection,a.PDept,a.PDiv,a.PEmploymentStatus, isnull(b.EActive,2)EActive,a.EEmployeeIDNo from ( select a.PK ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,b.PK PkId,c.PPosition, c.PSection,c.PDept,c.PDiv,c.PEmploymentStatus,b.EEmployeeIDNo, Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) from PayrollSystem.dbo.tbl_Profile a join PayrollSystem.dbo.tbl_Profile_IDNumber b on b.Pk = a.CurrentIDNumber join PayrollSystem.dbo.tbl_Profile_Action c on b.PK = c.PEmployeeNo ) a left join PayrollSystem.dbo.EEmploymentStatus b on a.PEmploymentStatus = b.EEmploymentStatus where a.Row = 1  and b.EActive = 1  ) a left join PayrollSystem.dbo.PPositionName b on a.PPosition = b.PPositionIDNo left join PayrollSystem.
                                        dbo.SSection c on a.PSection = c.SSectionID left join PayrollSystem.dbo.DDepartmental d on a.PDept = d.DDepartmentsNo left join PayrollSystem.dbo.EEmployeeDiv e on a.PDiv = e.PK where a.PkId = {PK} ";

            var empData = clsPayrollSystem.GetFirstRecord(strSelect);

            if (empData != null)
            {
                lblEMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                lblEmployeeName.Text = empData["LastName"].ToString() + ", " + empData["FirstName"].ToString() + "  " + empData["MiddleName"].ToString();
                lblADDRESS.Text = empData["CurrAddress"].ToString();
                lblBIRTHDAY.Text = DateTime.Parse(empData["BirthDate"].ToString()).ToShortDateString();
                lblPOSITION.Text = empData["Position"].ToString();
                lblSECTION.Text = empData["Section"].ToString();
                lblDEPARTMENT.Text = empData["Department"].ToString();
                lblDivision.Text = empData["Division"].ToString();
                lblEmpPK.Text = empData["PkId"].ToString();
                RefreshDetails();
                this.Text = $"{lblEmployeeName.Text}";
                Bitmap photo = null;
                object image = GetImage(int.Parse(empData["ProfileId"].ToString()));
                if (image != null)
                {
                    byte[] bytes = (byte[])image;
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes))
                    {
                        photo = new Bitmap(stream);
                    }
                }
                picPHOTO.Image = photo;
            }
        }
        public static object GetImage(int empId)
        {
            object result = null;
            string query = "select Photo from tbl_Profile_Photo where EmployeePK =" + empId + " ";
            var resultData = clsPayrollSystem.GetFirstRecord(query);

            try
            {
                result = resultData["Photo"];
            }
            catch (Exception)
            {

                result = null;
            }


            return result;
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                LoadEmpInfo(this.Tag.ToString());
            }
        }
        private void AssignShift()
        {
            string sql = $"SELECT top 1000 EmployeeShifting.PK as [Control No],FORMAT( EmployeeShifting.EffectDate,'yyyy-MM-dd') as DateEffect,LastModified as [Last Modified]  FROM EmployeeShifting LEFT OUTER JOIN EmployeeName ON EmployeeShifting.EmpNo = EmployeeName.EmpPK where EmployeeName.EmpPk = {lblEmpPK.Text} order by EmployeeShifting.PK DESC";
            DataTable dt = clsBiometrics.dataList(sql);
            clsListView.LoadListView(lvScheduleAssignList, dt);
        }
        private void LeaveUndertimeTab()
        {
            string sql = $"SELECT TOP 1000 LU_nID as ID, nCtrlNo as [Control No.],dTransDate as [Date],[dEffectDate] as [Date Effect],sReason as [Reason] FROM [tbl_LEAVE_UNDERTIME] where EmpPK = '{lblEmpPK.Text}' order by LU_nID desc ";
            DataTable dt = clsBiometrics.dataList(sql);
            clsListView.LoadListView(lvLeaves, dt);
        }
        private void ChangeShiftTab()
        {
            string sql = $"SELECT TOP 1000 ChangeShift.PK as ID ,CtrlNo as [Control No.],DDate as [Date],ShiftName,EffectDate as  [Date Effect] ,RefNo FROM [ChangeShift] LEFT JOIN  EmployeeName ON ChangeShift.EmpNo = EmployeeName.EmpPK LEFT JOIN ShiftingSchedule ON ChangeShift.Shift = ShiftingSchedule.PK where EmpPK = {lblEmpPK.Text} order by ChangeShift.PK DESC  ";
            DataTable dt = clsBiometrics.dataList(sql);
            clsListView.LoadListView(lvChangeShift, dt);

        }
        private void ChangeRestDay()
        {
            string sql = $"SELECT TOP 1000 CD_nID as ID , nCtrlNo as [Control No.],dTransDate as [Date],sReason as [Reason] FROM [tbl_CHANGERESTDAY] where EmpPK = '{lblEmpPK.Text}' order by CD_nID desc";
            DataTable dt = clsBiometrics.dataList(sql);
            clsListView.LoadListView(lvChangeRestDay, dt);
        }
        private void ChangePRW()
        {
            string sql = $"SELECT TOP 1000 PRW_nID as ID ,nCtrlNo as [Control No.],dTransDate as [Date],sReasons as [Reason] FROM [tbl_PRW_NEW] where EmpPK = '{lblEmpPK.Text}' order by PRW_nID desc";
            DataTable dt = clsBiometrics.dataList(sql);
            clsListView.LoadListView(lvPRW, dt);
        }
        private void RefreshDetails()
        {
            AssignShift();
            LeaveUndertimeTab();
            ChangeRestDay();
            ChangeShiftTab();
            ChangePRW();
        }
        private void newCall(string FormName)
        {

            if (lblEmpPK.Text.Length == 0)
            {
                return;
            }

            Form frm = clsMenu.callForm(FormName);
            clsMenu.CloseForm(frm);
            frm.AccessibleName = lblEmpPK.Text.ToString();
            clsMenu.ShowForm(frm);
        }
        private void viewCall(ListView lv, string FormName)
        {
            if (lblEmpPK.Text.Length == 0)
            {
                return;
            }

            if (lv.Items.Count == 0)
            {
                return;
            }

         


            lv.Select();

            Form frm = clsMenu.callForm(FormName);
            clsMenu.CloseForm(frm);
            frm.Tag = lv.FocusedItem.Text;
            clsMenu.ShowForm(frm);
        }
        private void btnNewShift_Click(object sender, EventArgs e)
        {


            newCall("FrmAssignSchedule");
        }

        private void btnViewShift_Click(object sender, EventArgs e)
        {
            viewCall(lvScheduleAssignList, "FrmAssignSchedule");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newCall("FrmLeaveUndertime");
        }

        private void btnViewLeave_Click(object sender, EventArgs e)
        {
            viewCall(lvLeaves, "FrmLeaveUndertime");
        }

        private void btnNewChangeShift_Click(object sender, EventArgs e)
        {

            newCall("FrmChangeShifting");
        }

        private void btnViewChangeShift_Click(object sender, EventArgs e)
        {
            viewCall(lvChangeShift, "FrmChangeShifting");
        }

        private void btnNewRD_Click(object sender, EventArgs e)
        {
            newCall("FrmChangeDayoff");
        }

        private void btnViewRD_Click(object sender, EventArgs e)
        {
            viewCall(lvChangeRestDay, "FrmChangeDayoff");
        }

        private void btnNewPRW_Click(object sender, EventArgs e)
        {
            newCall("FrmPRW");
        }

        private void btnViewPRW_Click(object sender, EventArgs e)
        {
            viewCall(lvPRW, "FrmPRW");
        }

        private void lvScheduleAssignList_DoubleClick(object sender, EventArgs e)
        {
            btnViewShift.PerformClick();
        }

        private void lvLeaves_DoubleClick(object sender, EventArgs e)
        {
            btnViewLeave.PerformClick();
        }

        private void lvChangeRestDay_DoubleClick(object sender, EventArgs e)
        {
            btnViewRD.PerformClick();
        }

        private void lvPRW_DoubleClick(object sender, EventArgs e)
        {
            btnViewPRW.PerformClick();
        }

        private void lvChangeShift_DoubleClick(object sender, EventArgs e)
        {
            btnViewChangeShift.PerformClick();
        }

        private void FrmProfile_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    break;
                case Keys.Delete:
                    break;
                case Keys.F5:
                    break;
                case Keys.Escape:
                    tsClose.PerformClick();
                    break;
                case Keys.F6:
                    tsFind.PerformClick();
                    break;
                case Keys.PageUp:
                    break;
                case Keys.PageDown:
                   break;
                case Keys.Home:
                    break;
                case Keys.F9:
                    break;
                case Keys.F8:
                    break;
                default:
                    // Nothing
                    break;

            }
        }
    }
}
