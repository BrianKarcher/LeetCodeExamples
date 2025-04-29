using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.
    /// </summary>
    public class _00258_AddDigits
    {
        public int AddDigits(int num)
        {
            if (num == 0)
                return 0;
            int currentNum = num;
            while (true)
            {
                // Break apart the currentNum, adding the digits as we go
                int sum = 0;
                int digitCount = 0;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                    digitCount++;
                }
                if (digitCount == 1)
                    return sum;
                currentNum = sum;
            }
        }
    }
}