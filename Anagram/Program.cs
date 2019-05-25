using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ReadAllLinesFromFile();
            var anagrams = GetAllAnagramsCombinations(lines);
            anagrams.ForEach(p => Console.WriteLine(p));

            Console.ReadKey();
        }

        private static List<string> ReadAllLinesFromFile()
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

        private static List<string> GetAllAnagramsCombinations(List<string> lines)
        {
            var result = new List<string>();

            lines.GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
                 .Select(grp => grp.ToList())
                 .Where(p => p.Count > 1 && lines.Any(x => p.Contains(x))).ToList()
                 .ForEach(p => result.AddRange(p));

            return result;
        }
    }
}
