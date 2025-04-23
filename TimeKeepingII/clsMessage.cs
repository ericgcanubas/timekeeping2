using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TimeKeepingII
{
    class clsMessage
    {

        public static void MessageShowInfo(string strMsg)
        {
            MessageBox.Show(strMsg, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageShowWarning(string strMsg)
        {
            MessageBox.Show(strMsg, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageShowError(string strMsg)
        {
            MessageBox.Show(strMsg, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool MessageQuestion(string strMesage)
        {

            DialogResult result = MessageBox.Show(strMesage, "Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                
            if(result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        public static bool MessageQuestionWarning(string strMesage)
        {

            DialogResult result = MessageBox.Show(strMesage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }
    }
}
