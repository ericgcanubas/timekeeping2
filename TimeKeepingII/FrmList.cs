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
    public partial class FrmList : Form
    {
        DataTable dataList;
        public string VALUE = "";
        public FrmList( DataTable dt)
        {
            InitializeComponent();
            this.dataList = dt;
        }

        private void FrmList_Load(object sender, EventArgs e)
        {
            SearchLoad();
        }
        private void SearchLoad()
        {

            DataTable newData = dataList.Clone();
            foreach (DataRow data in dataList.Rows)
            {
                // Adjust column index or name according to your data
                if (data.ItemArray.Any(field => field.ToString().IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    newData.ImportRow(data);
                }
            }


            clsListView.LoadListView(lvList, newData);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchLoad();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            VALUE = "";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            try
            {
                VALUE = lvList.FocusedItem.Text;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
       

        }
    }
}
