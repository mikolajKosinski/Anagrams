using System.Collections.Generic;
using System.Linq;

namespace Anagram
{
    public class AnagramProcessor
    {
        public List<List<string>> GetAllAnagrams(List<string> lines)
        {
            var result = lines.GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
                 .Select(grp => grp.ToList())
                 .Where(p => p.Count > 1 && lines.Any(x => p.Contains(x))).ToList();

            return result;
        }

        public List<string> GetBiggestSetOfAnagrams(List<string> lines)
        {
            var allAnagrams = GetAllAnagrams(lines);

            if (!allAnagrams.Any())
                return new List<string>();

            return allAnagrams.OrderByDescending(p => p.Count).First();
        }

        public List<string> GetLongestAnagrams(List<string> lines)
        {
            var allAnagrams = new List<string>();
            GetAllAnagrams(lines).ForEach(p => allAnagrams.AddRange(p));

            if (!allAnagrams.Any())
                return new List<string>();

            var wordLength = allAnagrams.OrderByDescending(p => p.Length).First().Length;
            var result = allAnagrams.Where(p => p.Length == wordLength).ToList();

            return result;
        }
    }
}
