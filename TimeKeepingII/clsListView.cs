using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsListView
    {
        public static void LoadListView(ListView listView, DataTable dataTable)
        {

            if (dataTable != null)
            {
                listView.Items.Clear();
                listView.Columns.Clear();

                foreach (DataColumn column in dataTable.Columns)
                {
                    listView.Columns.Add(column.ColumnName,0);
                }

                if(listView.Columns.Count > 0 )
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string firstData = row[0].ToString();
                        ListViewItem item = new ListViewItem(firstData); // First column as main item
                        for (int i = 1; i < dataTable.Columns.Count; i++)
                        {
                            item.SubItems.Add(row[i].ToString()); // Remaining columns as subitems
                        }
                        listView.Items.Add(item);
                    }
                    AutoResizeColumns(listView);
                }
             
            }
         
        }

        public static void AutoResizeColumns(ListView listView)
        {
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = -2; // Auto-size to fit content
            }
        }
    }
}
