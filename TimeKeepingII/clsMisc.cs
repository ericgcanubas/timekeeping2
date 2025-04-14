using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace TimeKeepingII
{
    class clsMisc
    {
        public static string FormatSQL(string str)
        {
            return str.Replace("'", "`");
        }

        public static bool IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 1000); // Google DNS
                    return reply != null && reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string Encrypt(string input)
        {
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int asciiValue = (int)input[i];
                int modifier = (i % 2 == 0) ? -1 : 1;
                asciiValue += modifier * ((i + 1) % 8);
                encrypted.Append((char)asciiValue);
            }

            return encrypted.ToString();
        }

        public static string Decrypt(string input)
        {
            StringBuilder decrypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int asciiValue = (int)input[i];
                int modifier = (i % 2 == 0) ? -1 : 1;
                asciiValue -= modifier * ((i + 1) % 8);
                decrypted.Append((char)asciiValue);
            }

            return decrypted.ToString();
        }


        public static string[] strColumn(string query)
        {
            string[] columns = null;
            Match match = Regex.Match(query, @"SELECT\s+(?:TOP\s+\d+\s+)?(.+?)\s+FROM", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                string columnPart = match.Groups[1].Value;

                columns = columnPart
                    .Split(',')
                    .Select(c => c.Trim())
                    .ToArray();

                Console.WriteLine("Extracted columns:");
                foreach (string col in columns)
                {
                    Console.WriteLine(col);
                }

                // Now columns[] contains all expected column expressions:
                // - ShiftingSchedule.PK
                // - ShiftingSchedule.ShiftName
                // - ShiftingType.ShiftType AS ShiftTypeName
            }
            else
            {
                Console.WriteLine("Could not parse SELECT columns.");
            }

            return columns;
        }
           
    }
}
