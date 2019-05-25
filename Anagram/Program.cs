using System;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {

            var lines = FileProcessor.ReadAllLinesFromFile();
            var anagramProcessor = new AnagramProcessor();
            var anagrams = anagramProcessor.GetAllAnagrams(lines);

            Console.WriteLine("All anagrams : ");
            foreach(var item in anagrams)
            {
                item.ForEach(p => Console.Write($" {p}"));
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Biggest set of anagrams : ");
            var biggestSet = anagramProcessor.GetBiggestSetOfAnagrams(lines);
            biggestSet.ForEach(b => Console.Write($" {b}"));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Longest anagrams : ");
            var longestAnagrams = anagramProcessor.GetLongestAnagrams(lines);
            longestAnagrams.ForEach(p => Console.WriteLine(p));

            Console.ReadKey();
        }
    }
}
