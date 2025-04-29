using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00720_LongestWord_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = LongestWord(new string[] { "w", "wo", "wor", "worl", "world" });
            Assert.AreEqual("world", answer);

            answer = LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" });
            Assert.AreEqual("apple", answer);

            answer = LongestWord(new string[] { "rac", "rs", "ra", "on", "r", "otif", "o", "onpdu", "rsf", "rs", "ot", "oti", "racy", "onpd" });
            Assert.AreEqual("otif", answer);
        }

        //public string LongestWord(string[] words)
        //{
        //    var sortedWords = words.OrderBy(s => s).ToList();
        //    string longestWord = string.Empty;
        //    HashSet<string> acceptedWords = new HashSet<string>();
        //    for (int i = 0; i < sortedWords.Count(); i++)
        //    {
        //        var word = sortedWords[i];

        //        if (word.Length > 1)
        //        {
        //            var wordMinusOne = word.Substring(0, word.Length - 1);

        //            // Don't accept the word if it can't be "built"
        //            if (!acceptedWords.Contains(wordMinusOne))
        //                continue;
        //        }

        //        if (word.Length > longestWord.Length)
        //        {
        //            longestWord = word;
        //        }

        //        acceptedWords.Add(word);
        //    }
        //    return longestWord;
        //}

        public string LongestWord(string[] words)
        {
            // count : list of words in that count
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (!dict.TryGetValue(word.Length, out var lst))
                {
                    List<string> newList = new List<string>();
                    lst = newList;
                    dict.Add(word.Length, lst);
                }
                lst.Add(word);
            }

            //var sortedWords = words.OrderBy(s => s).ToList();
            string longestWord = string.Empty;
            HashSet<string> acceptedWords = new HashSet<string>();
            for (int i = 0; i < sortedWords.Count(); i++)
            {
                var word = sortedWords[i];

                if (word.Length > 1)
                {
                    var wordMinusOne = word.Substring(0, word.Length - 1);

                    // Don't accept the word if it can't be "built"
                    if (!acceptedWords.Contains(wordMinusOne))
                        continue;
                }

                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }

                acceptedWords.Add(word);
            }
            return longestWord;
        }
    }
}