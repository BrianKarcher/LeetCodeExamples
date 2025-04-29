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
    public class _00326_PowerOfThree
    {
        public bool IsPowerOfThree(int n)
        {
            if (n == 0)
                return false;
            if (n == 1)
                return true;
            
            double num = Math.Log(n, 3);
            return num == Math.Floor(num);
        }
    }
}