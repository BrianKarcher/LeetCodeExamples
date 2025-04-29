using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00191_NumberOf1Bits
    {
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    count++;
                }
                n = n >> 1;
            }
            return count;
        }
    }
}