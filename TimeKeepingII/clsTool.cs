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
        public static string getWeekName(int Value)
        {
            string weekName = "";
            switch (Value)
            {
                case 1: weekName = "MONDAY"; break;
                case 2: weekName = "TUESDAY"; break;
                case 3: weekName = "WEDNESDAY"; break;
                case 4: weekName = "THURSDAY"; break;
                case 5: weekName = "FRIDAY"; break;
                case 6: weekName = "SATURDAY"; break;
                case 7: weekName = "SUNDAY"; break;
                default:
                    break;
            }

            return weekName;
        }
        public static int getWeekValue(string Name)
        {
            int weekValue = 0;
            switch (Name.ToUpper().Trim())
            {
                case "MONDAY": weekValue = 1; break;
                case "TUESDAY": weekValue = 2; break;
                case "WEDNESDAY": weekValue = 3; break;
                case "THURSDAY": weekValue = 4; break;
                case "FRIDAY": weekValue = 5; break;
                case "SATURDAY": weekValue = 6; break;
                case "SUNDAY": weekValue = 7; break;
                default:
                    break;
            }


            return weekValue;
        }
        public static int getDayWeekValue(DateTimePicker dt)
        {   
            if(dt.Checked == false)
            {
                return 0;
            }

            int W = ((int)dt.Value.DayOfWeek);

            if (W == 0)
            {
                return 7;
            }
            else
            {
                return W;
            }
        }
    }
}
