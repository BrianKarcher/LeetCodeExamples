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
    // USING HEAP (PRIORITY QUEUE)
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

    // USING TWO POINTERS.
    /// <summary>
    /// /////////
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public int MinMeetingRooms2(int[][] intervals)
    {
        // Check for the base case. If there are no intervals, return 0
        if (intervals.Length == 0)
        {
            return 0;
        }
        // Splitting the start and ends. It doesn't matter
        // which meeting ends, just that it opens a room.
        int[] start = new int[intervals.Length];
        int[] end = new int[intervals.Length];
        for (int i = 0; i < intervals.Length; i++)
        {
            start[i] = intervals[i][0];
            end[i] = intervals[i][1];
        }
        Array.Sort(start);
        Array.Sort(end);
        int count = 0;
        int endPtr = 0;
        for (int sPtr = 0; sPtr < intervals.Length; sPtr++)
        {
            if (start[sPtr] >= end[endPtr])
            {
                // An end time has passed. A room is available.
                count--;
                endPtr++;
            }
            // Grab a room.
            count++;
        }
        return count;
    }


    // DOESN'T WORK - but an interesteing idea using tuples. It doesn't work when an end time etand start time are the same.
    ///////////////////////////
    /// 
    public int MinMeetingRooms3(int[][] intervals)
    {
        (int order, char c)[] combinedIntervals = new (int, char)[intervals.Length * 2];
        int count = 0;
        for (int i = 0; i < intervals.Length; i++)
        {
            combinedIntervals[count] = (intervals[i][0], 'b');
            count++;
            combinedIntervals[count] = (intervals[i][1], 'e');
            count++;
        }
        char[] orderedIntervals = combinedIntervals.OrderBy(i => i.order).Select(i => i.c).ToArray();
        int maxSize = 0;
        int currentSize = 0;
        for (int i = 0; i < orderedIntervals.Length; i++)
        {
            if (orderedIntervals[i] == 'b')
            {
                currentSize++;
            }
            else if (orderedIntervals[i] == 'e')
            {
                currentSize--;
            }
            maxSize = Math.Max(maxSize, currentSize);
        }
        return maxSize;
    }
}