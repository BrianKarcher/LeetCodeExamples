using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //  You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer.The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.
    //  Increment the large integer by one and return the resulting array of digits.
    /// </summary>
    public class _00066_PlusOne
    {
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                if (digits[i] == 9 && i != 0)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i] = 0;
                    int[] newArr = new int[digits.Length + 1];
                    Array.Copy(digits, 0, newArr, 1, digits.Length);
                    newArr[0] = 1;
                    return newArr;
                }
            }
            return digits;
        }
    }
}