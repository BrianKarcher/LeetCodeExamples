using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a string s, reverse only all the vowels in the string and return it.
    //The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both cases.
    /// </summary>
    public class _00345_ReverseVowelsOfString
    {
        public string ReverseVowels(string s)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            List<char> vowelList = new List<char>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    vowelList.Add(s[i]);
                }
            }

            int vowelIndex = vowelList.Count - 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    sb.Append(vowelList[vowelIndex]);
                    vowelIndex--;
                }
                else
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }
    }
}