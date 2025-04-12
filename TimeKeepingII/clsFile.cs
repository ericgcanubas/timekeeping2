using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TimeKeepingII
{
    class clsFile
    {

        public static void makeConfig(string BioServer, string PayrollServer)
        {
            string configFile = "config.ini";
            string defaultConfig = $@"


                    [Database]
                    BIO_SERVER={BioServer}    
                    PAYROLL_SERVER={PayrollServer}
        
                    [users]
                    savelogin=
                
                    ";

            File.WriteAllText(configFile, defaultConfig.Trim());

        }



        private static readonly string configFilePath = "config.ini";
        public static Dictionary<string, string> getDirectory()
        {
            return ConfigReader.ReadConfig(configFilePath);
        }
        public static void UpdateIniFile(string section, string key, string newValue)
        {
            string filePath = configFilePath;

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            List<string> lines = new List<string>(File.ReadAllLines(filePath));
            bool insideSection = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i].Trim();

                if (line.Equals(section, StringComparison.OrdinalIgnoreCase))
                {
                    insideSection = true;
                    continue;
                }

                if (insideSection && line.StartsWith("[") && line.EndsWith("]"))
                {
                    break; // Stop if a new section starts
                }

                if (insideSection && line.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                {
                    lines[i] = $"{key}={newValue}";
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Config updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Key not found in the specified section.");
        }
    }
}
