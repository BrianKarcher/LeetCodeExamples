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
    public class _00299_BullsAndCows
    {
        public string GetHint(string secret, string guess)
        {
            Dictionary<char, int> diff = new Dictionary<char, int>();
            for (char ch = '0'; ch <= '9'; ch++)
            {
                diff.Add(ch, 0);
            }
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    if (diff[secret[i]] < 0)
                        cows++;
                    diff[secret[i]]++;

                    if (diff[guess[i]] > 0)
                        cows++;
                    diff[guess[i]]--;
                }
            }
            return $"{bulls}A{cows}B";
        }

        //public string GetHint2(string secret, string guess)
        //{
        //    Dictionary<char, int> secretNotFound = new Dictionary<char, int>();
        //    for (char ch = '0'; ch <= '9'; ch++)
        //    {
        //        secretNotFound.Add(ch, 0);
        //    }
        //    int bulls = 0;
        //    int cows = 0;
        //    HashSet<int> indexMatch = new HashSet<int>();
        //    for (int i = 0; i < secret.Length; i++)
        //    {
        //        if (secret[i] == guess[i])
        //        {
        //            // Record the bull indexes to skip them later
        //            indexMatch.Add(i);
        //            bulls++;
        //        }
        //        else
        //            secretNotFound[secret[i]]++;
        //    }

        //    for (int i = 0; i < guess.Length; i++)
        //    {
        //        // Skip if bull already found
        //        if (indexMatch.Contains(i))
        //            continue;
        //        if (secretNotFound[guess[i]] > 0)
        //        {
        //            cows++;
        //            secretNotFound[guess[i]]--;
        //        }
        //    }
        //    return $"{bulls}A{cows}B";
        //}
    }
}