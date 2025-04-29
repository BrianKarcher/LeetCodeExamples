using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a string s consisting of words and spaces, return the length of the last word in the string.

    // A word is a maximal
    // substring
    // consisting of non-space characters only.
    /// </summary>
    public class _00058_LengthOfLastWord
    {
        public int LengthOfLastWord(string s)
        {
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                // Account for spaces at the end of the string
                if (count == 0 && s[i] == ' ')
                    continue;
                else if (s[i] == ' ')
                    return count;
                count++;
            }
            return count;
        }
    }
}