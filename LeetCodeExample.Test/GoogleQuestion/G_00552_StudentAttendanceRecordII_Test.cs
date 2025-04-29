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
    public class G_00552_StudentAttendanceRecordII_Test
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
            total = 0;

            dp(n, 0, 0);
            return total;
        }

        int total;
        int M = 1000000007;

        public void dp(int n, int absentCount, int lateRecurringCount)
        {
            // base case
            if (n == 0)
            {
                total = (total + 1) % M;
                return;
            }

            // Can be Present
            dp(n - 1, absentCount, 0);

            // Can be absent
            if (absentCount == 0)
            {
                dp(n - 1, 1, 0);
            }
            // Can be late
            if (lateRecurringCount < 3)
            {
                dp(n - 1, absentCount, lateRecurringCount + 1);
            }
        }
    }
}