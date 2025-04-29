using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given a string s representing an attendance record for a student where each character signifies whether the student was absent, late, or present on that day.The record only contains the following three characters:

    //'A': Absent.
    //'L': Late.
    //'P': Present.
    //The student is eligible for an attendance award if they meet both of the following criteria:

    //The student was absent('A') for strictly fewer than 2 days total.
    //The student was never late ('L') for 3 or more consecutive days.
    //Return true if the student is eligible for an attendance award, or false otherwise.
    /// </summary>
    public class _00551_StudentAttendanceRecordI
    {
        public bool CheckRecord(string s)
        {
            bool wasAbsent = false;
            int lateCount = 0;
            foreach (var ch in s)
            {
                if (ch == 'A')
                {
                    if (wasAbsent)
                        return false;
                    wasAbsent = true;
                    lateCount = 0;
                }
                else if (ch == 'L')
                {
                    lateCount++;
                    if (lateCount > 2)
                        return false;
                }
                else if (ch == 'P')
                {
                    lateCount = 0;
                }
            }
            return true;
        }
    }
}