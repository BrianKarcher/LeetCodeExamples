using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given an integer n.There are n rooms numbered from 0 to n - 1.

//You are given a 2D integer array meetings where meetings[i] = [starti, endi] means that a meeting will be held during the half-closed time interval[starti, endi). All the values of starti are unique.

//Meetings are allocated to rooms in the following manner:

//Each meeting will take place in the unused room with the lowest number.
//If there are no available rooms, the meeting will be delayed until a room becomes free.The delayed meeting should have the same duration as the original meeting.
//When a room becomes unused, meetings that have an earlier original start time should be given the room.
//Return the number of the room that held the most meetings.If there are multiple rooms, return the room with the lowest number.

//A half-closed interval [a, b) is the interval between a and b including a and not including b.
/// </summary>
public class _02402_MeetingRoomsIII
{
    // Room # : Room # (min-heap)
    PriorityQueue<int, int> availableRooms;
    // (Room #, end time) : end time (min-heap based on end time)
    // NEED to sort by end time, THEN by the room number!!! Since the lowest room # gets picked first. (otherwise it fails in unit test 80)
    PriorityQueue<(long time, int num), (long, int)> roomsInUse;
    int[] roomCounter;
    int maxRooms;

    public int MostBooked(int n, int[][] meetings)
    {
        maxRooms = n;
        availableRooms = new PriorityQueue<int, int>();
        availableRooms.EnqueueRange(Enumerable.Range(0, n).Select(i => (i, i)));
        roomsInUse = new PriorityQueue<(long, int), (long, int)>();
        roomCounter = new int[n];
        // Sort meetings by start time.
        meetings = meetings.OrderBy(i => i[0]).ToArray();
        //int currentTime = 0;
        for (int i = 0; i < meetings.Length; i++)
        {
            int[] meeting = meetings[i];
            FlushMeetingsEnded(meeting[0]);
            // First check for available room.
            if (availableRooms.Count != 0)
            {
                AddMeetingToAvailableRoom(meeting[1]);
            }
            else
            {
                // No available room? Wait for a room in use to become available.
                // Thankfully it's at the top of the pq roomsInUse!
                var room = roomsInUse.Dequeue();
                availableRooms.Enqueue(room.num, room.num);
                // new end time is the room available time + (new meeting end time - new meeting start time)
                long duration = meeting[1] - meeting[0];
                AddMeetingToAvailableRoom(room.time + duration);
            }
        }

        int maxCount = 0;
        int roomWithMaxCount = -1;
        for (int i = 0; i < n; i++)
        {
            if (roomCounter[i] > maxCount)
            {
                maxCount = roomCounter[i];
                roomWithMaxCount = i;
            }
        }
        return roomWithMaxCount;
    }

    void FlushMeetingsEnded(long time)
    {
        while (roomsInUse.Count != 0 && roomsInUse.Peek().time <= time)
        {
            var room = roomsInUse.Dequeue();
            availableRooms.Enqueue(room.num, room.num);
        }
    }

    void AddMeetingToAvailableRoom(long endTime)
    {
        int roomToAdd = availableRooms.Dequeue();
        roomsInUse.Enqueue((endTime, roomToAdd), (endTime, roomToAdd));
        roomCounter[roomToAdd]++;
    }
}