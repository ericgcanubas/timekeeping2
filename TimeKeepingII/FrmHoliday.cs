using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeKeepingII.Reports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TimeKeepingII
{
    public partial class FrmHoliday : Form
    {
        private clsReports reports; 

        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 HolidayCntrlId as ID,HolidayName,HolidayDate,HolidayType FROM [tbl_HolidayName] order by HolidayCntrlId DESC ");
        string strEmp = "select 0 AS selected, a.* ,isnull(b.PPositionName,'')Position, isnull(c.SSectionName,'')Section, isnull(d.DDepartment,'')Department,e.Description Division from ( select a.ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,a.PkId,a.PPosition, a.PSection,a.PDept,a.PDiv,a.PEmploymentStatus, isnull(b.EActive,2)EActive,a.EEmployeeIDNo from ( select a.PK ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,b.PK PkId,c.PPosition, c.PSection,c.PDept,c.PDiv,c.PEmploymentStatus,b.EEmployeeIDNo, Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) from PayrollSystem.dbo.tbl_Profile a join PayrollSystem.dbo.tbl_Profile_IDNumber b on b.Pk = a.CurrentIDNumber join PayrollSystem.dbo.tbl_Profile_Action c on b.PK = c.PEmployeeNo ) a left join PayrollSystem.dbo.EEmploymentStatus b on a.PEmploymentStatus = b.EEmploymentStatus where a.Row = 1 and b.EActive = 1 ) a left join PayrollSystem.dbo.PPositionName b on a.PPosition = b.PPositionIDNo left join PayrollSystem.dbo.SSection c on a.PSection = c.SSectionID left join PayrollSystem.dbo.DDepartmental d on a.PDept = d.DDepartmentsNo left join PayrollSystem.dbo.EEmployeeDiv e on a.PDiv = e.PK where 1=1 ";
        string sSelectSql = $@"select TOP 1 h.HolidayCntrlId,h.DateCreated, h.CreatedBy,hn.HolidayNamePk,hn.HolidayDate, hn.HolidayType,hn.HolidayName from tbl_Holiday as h inner join tbl_HolidayName as hn on hn.HolidayCntrlId  =  h.HolidayCntrlId";

        public DataTable employeeList;

        public FrmHoliday()
        {
            InitializeComponent();
            reports = new clsReports();
        }

        private void FrmHoliday_Load(object sender, EventArgs e)
        {

            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            clsComponentControl.ClearValue(this);

            LoadData();

        }

        private void LoadData()
        {
            try
            {
                LoadHolidayType();
                LoadArea();

                cmbDivision.Enabled = true;
                cmbDepartment.Enabled = true;
                cmbSection.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void EmployeeRecord()
        {

            employeeList = clsBiometrics.dataList($@"select (CASE WHEN he.IsHolidayDuty = 0 THEN 0 ELSE 1 END) AS selected, a.ProfileId, a.LastName, a.FirstName, a.MiddleName,a.EEmployeeIDNo,a.PkId, a.PPosition, a.PSection, a.PDept,a.PDiv ,isnull(b.PPositionName,'') as Position, isnull(c.SSectionName,'') as Section, isnull(d.DDepartment,'') as Department,e.Description Division from ( select a.ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,a.PkId,a.PPosition, a.PSection,a.PDept,a.PDiv,a.PEmploymentStatus, isnull(b.EActive,2)EActive,a.EEmployeeIDNo from ( select a.PK ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,b.PK PkId,c.PPosition, c.PSection,c.PDept,c.PDiv,c.PEmploymentStatus,b.EEmployeeIDNo, Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) from PayrollSystem.dbo.tbl_Profile a join PayrollSystem.dbo.tbl_Profile_IDNumber b on b.Pk = a.CurrentIDNumber join PayrollSystem.dbo.tbl_Profile_Action c on b.PK = c.PEmployeeNo ) a left join PayrollSystem.dbo.EEmploymentStatus b on a.PEmploymentStatus = b.EEmploymentStatus where a.Row = 1 and b.EActive = 1 ) a left join PayrollSystem.dbo.PPositionName b on a.PPosition = b.PPositionIDNo left join PayrollSystem.dbo.SSection c on a.PSection = c.SSectionID left join PayrollSystem.dbo.DDepartmental d on a.PDept = d.DDepartmentsNo left join PayrollSystem.dbo.EEmployeeDiv e on a.PDiv = e.PK inner join tbl_HolidayEmployees as he on he.EmpId = a.PkId inner join tbl_HolidayName as hn on hn.HolidayNamePk = he.HolidayNamePk WHERE hn.HolidayCntrlId = {lblHolidayCntrlId.Text}");

            try
            {
                employeeList.PrimaryKey = new DataColumn[] { employeeList.Columns["PkId"] };
            }
            catch (Exception)
            {


            }


            refreshEmployee();
        }
        private void LoadHolidayType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Text", typeof(string));

            dt.Rows.Add("Regular", "Regular");
            dt.Rows.Add("Special", "Special");

            clsTool.ComboBoxDataLoad(cmbHolidayType, dt, "Text", "Value");
        }

        private void LoadArea()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Text", typeof(string));

            dt.Rows.Add("SELLING AREA", "SELLING AREA");
            dt.Rows.Add("BACK OFFICE", "BACK OFFICE");

            clsTool.ComboBoxDataLoad(cmbDivision, dt, "Text", "Value");

            cmbDivision.SelectedIndex = -1;
        }
        private void tsAdd_Click(object sender, EventArgs e)
        {


            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);
            clsComponentControl.ClearValue(this);

            employeeList = clsBiometrics.dataList(strEmp);
            employeeList.PrimaryKey = new DataColumn[] { employeeList.Columns["PkId"] };
            lvEmployee.Enabled = true;
            refreshEmployee();

        }

        private void lvEmployee_ItemChecked(object sender, ItemCheckedEventArgs e)
        {


            if (lnkAll.Enabled == false)
            {
                return;
            }

            string PkId = e.Item.SubItems[6].Text.ToString();
            employeeList.Rows.Find(PkId)["selected"] = e.Item.Checked ? "1" : "0";

        }
        private void refreshEmployee()
        {
            lvEmployee.Items.Clear();
            if (employeeList.Rows.Count == 0)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            foreach (DataRow row in employeeList.Rows)
            {
                AddList(row);

            }
            this.Cursor = Cursors.Default;
        }
        private int GetCount()
        {
            int run = 0;
            foreach (DataRow row in employeeList.Rows)
            {
                if (row["selected"].ToString() != "0")
                {
                    run++;
                }
            }

            return run;
        }
        private void AddList(DataRow row)
        {
            if (row["Division"].ToString() == cmbDivision.Text)
            {

                if (row["Department"].ToString() == cmbDepartment.Text)
                {
                    if (row["Section"].ToString() == cmbSection.Text)
                    {
                        lvEmployee.Items.Add(singleItem(row));
                        return;
                    }

                    if (cmbSection.Text == "")
                    {
                        lvEmployee.Items.Add(singleItem(row));
                        return;
                    }

                }

                if (cmbDepartment.Text == "")
                {
                    lvEmployee.Items.Add(singleItem(row));
                    return;

                }

            }
        }
        private ListViewItem singleItem(DataRow row)
        {
            string firstData = $"{row["LastName"].ToString()}, {row["FirstName"].ToString()} {row["Middlename"].ToString()}";
            ListViewItem item = new ListViewItem(firstData); // First column as main item
            item.SubItems.Add(row["Department"].ToString());
            item.SubItems.Add(row["Section"].ToString());
            item.SubItems.Add(row["Position"].ToString());
            item.SubItems.Add(row["Division"].ToString());
            item.SubItems.Add("");
            item.SubItems.Add(row["PkId"].ToString());

            string strSelect = row["selected"].ToString();

            bool iselected = strSelect == "0" ? false : true;

            item.Checked = iselected;
            
            return item;
        }
        private void RefreshData()
        {
            string squery = $@"{sSelectSql} WHERE h.HolidayCntrlId  = {lblHolidayCntrlId.Text} ";

            DataRecord(squery);
        }
        private void DivisionChange()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Text", typeof(string));
            HashSet<string> addedDepartment = new HashSet<string>();
            foreach (ListViewItem item in lvEmployee.Items)
            {
                string Department = item.SubItems[1].Text;

                if (!addedDepartment.Contains(Department))
                {
                    dt.Rows.Add(Department, Department);
                    addedDepartment.Add(Department);
                }
            }

            clsTool.ComboBoxDataLoad(cmbDepartment, dt, "Text", "Value");
            cmbDepartment.SelectedIndex = -1;
        }
        private void DepartmentChange()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Text", typeof(string));
            HashSet<string> addedSection = new HashSet<string>();
            foreach (ListViewItem item in lvEmployee.Items)
            {
                string Section = item.SubItems[2].Text;
                if (!addedSection.Contains(Section))
                {
                    dt.Rows.Add(Section, Section);
                    addedSection.Add(Section);
                }
            }

            clsTool.ComboBoxDataLoad(cmbSection, dt, "Text", "Value");
            cmbSection.SelectedIndex = -1;
        }
        private void tsCancel_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);

            if (lblHolidayCntrlId.Text.Length > 0)
            {
                RefreshData();

                LoadRestDay(dtpHolidayDate.Value);
                LoadLeave(dtpHolidayDate.Value);
            }
            else
            {
                clsComponentControl.ClearValue(this);
                lvEmployee.Items.Clear();
            }

            cmbDivision.Enabled = true;
            cmbDepartment.Enabled = true;
            cmbSection.Enabled = true;
            lvEmployee.Enabled = false;
        }

        private void lnkAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool status = headCountCheckBox();
            CheckBoxItemMainFilter(status);
        }
        private void CheckBoxItemMainFilter(bool c)
        {
            foreach (ListViewItem item in lvEmployee.Items)
            {
                if (item.SubItems[4].Text == cmbDivision.Text)
                {
                    if (item.SubItems[2].Text == cmbDepartment.Text)
                    {
                        if (item.SubItems[3].Text == cmbSection.Text)
                        {
                            item.Checked = c;
                        }
                    }
                    else
                    {
                        item.Checked = c;
                    }
                }
            }
        }
        private void CheckBoxItemRDLeave(bool c)
        {
            foreach (ListViewItem item in lvEmployee.Items)
            {
                if (item.SubItems[5].Text != "")
                {
                    if (item.SubItems[4].Text == cmbDivision.Text)
                    {
                        if (item.SubItems[2].Text == cmbDepartment.Text)
                        {
                            if (item.SubItems[3].Text == cmbSection.Text)
                            {
                                item.Checked = c;
                            }
                        }
                        else
                        {
                            item.Checked = c;
                        }
                    }
                }
            }
        }

        private bool headCountCheckBox()
        {
            int nCheck = 0;
            int unCheck = 0;

            foreach (ListViewItem item in lvEmployee.Items)
            {
                if (item.Checked)
                {
                    nCheck++;
                }
                else
                {
                    unCheck++;
                }
            }

            if (nCheck > unCheck)
            {
                return false;
            }

            return true;
        }

        private bool headRDCountCheckBox()
        {
            int nCheck = 0;
            int unCheck = 0;
            foreach (ListViewItem item in lvEmployee.Items)
            {
                if (item.SubItems[5].Text != "")
                {

                    if (item.Checked)
                    {
                        nCheck++;
                    }
                    else
                    {
                        unCheck++;
                    }
                }
            }

            if (nCheck > unCheck)
            {
                return false;
            }

            return true;
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloading();
        }

        private void reloading()
        {
            if (cmbDivision.SelectedIndex == -1)
            {
                return;
            }
            if (cmbDivision.Enabled)
            {
                cmbDepartment.SelectedIndex = -1;
                cmbSection.SelectedIndex = -1;

                refreshEmployee();
                DivisionChange();
                LoadRestDay(dtpHolidayDate.Value);
                LoadLeave(dtpHolidayDate.Value);
            }
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbDepartment.Enabled)
            {
                cmbSection.SelectedIndex = -1;
                refreshEmployee();
                DepartmentChange();
                LoadRestDay(dtpHolidayDate.Value);
                LoadLeave(dtpHolidayDate.Value);
            }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.Enabled)
            {
                refreshEmployee();
                LoadRestDay(dtpHolidayDate.Value);
                LoadLeave(dtpHolidayDate.Value);
            }

        }

        private void lnkAllRD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool status = headRDCountCheckBox();
            CheckBoxItemRDLeave(status);
        }
        private void LoadLeave(DateTime date)
        {
            string query = "select EmpPK " +
                          "from tbl_LEAVE_UNDERTIME " +
                          "where nType = 1 and nPosted = 1 and nCancelled = 0 " +
                            "and EffectDates like '%" + date.ToString("MM/dd/yyyy") + "' ";

            DataTable dt = clsBiometrics.dataList(query);
            foreach (DataRow dr in dt.Rows)
            {
                UpdateRemarksUpdate(dr, "Leave");
            }
        }
        private void LoadRestDay(DateTime date)
        {
            string query = "declare @dateEffect date = '" + date + "'; " +
                           "select a.PK,isnull(b.ToDay,a.RestDay) Restday " +
                           "from ( " +
                               "/** normal restday **/ " +
                               "select a.PK,a.RestDay " +
                               "from ( " +
                                   "select a.PK,c.RestDay, " +
                                          "Row= ROW_NUMBER() over (partition by a.Pk order by c.EffectDate desc) " +
                                   "from ( " +
                                       "select b.PK,c.PEmploymentStatus, " +
                                           "Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) " +
                                       "from PayrollSystem.dbo.tbl_Profile_IDNumber b " +
                                       "join PayrollSystem.dbo.tbl_Profile_Action c " +
                                           "on b.PK = c.PEmployeeNo ) a " +
                                   "left join PayrollSystem.dbo.EEmploymentStatus b " +
                                       "on a.PEmploymentStatus = b.EEmploymentStatus " +
                                   "join Biometrics.dbo.EmployeeShifting c " +
                                       "on a.PK = c.EmpNo " +
                                   "where a.Row = 1 and b.Eactive = 1 " +
                                   "and cast(c.EffectDate as date) <= @dateEffect ) a " +
                               "where a.Row = 1 and a.RestDay = " +
                               "(case when (DATEPART(DW,@dateEffect) - 1) = 0 then 7 else (DATEPART(DW,@dateEffect) - 1) end)  ) a " +
                           "left join ( " +
                               "/**change shift**/ " +
                               "select dReqDateFrom,dReqDateTo,EmpPK, " +
                                   "FromDay = case when DATEPART(W,dReqDateFrom) = 1 " +
                                                      "then 7 else (DATEPART(W,dReqDateFrom) - 1) end, " +
                                   "ToDay = case when DATEPART(W,dReqDateTo) = 1 " +
                                                      "then 7 else (DATEPART(W,dReqDateTo) -1) end " +
                               "from tbl_CHANGERESTDAY " +
                               "where cast(dReqDateTo as date) = cast(@dateEffect as date) " +
                               "and nPosted = 1 and nCancelled = 0 " +
                               "union all " +
                               "select dReqDateFrom,dReqDateTo,EmpPKWith, " +
                                   "FromDay = case when DATEPART(W,dExDateFrom) = 1 " +
                                                      "then 7 else (DATEPART(W,dExDateFrom) - 1) end, " +
                                   "ToDay = case when DATEPART(W,dExDateTo) = 1 " +
                                                      "then 7 else (DATEPART(W,dExDateTo) -1) end " +
                               "from tbl_CHANGERESTDAY " +
                               "where cast(dReqDateFrom as date) = cast(@dateEffect as date) " +
                               "and nPosted = 1 and nCancelled = 0 and EmpPKWith != 0 " +
                           ") b on a.PK = b.EmpPK ";

            DataTable dt = clsBiometrics.dataList(query);

            foreach (DataRow dr in dt.Rows)
            {
                UpdateRemarksUpdate(dr, "Restday");
            }

        }


        private void UpdateRemarksUpdate(DataRow dr, string Remarks)
        {
            foreach (ListViewItem lv in lvEmployee.Items)
            {

                if (lv.SubItems[6].Text == dr[0].ToString())
                {
                    lv.SubItems[5].Text = Remarks;
                    return;
                }
            }
        }
        private void dtpHolidayDate_ValueChanged(object sender, EventArgs e)
        {
            reloading();
        }
        private void tsSave_Click(object sender, EventArgs e)
        {

            if (txtHolidayName.Text.Length <= 3) // remarks
            {
                // Data Required
                clsMessage.MessageShowWarning("Holiday name required");
                return;
            }
            if (GetCount() == 0)
            {
                clsMessage.MessageShowWarning("No employee selected");
                return;
            }

            object ID = null;

            if (lblHolidayCntrlId.Text == "")
            {
                ID = clsBiometrics.ExecuteScalarQuery($"INSERT INTO tbl_Holiday (Remarks,Dates,DateCreated,CreatedBy) VALUES ('',{clsMisc.SQL_Date(dtpHolidayDate)},'{clsDateTime.NowDay()}','{clsAccessControl.gsUsername}') ");

            }
            else
            {
                ID = lblHolidayCntrlId.Text;
            }

            if (ID != null)
            {

                object HN_ID = null;

                var data = clsBiometrics.GetFirstRecord($"SELECT TOP 1 HolidayNamePk FROM tbl_HolidayName WHERE HolidayCntrlId = {ID}");

                if (data == null)
                {
                    HN_ID = clsBiometrics.ExecuteScalarQuery($"INSERT INTO tbl_HolidayName (HolidayCntrlId,HolidayName,HolidayDate,HolidayType) VALUES ({ID},'{txtHolidayName.Text}',{clsMisc.SQL_Date(dtpHolidayDate)},'{cmbHolidayType.Text}') ");
                }
                else
                {
                    HN_ID = int.Parse(data["HolidayNamePk"].ToString());
                    clsBiometrics.ExecuteNonQuery($"UPDATE tbl_HolidayName Set HolidayName = '{txtHolidayName.Text}', HolidayDate = {clsMisc.SQL_Date(dtpHolidayDate)}, HolidayType='{cmbHolidayType.Text}' Where HolidayNamePk = {HN_ID} ");
                }

                // Registered Employees
                foreach (DataRow row in employeeList.Rows)
                {
                    string strEmployeeId = row["PkId"].ToString();
                    string strIsHolidayDuty = row["selected"].ToString();
                    Application.DoEvents();
                    if (clsBiometrics.RecordExists($"SELECT TOP 1 * FROM tbl_HolidayEmployees WHERE HolidayNamePk = {HN_ID} and EmpId = {strEmployeeId} ") == false)
                    {
                        clsBiometrics.ExecuteNonQuery($"INSERT INTO tbl_HolidayEmployees (HolidayNamePk,EmpId,IsHolidayDuty) VALUES ({HN_ID},{strEmployeeId},{strIsHolidayDuty}); ");
                    }
                    else
                    {
                        clsBiometrics.ExecuteNonQuery($"UPDATE tbl_HolidayEmployees SET IsHolidayDuty = {strIsHolidayDuty} WHERE HolidayNamePk={HN_ID} and EmpId = {strEmployeeId}; ");
                    }
                }

                lblHolidayCntrlId.Text = ID.ToString();
                tsCancel.PerformClick();
            }
        }

        private void tsFirst_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql} ORDER BY h.HolidayCntrlId ASC ";
            DataRecord(squery);
        }
        private void DataRecord(string squery)
        {
            var data = clsBiometrics.GetFirstRecord(squery);
            if (data != null)
            {
                clsComponentControl.AssignValue(this, data);
                EmployeeRecord();
            }
        }
        private void tsBack_Click(object sender, EventArgs e)
        {
            if (lblHolidayCntrlId.Text == "")
            {
                tsFirst.PerformClick();
                return;
            }
            string squery = $@"{sSelectSql} WHERE h.HolidayCntrlId < {lblHolidayCntrlId.Text} ORDER BY h.HolidayCntrlId DESC ";
            DataRecord(squery);
        }

        private void tsNext_Click(object sender, EventArgs e)
        {
            if (lblHolidayCntrlId.Text == "")
            {
                tsLast.PerformClick();
                return;
            }
            string squery = $@"{sSelectSql} WHERE h.HolidayCntrlId > {lblHolidayCntrlId.Text} ORDER BY h.HolidayCntrlId ASC ";
            DataRecord(squery);
        }

        private void tsLast_Click(object sender, EventArgs e)
        {
            string squery = $@"{sSelectSql} ORDER BY h.HolidayCntrlId DESC ";
            DataRecord(squery);
        }

        private void tsFind_Click(object sender, EventArgs e)
        {

            frmFind.ShowDialog();
            if (frmFind.isYes == true)
            {
                frmFind.isYes = false;
                clsComponentControl.ClearValue(this);
                lblHolidayCntrlId.Text = frmFind.PK;
                RefreshData();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            if (lnkAll.Enabled == false)
            {
                return;

            }

        }

        private void cmbHolidyType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);
    

        
            lvEmployee.Enabled = true;
     
        }
        private bool isCheckboxClicked = false;
        private void lvEmployee_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            

   
        }

        private void lvEmployee_MouseDown(object sender, MouseEventArgs e)
        {

            
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            if (lblHolidayCntrlId.Text == "")
            {
                clsMessage.MessageShowWarning("File not found");
                return;
            }

            cryHoliday  cryHoliday= new cryHoliday();
            ReportDocument rpt = reports.LoadReportWithConnection(cryHoliday, false);

            rpt.SetParameterValue("PK", lblHolidayCntrlId.Text);

          

            FrmReportView frm = new FrmReportView(rpt, "Holiday Print");

            clsMenu.CloseForm(frm);

            clsMenu.ShowForm(frm);
        }
    }
}
