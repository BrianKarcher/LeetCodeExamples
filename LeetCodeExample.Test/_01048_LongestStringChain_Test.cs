using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an array of words where each word consists of lowercase English letters.
    // wordA is a predecessor of wordB if and only if we can insert exactly one letter anywhere in wordA without changing the order of the other characters to make it equal to wordB.
    // For example, "abc" is a predecessor of "abac", while "cba" is not a predecessor of "bcad".
    // A word chain is a sequence of words[word1, word2, ..., wordk] with k >= 1, where word1 is a predecessor of word2, word2 is a predecessor of word3, and so on.A single word is trivially a word chain with k == 1.

    // Return the length of the longest possible word chain with words chosen from the given list of words.
    /// </summary>
    public class _01048_LongestStringChain_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = LongestStrChain(new string[] { "a", "b", "ba", "bca", "bda", "bdca" });
            Assert.AreEqual(4, answer);

            answer = LongestStrChain(new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" });
            Assert.AreEqual(5, answer);

            answer = LongestStrChain(new string[] { "abcd", "dbqca" }); // ["abcd","dbqca"] is not a valid word chain because the ordering of the letters is changed.
            Assert.AreEqual(1, answer);
        }

        public int LongestStrChain(string[] words)
        {
            //map = new Dictionary<int, int>();

            // Check every possible root
            int maxCount = 0;
            for (int i = 0; i < words.Length; i++)
            {
                int count = Recurse(words, null, i);
                maxCount = Math.Max(maxCount, count);
            }

            return maxCount;
        }

        // Memoize (index : count)
        Dictionary<int, int> map = new Dictionary<int, int>();

        // Use Dynamic Programming. On each Recurse step, find the max chain of words that can be created from it.
        public int Recurse(string[] words, string previousString, int i)
        {
            // Base case
            if (previousString != null)
            {
                if (!IsValidNextWord(previousString, words[i]))
                    return 0;
            }

            if (map.ContainsKey(i))
                return map[i];

            int maxChain = 0;
            int thisOne = 1;
            // Find the next word in the chain
            for (int k = 0; k < words.Length; k++)
            {
                // Don't check a word against itself
                if (k == i)
                    continue;
                int newMax = Recurse(words, words[i], k);
                maxChain = Math.Max(maxChain, newMax);
            }
            maxChain += thisOne;

            map.Add(i, maxChain);

            return maxChain;
        }

        public bool IsValidNextWord(string prev, string next)
        {
            if (next.Length != prev.Length + 1)
                return false;

            // use two pointers to make sure that the new word contains all letters of the previous word
            // and in the same order
            int prevCounter = 0;
            for (int k = 0; k < next.Length; k++)
            {
                if (prevCounter >= prev.Length)
                    break;
                if (prev[prevCounter] == next[k])
                {
                    prevCounter++;
                }
            }
            if (prevCounter != prev.Length)
                return false;
            return true;
        }
    }
}