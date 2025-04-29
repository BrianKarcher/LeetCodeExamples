using System;

namespace LeetCodeExample.Test
{
    /// <summary>
    // An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
    // Given an integer n, return the nth ugly number.
    /// </summary>
    public class _00264_UglyNumberII
    {
        public int NthUglyNumber(int n)
        {
            if (n <= 0) return 0; // get rid of corner cases 
            if (n == 1) return 1; // base case
            int t2 = 0, t3 = 0, t5 = 0; //pointers for 2, 3, 5
            int[] k = new int[n];
            k[0] = 1;
            for (int i = 1; i < n; i++)
            {
                k[i] = Math.Min(k[t2] * 2, Math.Min(k[t3] * 3, k[t5] * 5));
                if (k[i] == k[t2] * 2) t2++;
                if (k[i] == k[t3] * 3) t3++;
                if (k[i] == k[t5] * 5) t5++;
            }
            return k[n - 1];
        }
    }
}