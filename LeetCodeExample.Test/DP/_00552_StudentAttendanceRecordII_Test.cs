using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    An attendance record for a student can be represented as a string where each character signifies whether the student was absent, late, or present on that day.The record only contains the following three characters:

    //'A': Absent.
    //    'L': Late.
    //    'P': Present.
    //    Any student is eligible for an attendance award if they meet both of the following criteria:


    //    The student was absent ('A') for strictly fewer than 2 days total.
    //    The student was never late ('L') for 3 or more consecutive days.
    //    Given an integer n, return the number of possible attendance records of length n that make a student eligible for an attendance award.The answer may be very large, so return it modulo 109 + 7.
    /// </summary>
    public class _00552_StudentAttendanceRecordII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ans = CheckRecord(1);
            Console.WriteLine(ans);

            ans = CheckRecord(2);
            Console.WriteLine(ans);
        }

        public int CheckRecord(int n)
        {
            //total = 0;

            long[,,] dp = new long[n, 3, 2];
            // base case
            // n  l  a
            dp[0, 0, 0] = 1;
            dp[0, 0, 1] = 1;
            dp[0, 1, 0] = 1;
            dp[0, 1, 1] = 0;
            dp[0, 2, 0] = 0;
            dp[0, 2, 1] = 0;

            // State-based

            for (int i = 1; i < n; i++)
            {
                dp[i, 0, 0] = (dp[i - 1, 0, 0] + dp[i - 1, 1, 0] + dp[i - 1, 2, 0]) % M; // no consecLate, no A
                dp[i, 0, 1] = (dp[i - 1, 0, 0] + dp[i - 1, 1, 0] + dp[i - 1, 2, 0]) % M + (dp[i - 1, 0, 1] + dp[i - 1, 1, 1] + dp[i - 1, 2, 1]) % M;
                dp[i, 1, 0] = dp[i - 1, 0, 0] % M; // 1 ConsecLte, no A
                dp[i, 1, 1] = dp[i - 1, 0, 1] % M; // 1 L, has A
                dp[i, 2, 0] = dp[i - 1, 1, 0] % M; // 2 L, no A
                dp[i, 2, 1] = dp[i - 1, 1, 1] % M; // 2 L, has A
            }

            long total = 0;
            for (int l = 0; l < 3; l++)
            {
                for (int a = 0; a < 2; a++)
                {
                    total += dp[n - 1, l, a];
                    total %= M;
                }
            }

            //int total = dp(n, 0, 0);
            return (int)total;
        }

        //int total;
        int M = 1000000007;

        /*public int CheckRecord(int n)
        {
            //total = 0;

            int total = dp(n, 0, 0);
            return total;
        }

        //int total;
        int M = 1000000007;

        Dictionary<(int n, int absentCount, int late), int> cache = new Dictionary<(int n, int absentCount, int late), int>();

        public int dp(int n, int absentCount, int lateRecurringCount)
        {
            // base case
            if (n == 0)
            {
                return 1;
            }

            if (cache.ContainsKey((n, absentCount, lateRecurringCount)))
                return cache[(n, absentCount, lateRecurringCount)];

            // Can be Present
            int total = dp(n - 1, absentCount, 0);
            total %= M;

            // Can be absent
            if (absentCount == 0)
            {
                total += dp(n - 1, 1, 0);
                total %= M;
            }
            // Can be late
            if (lateRecurringCount < 2)
            {
                total += dp(n - 1, absentCount, lateRecurringCount + 1);
                total %= M;
            }
            cache.Add((n, absentCount, lateRecurringCount), total);

            return total;
        }*/
    }
}