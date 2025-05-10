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

            string strSelect = $@"SELECT PK, 
                                    EEmployeeIDNo,
                                    ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS Name,
                                    ELastName, 
                                    ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS EActive, 
                                    ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS Hired
                                    FROM tbl_Profile_IDNumber 
                                    WHERE PK = {PK} ";

            var empData = clsPayrollSystem.GetFirstRecord(strSelect);

            if (empData != null)
            {
                lblEMPLOYEE_NO.Text = empData["EEmployeeIDNo"].ToString();
                lblEmployeeName.Text = empData["Name"].ToString();
                lblEmpPK.Text = empData["PK"].ToString();

                this.Text = $"{lblEmployeeName.Text}";



                Bitmap photo = null;
                object image = GetImage(int.Parse(PK));
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

            result = resultData["Photo"];
            return result;
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
