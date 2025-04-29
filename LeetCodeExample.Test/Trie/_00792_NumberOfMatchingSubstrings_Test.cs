using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
   // Given a string s and an array of strings words, return the number of words[i] that is a subsequence of s.

   // A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted without changing the relative order of the remaining characters.

   //For example, "ace" is a subsequence of "abcde".
    /// </summary>
    public class _00792_NumberOfMatchingSubstrings_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            
        }

        // https://leetcode.com/problems/number-of-matching-subsequences/discuss/117634/Efficient-and-simple-go-through-words-in-parallel-with-explanation/

        public int numMatchingSubseq(String S, String[] words)
        {
            List<int[]>[] waiting = new List<int>[128];
            for (int c = 0; c <= 'z'; c++)
                waiting[c] = new ArrayList();
            for (int i = 0; i < words.length; i++)
                waiting[words[i].charAt(0)].add(new Integer[] { i, 1 });
            for (char c : S.toCharArray())
            {
                List<Integer[]> advance = new ArrayList(waiting[c]);
                waiting[c].clear();
                for (Integer[] a : advance)
                    waiting[a[1] < words[a[0]].length() ? words[a[0]].charAt(a[1]++) : 0].add(a);
            }
            return waiting[0].size();
        }

        public int NumMatchingSubseq(string s, string[] words)
        {
            int count = 0;

            foreach (var word in words)
            {
                int wordPtr = 0;
                for (int sPtr = 0; sPtr < s.Length; sPtr++)
                {
                    if (word[wordPtr] == s[sPtr])
                    {
                        wordPtr++;
                        if (wordPtr >= word.Length)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }

            return count;
        }
    }
}