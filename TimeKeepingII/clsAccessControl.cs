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

        public bool AccessRight(string strModule, string strAction)
        {

            var data = clsPayrollSystem.GetFirstRecord($@"SELECT TOP 1 [Applicant]
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



            foreach (var row in data)
            {
               if (row.Key == strModule)
                {
                    var ACCSPLIT = row.Value.ToString().Split('/');


                }


            }




                return false;

        }
    }
}
