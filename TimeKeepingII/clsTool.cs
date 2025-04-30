using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsTool
    {
        public static void ComboBoxDataLoad(ComboBox cmb, DataTable dt, string DisplayMember, string ValueMember)
        {
            cmb.DataSource = dt.Copy();
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
        }

        public static DataTable WeekDayList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(int));
            dt.Columns.Add("Text", typeof(string));

            dt.Rows.Add(1, "MONDAY");
            dt.Rows.Add(2, "TUESDAY");
            dt.Rows.Add(3, "WEDNESDAY");
            dt.Rows.Add(4, "THURSDAY");
            dt.Rows.Add(5, "FRIDAY");
            dt.Rows.Add(6, "SATURDAY");
            dt.Rows.Add(7, "SUNDAY");

            return dt;
        }
    }
}
