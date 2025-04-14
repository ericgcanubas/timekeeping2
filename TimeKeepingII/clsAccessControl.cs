using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingII
{
    class clsAccessControl
    {
        public static string gsUsername;
        public static string gsPassword;

        public static bool AccessRight(string strModule = "", string strAction = "")
        {
            if ((string)strModule == null)
            {
                return true;
            }

            string[] AccArr;
            var data = clsPayrollSystem.GetFirstRecord($@"SELECT TOP 1
                       [Applicant]
                      ,[Personnel]
                      ,[PersonnelAssID]
                      ,[ActionMemo]
                      ,[Deactivation]
                      ,[PersonnelReport]
                      ,[Merits_Dem]
                      ,[EmploymentStat]
                      ,[Dept]
                      ,[Sect]
                      ,[Post]
                      ,[Supplier]
                      ,[Charge_Penalty]
                      ,[Journal]
                      ,[Charge_Rep]
                      ,[Transactions]
                      ,[TransactionsWeekly]
                      ,[Govt_Tables]
                      ,[Misc]
                      ,[Utility]
                      ,[User_Rights]
                      ,[Allowance]
                      ,[TimeSummary]
                      ,[TimeSummaryAdjustment]
                      ,[HoldSalary2]
                      ,[HoldSalary]
                      ,[ReleaseSalary]
                      ,[ClearingRate]
                      ,[SecurityOTRate]
                      ,[AssignSched]
                      ,[Holidays]
                      ,[Sale_Time]
                      ,[ExtendedHour]
                      ,[ShiftingSchedule]
                      ,[BioUtility]
                      ,[PRW]
                      ,[ChangeRD]
                      ,[ChangeShift]
                      ,[Leave]
                      ,[AdjustTime]
                      ,[Suspension]
                      ,[Overtime]
                      ,[Clearing]
                      ,[Undertime]
                      ,[TravelDuty]
                      ,[BioReports]
                      ,[SHActive]
                      ,[SHINActive]
                      ,[SHPeriod]
                      ,[AWOLEmployee]
                      ,[UserSetting]
                      ,[PayCard]

                       FROM UserAccount_New WHERE (username='{gsUsername}') and (password='{gsPassword}')");


            switch ((string)strModule.ToUpper())
            {
                case "TIME RECORD":
                    AccArr = data["BioReports"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "REPOST TIME": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "TIME RECORD/SUMMARY": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "UPDATE SUMMARY": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "GENERATE MIDNIGHT": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }

                case "TIME SUMMARY MANAGERIAL":
                    AccArr = data["TimeSummary"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "CHK HOURS": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "TIME SUMMARY ADJUSTMENT":
                    AccArr = data["TimeSummaryAdjustment"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "CHANGE SHIFTING":
                    AccArr = data["ChangeShift"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "CHANGE DAYOFF":
                    AccArr = data["ChangeRD"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "PERMISSION TO WORK":
                    AccArr = data["PRW"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "ADJUST TIME":
                    AccArr = data["AdjustTime"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "TRAVEL DUTY":
                    AccArr = data["TravelDuty"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "UNDERTIME":
                    AccArr = data["Undertime"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "LEAVE":
                    AccArr = data["Leave"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "SUSPENSION":
                    AccArr = data["Suspension"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        case "POST": return AccArr[4].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "CLEARING":
                    AccArr = data["Clearing"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "OVERTIME":
                    AccArr = data["Overtime"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "SHIFTING SCHEDULE":
                    AccArr = data["ShiftingSchedule"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "MIDNIGHT SALE":
                    AccArr = data["Sale_Time"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "HOLIDAYS":
                    AccArr = data["Holidays"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "OVERTIME / CLEARING RATE":
                    AccArr = data["ClearingRate"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "SECURITY OVERTIME RATE":
                    AccArr = data["SecurityOTRate"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "PAY CARD":
                    AccArr = data["Paycard"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;
                    }
                case "EXTENDED HOUR":
                    AccArr = data["ExtendedHour"].ToString().Split('/');
                    switch (strAction)
                    {
                        case "OPEN": return AccArr[0].ToString().Trim() == "1" ? true : false;
                        case "ADD": return AccArr[1].ToString().Trim() == "1" ? true : false;
                        case "EDIT": return AccArr[2].ToString().Trim() == "1" ? true : false;
                        case "DELETE": return AccArr[3].ToString().Trim() == "1" ? true : false;
                        default: return false;

                    }
            }
            return false;

        }
    }
}
