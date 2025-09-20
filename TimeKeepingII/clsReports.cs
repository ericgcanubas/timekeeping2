using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeepingII
{
   public  class clsReports
    {
        public  ReportDocument LoadReportWithConnection(ReportDocument report, bool isPayroll )
        {
            string _ServerName;
            string _DatabaseName;
            string _UserID;
            string _Password;

            if (isPayroll)
            {
                _ServerName = clsSetting.GetSetting("PAYROLL", "SERVER");
                _DatabaseName  = clsSetting.GetSetting("PAYROLL", "DATABASE");
                _UserID = clsSetting.GetSetting("PAYROLL", "USERNAME");
                _Password = clsSetting.GetSetting("PAYROLL", "PASSWORD");
            }
            else
            {
                _ServerName = clsSetting.GetSetting("BIO", "SERVER");
                _DatabaseName = clsSetting.GetSetting("BIO", "DATABASE");
                _UserID = clsSetting.GetSetting("BIO", "USERNAME");
                _Password = clsSetting.GetSetting("BIO", "PASSWORD");
            }




            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = _ServerName,
                DatabaseName = _DatabaseName,
                UserID = _UserID,
                Password = _Password,
                IntegratedSecurity = false
            };

            // Apply to main report
            foreach (Table table in report.Database.Tables)
            {
                TableLogOnInfo logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(logOnInfo);
                table.Location = table.Name;
            }

            // Apply to subreports
            foreach (Section section in report.ReportDefinition.Sections)
            {
                foreach (ReportObject obj in section.ReportObjects)
                {
                    if (obj is SubreportObject subreport)
                    {
                        ReportDocument subDoc = subreport.OpenSubreport(subreport.SubreportName);
                        foreach (Table table in subDoc.Database.Tables)
                        {
                            TableLogOnInfo logOnInfo = table.LogOnInfo;
                            logOnInfo.ConnectionInfo = connectionInfo;
                            table.ApplyLogOnInfo(logOnInfo);
                            table.Location = table.Name;
                        }
                    }
                }
            }

            return report;
        }
    }
}
