using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Write an algorithm to determine if a number n is happy.

    //    A happy number is a number defined by the following process:

    //Starting with any positive integer, replace the number by the sum of the squares of its digits.
    //Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
    //Those numbers for which this process ends in 1 are happy.
    //Return true if n is a happy number, and false if not.
    /// </summary>
    public class _00202_HappyNumber
    {
        public bool IsHappy(int n)
        {
            HashSet<int> hash = new HashSet<int>();
            while (!hash.Contains(n))
            {
                hash.Add(n);
                // Deconstruct number
                int newNum = 0;
                // We need to extract all digits from n, square them, then add it to newNum
                while (n != 0)
                {
                    int newDigit = n % 10;
                    //Console.WriteLine(newDigit);
                    newNum += newDigit * newDigit;
                    n = n / 10;
                }
                if (newNum == 1)
                {
                    return true;
                }
                n = newNum;
            }
            return false;
        }
    }
}