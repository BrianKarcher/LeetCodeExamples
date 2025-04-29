using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given two strings s and t, return the number of distinct subsequences of s which equals t.
    // A string's subsequence is a new string formed from the original string by deleting some (can be none) of the characters without disturbing the remaining characters' relative positions. (i.e., "ACE" is a subsequence of "ABCDE" while "AEC" is not).
    // It is guaranteed the answer fits on a 32-bit signed integer.
    /// </summary>
    public class _00115_DistinctSubsequences_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = NumDistinct("rabbbit", "rabbit");
            Assert.AreEqual(3, answer);

            answer = NumDistinct("babgbag", "bag");
            Assert.AreEqual(5, answer);

            answer = NumDistinct("anacondastreetracecar", "contra");
            Assert.AreEqual(6, answer);

        }

        public int NumDistinct(string s, string t)
        {
            //map = new Dictionary<string, int>();
            map = new();
            if (s == t)
            {
                return 1;
            }

            //return Recurse(s, t);
            //return Recurse(s, t, new string('0', s.Length));
            return Recursive(s, t, 0, 0);
        }

        // The question is asking for distinct subsequences, not the number of paths to an answer.
        // So we will retain the indexes of the letters removed and not count duplicate paths to the answer

        //HashSet<string> map = new HashSet<string>();
        //Dictionary<string, int> map = new Dictionary<string, int>();
        Dictionary<(int i,int j), int> map = new Dictionary<(int i, int j), int>();

        // Dynamic Programming approach
        //public int Recurse(string s, string t)
        //{
        //    if (s == t)
        //    {
        //        return 1;
        //    }

        //    // Cannot be a subset if s is smaller than t
        //    if (s.Length < t.Length)
        //        return 0;

        //    if (s.Length == 0)
        //        return 0;

        //    // Do not retest the same sequence again, use cached results
        //    if (map.ContainsKey(s))
        //    {
        //        return 0;
        //        //return map[s];
        //    }

        //    int sum = 0;

        //    // Test removal of one character from each position
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        var test = s.Remove(i, 1);
        //        sum += Recurse(test, t);
        //    }

        //    // Memoize the result
        //    map.Add(s, sum);
        //    return sum;
        //}

        //public int Recurse(string s, string t, string charsChecked)
        //{
        //    // Cannot be a subset if s is smaller than t
        //    if (s.Length < t.Length)
        //        return 0;

        //    if (s.Length == 0)
        //        return 0;

        //    // Do not retest the same sequence again, return 0
        //    if (map.Contains(charsChecked))
        //    {
        //        return 0;
        //    }

        //    map.Add(charsChecked);

        //    int counter = 0;
        //    bool match = true;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (charsChecked[i] == '1')
        //        {
        //            if (counter >= t.Length)
        //            {
        //                match = false;
        //                break;
        //            }
        //            if (s[i] != t[counter])
        //            {
        //                match = false;
        //                break;
        //            }
        //            counter++;
        //        }
        //    }

        //    if (match && counter == t.Length)
        //        return 1;

        //    int sum = 0;
        //    // Test removal of one character from each position
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        var updatedCharsChecked = charsChecked.Remove(i, 1).Insert(i, "1");
        //        sum += Recurse(s, t, updatedCharsChecked);
        //    }

        //    return sum;
        //}

        public int Recursive(string s, string t, int i, int j)
        {
            // Base case
            int M = s.Length;
            int N = t.Length;
            if (M == i || N == j || M - i < N - j)
            {
                if (N == j)
                    return 1;
                else
                    return 0;
            }

            // Check the cache for an already calculated result
            if (map.ContainsKey((i, j)))
                return map[(i, j)];

            int ans;
            if (s[i] == t[j])
            {
                // A match. Since we are testing for any number of subqueries, we need
                // to branch and test were S's index + 1 (assume a nonmatch), and both indexes + 1
                ans = Recursive(s, t, i + 1, j) + Recursive(s, t, i + 1, j + 1);
            }
            else
            {
                // No match, just increment S's index
                ans = Recursive(s, t, i + 1, j);
            }

            // memoize
            map.Add((i, j), ans);
            return ans;
        }
    }
}