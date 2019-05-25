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

            return allAnagrams.OrderByDescending(p => p.Count).First();
        }

        public List<string> GetLongestAnagrams(List<string> lines)
        {
            var allAnagrams = GetAllAnagrams(lines);
            var orderedWords = allAnagrams.OrderByDescending(p => p[0].Length).ToList();
            var wordLength = orderedWords.First()[0].Length;
            var result = new List<string>();

            for(int q = 0; q < orderedWords.Count(); q++)
            {
                if(orderedWords[q].First().Length == wordLength)
                {
                    result.Add(orderedWords[q].First());
                }
                else
                {
                    return result;
                }
            }

            return result;
        }
    }
}
