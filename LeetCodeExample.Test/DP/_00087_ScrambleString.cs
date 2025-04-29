using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    We can scramble a string s to get a string t using the following algorithm:

    //If the length of the string is 1, stop.
    //If the length of the string is > 1, do the following:
    //Split the string into two non-empty substrings at a random index, i.e., if the string is s, divide it to x and y where s = x + y.
    //Randomly decide to swap the two substrings or to keep them in the same order.i.e., after this step, s may become s = x + y or s = y + x.
    //Apply step 1 recursively on each of the two substrings x and y.
    //Given two strings s1 and s2 of the same length, return true if s2 is a scrambled string of s1, otherwise, return false.
    /// </summary>
    public class _00087_ScrambleString
    {
        // NOTE : Rewrite using Matrix Chain Multiplication (MCM) - not sure what this is
        // Look up a video!
        public bool IsScramble(string s1, string s2)
        {
            return CanScramble(0, s1.Length - 1, s1, s2) == 2;
        }

        Dictionary<(int l, int r, string s), int> map = new Dictionary<(int l, int r, string s), int>();

        public int CanScramble(int l, int r, string s1, string targetString)
        {
            if (s1 == targetString)
                return 2;

            if (l + 1 >= r)
                return 1;

            if (map.ContainsKey((l, r, s1)))
                return map[(l, r, s1)];

            // 0 = Working on it
            map.Add((l, r, s1), 0);

            bool result = false;
            Console.WriteLine($"Entering dp {l} {r} {s1}");
            // Can only split from the middle of the string, before the first or after the last letter
            for (int i = l + 1; i <= r; i++)
            {
                // Option 1: No flip
                // Check left substring
                if (CanScramble(l, i, s1, targetString) == 2)
                    result = true;
                // Check right substring
                if (CanScramble(i, r, s1, targetString) == 2)
                    result = true;

                // Option 2: Flip!
                string toTheLeft = s1.Substring(0, l);
                string leftSub = s1.Substring(l, i - l);
                if (i + r - i + 1 > s1.Length - 1)
                    Console.WriteLine($"{s1} {i} {r}");
                string rightSub = s1.Substring(i, r - i + 1);
                string toTheRight = "";
                if (r < s1.Length) ;
                toTheRight = s1.Substring(r + 1, s1.Length - r - 1);
                string final = toTheLeft + rightSub + leftSub + toTheRight;

                Console.WriteLine($"({i}) {s1} l:{toTheLeft} ls:{leftSub} rs:{rightSub} r:{toTheRight} = {final}");
                // Check right substring after the flip
                if (CanScramble(l, l + rightSub.Length - 1, final, targetString) == 2)
                    result = true;

                // Check left substring after the flip
                Console.WriteLine($"Checking left substring {s1} {i} {leftSub.Length}");
                if (CanScramble(l + rightSub.Length - 1, s1.Length - l - rightSub.Length, final, targetString) == 2)
                    result = true;
            }

            //map.Add((l, r, s1), result ? 2 : 1);
            int iResult = result ? 2 : 1;
            map[(l, r, s1)] = iResult;
            return iResult;
        }
    }
}