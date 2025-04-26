using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingII
{
    class clsGlobal
    {
        public static int UserID;

        public static string EmployeeFind = $@"SELECT PK, 
                        EEmployeeIDNo, 
                        ELastName + ',  ' + EFirstName + '  ' + EMiddleName AS Name, ELastName, 
                        ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS EActive, 
                        ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) AS Hired
                        FROM tbl_Profile_IDNumber 
                        WHERE (ISNULL((SELECT TOP 1 tbl_Profile_Action.PHired FROM tbl_Profile_Action WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND 
                        (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) <> 4)  
                        AND (ISNULL((SELECT TOP 1 EEmploymentStatus.EActive FROM tbl_Profile_Action LEFT OUTER JOIN EEmploymentStatus ON tbl_Profile_Action.PEmploymentStatus = dbo.EEmploymentStatus.EEmploymentStatus WHERE (tbl_Profile_Action.PEmployeeNo = tbl_Profile_IDNumber.PK) AND (tbl_Profile_Action.PEffectivityDate <= CONVERT(datetime, CONVERT(char(6), GETDATE(), 12), 102)) ORDER BY tbl_Profile_Action.PEffectivityDate DESC), 1) = 1) 
                        ORDER BY ELastName + ',  ' + EFirstName + '  ' + EMiddleName, EEmployeeIDNo
                        ";
    }
}
