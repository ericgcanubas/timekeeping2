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
            return  DateTime.ParseExact($"1900-01-01 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        public static DateTime GetDefault()
        {
            return DateTime.ParseExact($"{NowDay().ToString("yyyy-MM-dd")} 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        public static string LastModify()
        {
            return  DateTime.Now.ToString() + " " + clsAccessControl.gsUsername;
        }
        public static DateTime NowDay()
        {
            return DateTime.Now;
        }
        public static int NowYear()
        {
            return DateTime.Now.Year;
        }
    }
}
