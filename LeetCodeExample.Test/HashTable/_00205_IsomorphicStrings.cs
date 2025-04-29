using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given two strings s and t, determine if they are isomorphic.
    // Two strings s and t are isomorphic if the characters in s can be replaced to get t.
    // All occurrences of a character must be replaced with another character while preserving the order of characters.No two characters may map to the same character, but a character may map to itself.
    /// </summary>
    public class _00205_IsomorphicStrings
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> map = new();
            Dictionary<char, char> reverseMap = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map.Add(s[i], t[i]);
                }
                if (!reverseMap.ContainsKey(t[i]))
                {
                    reverseMap.Add(t[i], s[i]);
                }
                if (map[s[i]] != t[i])
                {
                    return false;
                }
                if (reverseMap[t[i]] != s[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}