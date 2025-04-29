using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given an array of meeting time intervals intervals where intervals[i] = [starti, endi],
    // return the minimum number of conference rooms required.
    /// </summary>
    public class _00253_MeetingRoomsII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // Sort + 2 pointers
        // O(N Log N) - due to the sorts
        public int minMeetingRooms(int[][] intervals)
        {

            // Check for the base case. If there are no intervals, return 0
            if (intervals.Length == 0)
            {
                return 0;
            }

            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            Array.Sort(start);
            Array.Sort(end);

            // The two pointers in the algorithm: e_ptr and s_ptr.
            int startPointer = 0, endPointer = 0;

            // Variables to keep track of maximum number of rooms used.
            int usedRooms = 0;

            // Iterate over intervals.
            while (startPointer < intervals.Length)
            {

                // If there is a meeting that has ended by the time the meeting at `start_pointer` starts
                if (start[startPointer] >= end[endPointer])
                {
                    usedRooms -= 1;
                    endPointer += 1;
                }

                // We do this irrespective of whether a room frees up or not.
                // If a room got free, then this used_rooms += 1 wouldn't have any effect. used_rooms would
                // remain the same in that case. If no room was free, then this would increase used_rooms
                usedRooms += 1;
                startPointer += 1;

            }

            return usedRooms;
        }

        public int MinMeetingRooms(int[][] intervals)
        {
            List<(int start, int end)> unorderdLst = new List<(int, int)>();
            for (int i = 0; i < intervals.Length; i++)
            {
                unorderdLst.Add((intervals[i][0], intervals[i][1]));
            }
            // Order by start time
            var orderedList = unorderdLst.OrderBy(i => i.start);
            List<(int start, int end)> concurrentMeetings = new List<(int start, int end)>();

            int max = 0;
            foreach (var lst in orderedList)
            {
                // Remove any meetings that have concluded at this start time.
                for (int i = concurrentMeetings.Count - 1; i >= 0; i--)
                {
                    if (concurrentMeetings[i].end <= lst.start)
                    {
                        concurrentMeetings.RemoveAt(i);
                    }
                }

                concurrentMeetings.Add(lst);
                max = Math.Max(max, concurrentMeetings.Count);
            }
            return max;
        }
    }
}