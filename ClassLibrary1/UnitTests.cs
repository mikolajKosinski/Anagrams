using Anagram;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void GetAllAnagrams_ThreeWordsTwoAnagrams_ShouldReturnTwoWords()
        {
            var anagramProcessor = new AnagramProcessor();
            var lines = new List<string> { "abc", "bca", "bbb" };

            var result = anagramProcessor.GetAllAnagrams(lines);

            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result[0].Count, Is.EqualTo(2));
            });
        }

        [Test]
        public void GetBiggestSetOfAnagrams_ThreeWordsTwoAnagrams_ShouldReturnTwoWords()
        {
            var anagramProcessor = new AnagramProcessor();
            var lines = new List<string> { "abc", "bca", "bbb" };

            var result = anagramProcessor.GetBiggestSetOfAnagrams(lines);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetLongestAnagrams_ThreeWordsTwoAnagrams_ShouldReturnThreeWord()
        {
            var anagramProcessor = new AnagramProcessor();
            var lines = new List<string> { "abc", "bca", "cabb",  "abbc", "bbca", "bbb" };

            var result = anagramProcessor.GetBiggestSetOfAnagrams(lines);

            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}
