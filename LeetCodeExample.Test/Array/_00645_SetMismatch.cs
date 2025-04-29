using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You have a set of integers s, which originally contains all the numbers from 1 to n.Unfortunately, due to some error, one of the numbers in s got duplicated to another number in the set, which results in repetition of one number and loss of another number.
    //You are given an integer array nums representing the data status of this set after the error.

    //Find the number that occurs twice and the number that is missing and return them in the form of an array.
    /// </summary>
    public class _00645_SetMismatch
    {
        public int[] FindErrorNums(int[] nums)
        {
            HashSet<int> numsHash = new HashSet<int>();
            int missingNum = 0;
            int dupeNum = 0;
            // Pass over array twice. Once to find the duplicate, the other to find the missing value
            // to pass the edge case of the duplicate being mistaken as the missing value
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (numsHash.Contains(num))
                {
                    dupeNum = num;
                }
                else
                {
                    numsHash.Add(num);
                }
            }

            for (int i = 1; i < nums.Length + 1; i++)
            {
                if (nums[i - 1] != i && !numsHash.Contains(i))
                {
                    missingNum = i;
                }
            }
            return new int[] { dupeNum, missingNum };
        }
    }
}