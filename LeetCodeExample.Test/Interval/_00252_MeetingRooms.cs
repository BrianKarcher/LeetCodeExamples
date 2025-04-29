using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of meeting time intervals where intervals[i] = [starti, endi], determine if a person could attend all meetings.
    /// </summary>
    public class _00252_MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}