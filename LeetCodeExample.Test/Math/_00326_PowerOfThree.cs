using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //  Given an integer n, return true if it is a power of three.Otherwise, return false.
    //  An integer n is a power of three, if there exists an integer x such that n == 3x.
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
            return Math.Abs(num - Math.Round(num)) < float.Epsilon / float.Epsilon;
        }
    }
}