using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingII
{
    class clsBiometrics
    {
        public static readonly string DSN_BIO_SERVER = "DSN_BIO_SERVER";

        public static OdbcConnection GetConnection()
        {
            string UID = clsSetting.GetSetting("BIO", "USERNAME");
            string PWD = clsSetting.GetSetting("BIO", "PASSWORD");
            var connectionString = $"DSN={DSN_BIO_SERVER};UID=" + UID + ";PWD=" + PWD + ";";

            return new OdbcConnection(connectionString);
        }

        public static bool ConnectionTest()
        {
            bool isConnect = false;
            try
            {
                using (OdbcConnection conn = GetConnection())
                {
                    conn.Open();

                    conn.Close();
                    isConnect = true;
                }
            }
            catch (Exception)
            {
                isConnect = false;


            }

            return isConnect;
        }
        public static void CryLogin(CrystalDecisions.CrystalReports.Engine.Table table)
        {

   
            var SERVER = DSN_BIO_SERVER;

            var database = clsSetting.GetSetting("BIO", "DATABASE");
            string UID = clsSetting.GetSetting("BIO", "USERNAME");
            string PWD = clsSetting.GetSetting("BIO", "PASSWORD");

            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = SERVER,
                DatabaseName = database,
                UserID = UID,
                Password = PWD
            };


            TableLogOnInfo logOnInfo = table.LogOnInfo;
            logOnInfo.ConnectionInfo = connectionInfo;
            table.ApplyLogOnInfo(logOnInfo);


        }
        public static DataTable dataList(string query)
        {
            DataTable dataTable = new DataTable();
            try

            {
                using (OdbcConnection connection = GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                clsSetting.SetSetting("CONNCTED", "STATUS", "false");
                MessageBox.Show(ex.Message, "Error message");
                Application.Exit();
            }

            return dataTable;
        }
        public static object ExecuteScalarQuery(string query)
        {
            object result = null;
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (OdbcConnection connection = GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        command.ExecuteScalar();
                    }

                    using (OdbcCommand command = new OdbcCommand("SELECT SCOPE_IDENTITY()", connection))
                    {
                        result = command.ExecuteScalar();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Application.DoEvents();
            }

            return result;
        }
        public static int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            try
            {
                using (OdbcConnection connection = GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Application.DoEvents();
            }

            return rowsAffected;
        }
        public static bool ExecuteNonQueryBool(string query)
        {
            bool isSuccess = false;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            try
            {
                using (OdbcConnection connection = GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {

                        command.ExecuteNonQuery();
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Application.DoEvents();
            }

            return isSuccess;
        }
        public static Dictionary<string, object> GetFirstRecord(string query)
        {
            Dictionary<string, object> result = null;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                using (OdbcConnection connection = GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Read only the first record
                        {
                            result = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++) // Loop through all columns
                            {
                                result[reader.GetName(i)] = reader.GetValue(i); // Store column name & value
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
            finally
            { 
                Cursor.Current = Cursors.Default;
                Application.DoEvents();
            }

            return result;
        }
        public static bool RecordExists(string query)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            try
            {
                using (OdbcConnection connection = GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read(); // Returns true if a record exists, false otherwise
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; // Return false in case of an error
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Application.DoEvents();
            }

        }

    }
}
