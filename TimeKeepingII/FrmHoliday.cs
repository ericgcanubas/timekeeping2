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
    public partial class FrmHoliday : Form
    {

        string strEmp = "select 0 AS selected, a.* ,isnull(b.PPositionName,'')Position, isnull(c.SSectionName,'')Section, isnull(d.DDepartment,'')Department,e.Description Division from ( select a.ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,a.PkId,a.PPosition, a.PSection,a.PDept,a.PDiv,a.PEmploymentStatus, isnull(b.EActive,2)EActive,a.EEmployeeIDNo from ( select a.PK ProfileId,a.LastName,a.FirstName,a.MiddleName, a.BirthDate,a.Age,a.CurrAddress,b.PK PkId,c.PPosition, c.PSection,c.PDept,c.PDiv,c.PEmploymentStatus,b.EEmployeeIDNo, Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) from PayrollSystem.dbo.tbl_Profile a join PayrollSystem.dbo.tbl_Profile_IDNumber b on b.Pk = a.CurrentIDNumber join PayrollSystem.dbo.tbl_Profile_Action c on b.PK = c.PEmployeeNo ) a left join PayrollSystem.dbo.EEmploymentStatus b on a.PEmploymentStatus = b.EEmploymentStatus where a.Row = 1 and b.EActive = 1 ) a left join PayrollSystem.dbo.PPositionName b on a.PPosition = b.PPositionIDNo left join PayrollSystem.dbo.SSection c on a.PSection = c.SSectionID left join PayrollSystem.dbo.DDepartmental d on a.PDept = d.DDepartmentsNo left join PayrollSystem.dbo.EEmployeeDiv e on a.PDiv = e.PK where 1=1 ";
        public DataTable employeeList;

        public FrmHoliday()
        {
            InitializeComponent();
        }

        private void FrmHoliday_Load(object sender, EventArgs e)
        {


            clsComponentControl.HeaderMenu(tsHeaderControl, true);
            clsComponentControl.ObjectEnable(this, false);
            clsComponentControl.ClearValue(this);

            LoadHolidayType();
            LoadArea();

        }
        private void LoadHolidayType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Text", typeof(string));

            dt.Rows.Add("Regular", "Regular");
            dt.Rows.Add("Special", "Special");

            clsTool.ComboBoxDataLoad(cmbHolidyType, dt, "Text", "Value");
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

        private void LoadEmployeeList()
        {

            clsListView.LoadListView(lvEmployee, employeeList);
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {


            clsComponentControl.HeaderMenu(tsHeaderControl, false);
            clsComponentControl.ObjectEnable(this, true);
            clsComponentControl.ClearValue(this);

            employeeList = clsBiometrics.dataList(strEmp);
            employeeList.PrimaryKey = new DataColumn[] { employeeList.Columns["ProfileID"] };

            refreshEmployee();

            //clsListView.AutoResizeColumns(lvEmployee);
        }

        private void lvEmployee_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string profileID = e.Item.SubItems[6].Text.ToString();
            employeeList.Rows.Find(profileID)["selected"] = e.Item.Checked ? "1" : "0";

        }
        private void refreshEmployee()
        {
            lvEmployee.Items.Clear();
            foreach (DataRow row in employeeList.Rows)
            {
                if (row["Division"].ToString() == cmbDivision.Text)
                {

                    if (row["Department"].ToString() == cmbDepartment.Text)
                    {
                        if (row["Section"].ToString() == cmbSection.Text)
                        {
                            lvEmployee.Items.Add(singleItem(row));
                        }

                        if (cmbSection.Text == "")
                        {
                            lvEmployee.Items.Add(singleItem(row));
                        }


                    }

                    if (cmbDepartment.Text == "")
                    {
                        lvEmployee.Items.Add(singleItem(row));

                    }

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
            item.SubItems.Add(row["ProfileID"].ToString());

            if (row["selected"].ToString() == "0")
            {
                item.Checked = false;
            }
            else
            {
                item.Checked = true;
            }

            return item;
        }
        private void RefreshData()
        {

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

            if (lblLU_nID.Text.Length > 0)
            {

                RefreshData();
            }
            else
            {
                clsComponentControl.ClearValue(this);
                lvEmployee.Items.Clear();
            }

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
        private void Uncheck()
        {
            foreach (ListViewItem item in lvEmployee.Items)
            {
                item.Checked = true;
            }
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
            }
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbDepartment.Enabled)
            {
                cmbSection.SelectedIndex = -1;
                refreshEmployee();
                DepartmentChange();
            }

        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.Enabled)
            {
                refreshEmployee();
            }

        }

        private void lnkAllRD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool status = headRDCountCheckBox();
            CheckBoxItemRDLeave(status);
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

            }

        }

        private void dtpHolidayDate_ValueChanged(object sender, EventArgs e)
        {
            reloading();

        }

        private void tsSave_Click(object sender, EventArgs e)
        {

        }

        private void tsFirst_Click(object sender, EventArgs e)
        {

        }

        private void tsBack_Click(object sender, EventArgs e)
        {

        }

        private void tsNext_Click(object sender, EventArgs e)
        {

        }

        private void tsLast_Click(object sender, EventArgs e)
        {

        }

        private void tsFind_Click(object sender, EventArgs e)
        {

        }

        private void tsClose_Click(object sender, EventArgs e)
        {

        }
    }
}
