using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given a string s.In one step you can insert any character at any index of the string.
    // Return the minimum number of steps to make s palindrome.
    // A Palindrome String is one that reads the same backward as well as forward.
    /// </summary>
    public class _001312_MinimumInsertionStepsMakeStringPalindrome
    {
        public int MinInsertions(string s)
        {
            return dp(s, 0, s.Length - 1);
        }

        Dictionary<(int l, int r), int> memo = new Dictionary<(int, int), int>();

        int dp(string s, int l, int r)
        {
            if (l > r)
                return 0;

            if (memo.ContainsKey((l, r)))
                return memo[(l, r)];

            int rtn = Int32.MaxValue;
            // A match makes it possible to move both pointers at the same time
            if (s[l] == s[r])
                rtn = dp(s, l + 1, r - 1);
            // Add 1 because an insertion is needed
            rtn = Math.Min(rtn, dp(s, l + 1, r) + 1);
            rtn = Math.Min(rtn, dp(s, l, r - 1) + 1);
            memo.Add((l, r), rtn);
            return rtn;
        }
    }
}