using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a string s, partition s such that every substring of the partition is a palindrome.Return all possible palindrome partitioning of s.
    //A palindrome string is a string that reads the same backward as forward.
    /// </summary>
    public class _00131_PalindromePartitioning
    {
        public IList<IList<string>> Partition(string s)
        {
            dp(s, 0, new List<string>());
            return rtn;
        }

        IList<IList<string>> rtn = new List<IList<string>>();

        void dp(string s, int sum, List<string> splits)
        {
            // base case
            if (sum >= s.Length)
            {
                rtn.Add(new List<string>(splits));
                return;
            }

            // We need to set up the combinations so none are ever repeated
            for (int i = 1; i <= s.Length - sum; i++)
            {
                // Abort early if this split is not a palindrome
                string split = s.Substring(sum, i);
                if (!isPalindrome(split))
                    continue;
                splits.Add(split);
                dp(s, sum + i, splits);
                // Backtrack
                splits.RemoveAt(splits.Count - 1);
            }
        }

        bool isPalindrome(string s)
        {
            int l = 0;
            int r = s.Length - 1;
            while (l <= r)
            {
                if (s[l] != s[r])
                    return false;
                l++;
                r--;
            }
            return true;
        }

        //public IList<IList<string>> Partition(string s)
        //{
        //    dp(s, 0, new List<int>());
        //    return rtn;
        //}

        //IList<IList<string>> rtn = new List<IList<string>>();

        //void dp(string s, int sum, List<int> counts)
        //{
        //    // base case
        //    if (sum == s.Length)
        //    {
        //        int currentCount = 0;
        //        List<string> splits = new List<string>();
        //        // Split up the string
        //        foreach (var count in counts)
        //        {
        //            splits.Add(s.Substring(currentCount, count));
        //            currentCount += count;
        //        }
        //        bool canAdd = true;
        //        foreach (var split in splits)
        //        {
        //            // If any split is not a palindrome we need to abort
        //            if (!isPalindrome(split))
        //            {
        //                canAdd = false;
        //                break;
        //            }
        //        }
        //        if (canAdd)
        //            rtn.Add(splits);
        //        return;
        //    }
        //    if (sum > s.Length)
        //        return;

        //    // We need to set up the combinations so none are ever repeated
        //    for (int i = 1; i <= s.Length - sum; i++)
        //    {
        //        counts.Add(i);
        //        dp(s, sum + i, counts);
        //        // Backtrack
        //        counts.RemoveAt(counts.Count - 1);
        //    }
        //}

        //bool isPalindrome(string s)
        //{
        //    int l = 0;
        //    int r = s.Length - 1;
        //    while (l <= r)
        //    {
        //        if (s[l] != s[r])
        //            return false;
        //        l++;
        //        r--;
        //    }
        //    return true;
        //}
    }
}