using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TimeKeepingII
{
    class clsDateTime
    {


        public static DateTime getEmpty()
        {
            return DateTime.ParseExact($"1900-01-01 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        public static DateTime GetDefault()
        {
            return DateTime.ParseExact($"{NowDay().ToString("yyyy-MM-dd")} 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        public static string LastModify()
        {
            return DateTime.Now.ToString() + " " + clsAccessControl.gsUsername;
        }
        public static DateTime NowDay()
        {
            return DateTime.Now;
        }
        public static int NowYear()
        {
            return DateTime.Now.Year;
        }
        public static int GetDiffCountDays(DateTime start, DateTime end)
        {
            TimeSpan difference = end - start;
            int days = difference.Days;
            return days;
        }

        public static int GetDiffCountMinutes(DateTime start, DateTime end)
        {
            TimeSpan difference = end - start;
            int Mins = difference.Minutes;
            return Mins;
        }
        public static string TimeDisplay(DateTime start, DateTime end)
        {


            TimeSpan diff = end - start;

            string formatted = $"{(int)diff.TotalHours} hrs. {diff.Minutes} min.";

            return formatted;
        }
        public static string DateRangeOutput(DateTime startDate, DateTime endDate)
        {
            List<string> dateStrings = new List<string>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dateStrings.Add(date.ToString("M/d/yyyy"));
            }

            string result = string.Join(",", dateStrings);
            return result;
        }
        public DateTime ServerDate()
        {
            var resultData = clsBiometrics.GetFirstRecord("select GETDATE() SystemDate ");
            return Convert.ToDateTime(resultData["SystemDate"]);
        }
    }
}
