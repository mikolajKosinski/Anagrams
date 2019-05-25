using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Anagram
{
    class FileProcessor
    {
        public static List<string> ReadAllLinesFromFile()
        {
            string filePath = ConfigurationSettings.AppSettings["filePath"];
            string line;
            var result = new List<string>();

            if (File.Exists(filePath))
            {
                StreamReader file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
