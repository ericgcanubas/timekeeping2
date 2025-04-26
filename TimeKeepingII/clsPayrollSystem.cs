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
    class clsPayrollSystem
    {
        public static readonly string DSN_PAYROL_SERVER = "DSN_PAYROL_SERVER";
        private static readonly string configFilePath = "config.ini";
        public static Dictionary<string, string> getConnectionSource()
        {
            return ConfigReader.ReadConfig(configFilePath);
        }
        public static OdbcConnection GetConnection()
        {
          
            var connectionString = $"DSN={DSN_PAYROL_SERVER};UID=sa;PWD=;";
            return new OdbcConnection(connectionString);
        }
        public static OdbcConnection GetConnectionTest()
        {

          
            var connectionString = $"DSN={DSN_PAYROL_SERVER};UID=sa;PWD=;";
            return new OdbcConnection(connectionString);
        }
        public static bool ConnectionTest()
        {
            bool isConnect = false;
            try
            {
                using (OdbcConnection conn = GetConnectionTest())
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

            var config = getConnectionSource();

            var server = DSN_PAYROL_SERVER;
            var database = "PayrollSystem"; 

            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = server,
                DatabaseName = database,
                UserID = "sa",
                Password = ""
            };


            TableLogOnInfo logOnInfo = table.LogOnInfo;
            logOnInfo.ConnectionInfo = connectionInfo;
            table.ApplyLogOnInfo(logOnInfo);


        }
        public static DataTable dataList(string query)
        {
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
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
                MessageBox.Show(ex.Message, "Error message");
                Application.Exit();
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Restore default cursor
            }

            return dataTable;
        }

        public static int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            Cursor.Current = Cursors.WaitCursor;
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
                Application.Exit();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


            return rowsAffected;
        }

        public static Dictionary<string, object> GetFirstRecord(string query)
        {
            Dictionary<string, object> result = null;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (OdbcConnection connection = clsPayrollSystem.GetConnection())
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
            }

            return result;
        }
        public static bool RecordExists(string query)
        {
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
                Application.Exit();
                return false; // Return false in case of an error
            }
        }
    }
}
