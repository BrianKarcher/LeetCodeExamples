using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given a string s, find the length of the longest substring without repeating characters.
    /// </summary>
    public class _00003_LongestSubstringWithoutRepeatingCharacters_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int LengthOfLongestSubstring(string s)
        {
            if (s == null)
                return 0;
            // char : index of char in the string
            Dictionary<char, int> map = new Dictionary<char, int>();
            int left = 0;
            int maxSubstring = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    int pos = map[s[i]];
                    // Move the left int to the position of the first duplicate + 1, removing the chars
                    // from the dictionary along the way
                    while (left <= pos)
                    {
                        if (map.ContainsKey(s[left]))
                            map.Remove(s[left]);
                        left++;
                    }
                }
                maxSubstring = Math.Max(maxSubstring, i - left + 1);
                map.Add(s[i], i);
            }
            return maxSubstring;
        }
    }
}