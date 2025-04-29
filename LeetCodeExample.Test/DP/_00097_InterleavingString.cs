using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.

    //    An interleaving of two strings s and t is a configuration where they are divided into non-empty substrings such that:


    //    s = s1 + s2 + ... + sn
    //    t = t1 + t2 + ... + tm
    //    |n - m| <= 1
    //The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
    //Note: a + b is the concatenation of strings a and b.
    /// </summary>
    public class _00097_InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;
            return dp(s1, s2, s3, 0, 0, 0);
        }

        Dictionary<(int i1, int i2, int i3), bool> map = new Dictionary<(int, int, int), bool>();

        public bool dp(string s1, string s2, string s3, int i1, int i2, int i3)
        {
            //Console.WriteLine($"{i1} {i2} {i3}");
            // base case
            if (i3 == s3.Length)
            {
                return true;
            }

            if (map.ContainsKey((i1, i2, i3)))
                return map[(i1, i2, i3)];

            char c1 = i1 >= s1.Length ? ' ' : s1[i1];
            char c2 = i2 >= s2.Length ? ' ' : s2[i2];
            char c3 = s3[i3];
            //Console.WriteLine($"{c1} {c2} {c3}");
            bool res = false;
            if (c1 == c3 && c2 != c3)
            {
                //Console.WriteLine("Taking 1");
                // First character match, only increment that one
                res = dp(s1, s2, s3, i1 + 1, i2, i3 + 1);
            }
            else if (c2 == c3 && c1 != c3)
            {
                //Console.WriteLine("Taking 2");
                // Second character match, only increment that one
                res = dp(s1, s2, s3, i1, i2 + 1, i3 + 1);
            }
            else if (c1 == c3 && c2 == c3)
            {
                // All 3 characters match, don't know which to pick so let's try both
                // and see if one ends up at a successful conclusion
                //Console.WriteLine("Trying both");
                bool try1 = dp(s1, s2, s3, i1 + 1, i2, i3 + 1);
                bool try2 = dp(s1, s2, s3, i1, i2 + 1, i3 + 1);
                res = try1 || try2;
            }
            map.Add((i1, i2, i3), res);
            //Console.WriteLine("Return false");
            return res;
        }
    }
}