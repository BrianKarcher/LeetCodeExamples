using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //  Write a function to find the longest common prefix string amongst an array of strings.
    //  If there is no common prefix, return an empty string "".
    /// </summary>
    public class _00014_LongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null)
                return string.Empty;

            string prefix = "";
            for (int i = 0; i < 200; i++)
            {
                char potentialPrefixChar = '\0';
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length)
                        return prefix;
                    char charForThisString = strs[j][i];
                    // First character? Set it
                    if (potentialPrefixChar == '\0')
                    {
                        potentialPrefixChar = charForThisString;
                    }
                    // Character change? End of prefix
                    else if (charForThisString != potentialPrefixChar)
                    {
                        return prefix;
                    }
                }
                prefix += potentialPrefixChar;
            }
            return prefix;
        }
    }
}