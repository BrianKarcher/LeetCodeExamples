using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an array of meeting time intervals intervals where intervals[i] = [starti, endi], return the minimum number of conference rooms required.
/// </summary>
public class _00253_MeetingRoomsII
{
    public int MinMeetingRooms(int[][] intervals)
    {
        // Order by start date.
        int[][] orderedIntervals = intervals.OrderBy(i => i[0]).ToArray();
        // Store the current end dates 
        PriorityQueue<int, int> pq = new();
        int maxSize = 0;
        for (int i = 0; i < orderedIntervals.Length; i++)
        {
            pq.Enqueue(orderedIntervals[i][1], orderedIntervals[i][1]);
            // Dequeue the meetings that have ended before this interval's start date.
            while (pq.Count != 0 && pq.Peek() <= orderedIntervals[i][0])
            {
                pq.Dequeue();
            }
            maxSize = Math.Max(maxSize, pq.Count);
        }
        return maxSize;
    }
}