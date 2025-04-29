using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given a license key represented as a string s that consists of only alphanumeric characters and dashes.The string is separated into n + 1 groups by n dashes. You are also given an integer k.
    //We want to reformat the string s such that each group contains exactly k characters, except for the first group, which could be shorter than k but still must contain at least one character. Furthermore, there must be a dash inserted between two groups, and you should convert all lowercase letters to uppercase.
    //Return the reformatted license key.
    /// </summary>
    public class _00482_LicenseKeyFormatting
    {
        public string LicenseKeyFormatting(string s, int k)
        {
            int groupCount = 0;
            string res = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '-')
                    continue;
                res = Char.ToUpper(s[i]) + res;
                groupCount++;
                if (groupCount == k && i != 0)
                {
                    res = "-" + res;
                    groupCount = 0;
                }
            }
            if (res.Length > 0 && res[0] == '-')
                res = res.Substring(1);
            return res;
        }
    }
}