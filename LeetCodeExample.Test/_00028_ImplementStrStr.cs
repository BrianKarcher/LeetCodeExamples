using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Implement strStr().
    //Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    //Clarification:
    //What should we return when needle is an empty string? This is a great question to ask during an interview.
    //For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
    /// </summary>
    public class _00028_ImplementStrStr
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle == string.Empty)
                return 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                int j = 0;
                while (j < needle.Length && i + j < haystack.Length && haystack[i + j] == needle[j])
                {
                    j++;
                }
                if (j == needle.Length)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}