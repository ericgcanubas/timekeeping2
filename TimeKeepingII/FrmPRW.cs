using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    public partial class FrmPRW : Form
    {

        FrmFind frmFind = new FrmFind($@"SELECT TOP 1000 PRW_nID as ID,sEmpName ,nCtrlNo,dTransDate,sReason FROM [tbl_PRW_NEW]  ");
        const string sSelectSql = "SELECT TOP 1 [PRW_nID] ,[nCtrlNo] ,[dTransDate] ,[nType] ,[EmpPK] ,[sEmpName] ,[sSection] ,[sBrand] ,[sALDates] ,[sReasons] ,[dStarting] ,[dEnding] ,[sATDNo] ,[nAmount] ,[sTransNo] ,[sVerBy] ,[sRecBy] ,[sNotBy1] ,[sAppBy] ,[sRelBy] ,[nDiscActType] ,[sSuspensionFor] ,[sSuspensionSked] ,[dTerminationDate] ,[sRemarks] ,[sPreBy] ,[sNotBy2] ,[sAppBy2] ,[sConfrm] ,[nPosted] ,[sLastUpdatedBy] ,[sNoOfDaysMins] ,[nFreq] FROM [tbl_PRW_NEW] ";
        DataTable dtEmployee;
        public FrmPRW()
        {
            InitializeComponent();
        }


    }
}
