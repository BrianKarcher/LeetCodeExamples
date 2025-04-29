using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array of strings words and an integer k, return the k most frequent strings.
    // Return the answer sorted by the frequency from highest to lowest.Sort the words with the same frequency by their lexicographical order.
    /// </summary>
    public class _00692_TopKFrequentWords_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TopKFrequent(new string[] { "i", "love", "leetcode", "i", "love", "coding" }, 2);
            //Assert.AreEqual(new List<string> { "i", "love" }, answer);

            var answer = TopKFrequent(new string[] { "love", "i", "leetcode", "i", "love", "coding" }, 2);
            Assert.AreEqual(new List<string> { "i", "love" }, answer);

            answer = TopKFrequent(new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" }, 4);
            Assert.AreEqual(new List<string> { "the", "is", "sunny", "day" }, answer);
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> dictWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!dictWords.ContainsKey(words[i]))
                    dictWords.Add(words[i], 0);
                dictWords[words[i]]++;
            }

            // nlogn
            var sortedList = dictWords.OrderByDescending(i => i.Value).ToList();

            List<string> rtn = new List<string>();
            // count is the official count of words added to rtn.
            int count = 0;
            while (count < k)
            {
                // Build a list of all items with the same count so we can sort them in 
                // Lexigraphical order
                int wordCount = sortedList[count].Value;
                List<string> tempWords = new List<string>();
                for (int i = count; i < sortedList.Count && sortedList[i].Value == wordCount; i++)
                {
                    tempWords.Add(sortedList[i].Key);
                }

                // Lexigraphical order
                var orderedWords = tempWords.OrderBy(i => i).ToList();
                for (int i = 0; i < orderedWords.Count && count < k; i++)
                {
                    rtn.Add(orderedWords[i]);
                    count++;
                }

            }
            return rtn;
        }
    }
}