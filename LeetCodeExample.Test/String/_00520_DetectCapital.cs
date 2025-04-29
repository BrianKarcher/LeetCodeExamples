using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00520_DetectCapital
    {
        public bool DetectCapitalUse(string word)
        {
            bool allCapitals = true;
            bool allLowercase = true;
            bool onlyFirstLetterIsCapital = true;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (Char.IsUpper(ch))
                {
                    allLowercase = false;
                    if (i != 0)
                        onlyFirstLetterIsCapital = false;
                }
                else
                {
                    allCapitals = false;
                }
                if (!allCapitals && !allLowercase && !onlyFirstLetterIsCapital)
                    return false;
            }
            return true;
        }
    }
}