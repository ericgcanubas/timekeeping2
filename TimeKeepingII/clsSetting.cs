using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace TimeKeepingII
{
    class clsSetting
    {

        public static void SetSetting(string strSECTION , string strKey ,  string strValue)
        {
            Interaction.SaveSetting("TIMEKEEPING_SYSTEM", strSECTION, strKey, strValue);
        }
        public static string GetSetting(string strSECTION, string strKey)
        {
            return Interaction.GetSetting("TIMEKEEPING_SYSTEM", strSECTION, strKey).ToString();
        }
    }
}
