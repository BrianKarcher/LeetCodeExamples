using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class MinDifficultyJobSchedule_1335_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            int answer;
            answer = MinDifficulty(new int[] { 1, 1, 1}, 3);
            Assert.AreEqual(3, answer);
            answer = MinDifficulty(new int[] { 6, 5, 4, 3, 2, 1 }, 2);
            Assert.AreEqual(7, answer);
            answer = MinDifficulty(new int[] { 9, 9, 9 }, 4);
            Assert.AreEqual(-1, answer);
            answer = MinDifficulty(new int[] { 7, 1, 7, 1, 7, 1 }, 3);
            Assert.AreEqual(15, answer);
            answer = MinDifficulty(new int[] { 11, 111, 22, 222, 33, 333, 44, 444 }, 6);
            Assert.AreEqual(843, answer);
        }

        Dictionary<(int jobIndex, int day), int> memo;

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (jobDifficulty.Length < d)
                return -1;
            memo = new Dictionary<(int jobIndex, int day), int>();
            return PlaceJobInDay(jobDifficulty, 0, 1, d);
        }

        // Use Dynamic Programming
        //public int PlaceJobInDay(int[] jobDifficulty, int jobIndex, int currentDay, int currentDayDifficulty, int totalDays)
        public int PlaceJobInDay(int[] jobDifficulty, int jobIndex, int currentDay, int totalDays)
        {
            // Don't repeat calculation for an index and day
            if (memo.ContainsKey((jobIndex, currentDay)))
            {
                return memo[(jobIndex, currentDay)];
            }

            // Exit clause - last item in list
            // Last job?
            if (jobIndex == jobDifficulty.Length - 1)
            {
                // More days to calculate?
                if (currentDay != totalDays)
                {
                    memo.Add((jobIndex, currentDay), 0);
                    return 0;
                }
                memo.Add((jobIndex, currentDay), jobDifficulty[jobIndex]);
                return jobDifficulty[jobIndex];
            }

            //int dayDifficulty = jobDifficulty[jobIndex];
            //if (dayDifficulty > currentDayDifficulty)
            //    currentDayDifficulty = dayDifficulty;
            //currentDayDifficulty =  ? dayDifficulty : currentDayDifficulty;
            // Where to place next job?
            // Get min difficulty if we place the job today
            int placeTodayMinDifficulty = PlaceJobInDay(jobDifficulty, jobIndex + 1, currentDay, totalDays);
            // Retain an abort
            if (placeTodayMinDifficulty != 0)
                placeTodayMinDifficulty = Math.Max(placeTodayMinDifficulty, jobDifficulty[jobIndex]);

            // Is there a tomorrow?
            int placeTomorrowMinDifficulty = 0;
            if (currentDay <= totalDays)
            {
                // Get min difficulty if we place the job tomorrow
                placeTomorrowMinDifficulty = PlaceJobInDay(jobDifficulty, jobIndex + 1, currentDay + 1, totalDays);
                // Retain an abort
                if (placeTomorrowMinDifficulty != 0)
                    placeTomorrowMinDifficulty += jobDifficulty[jobIndex];
            }

            int dayDifficulty = 0;
            if (placeTodayMinDifficulty == 0)
            {
                dayDifficulty = placeTomorrowMinDifficulty;
            }
            else if (placeTomorrowMinDifficulty == 0)
            {
                dayDifficulty = placeTodayMinDifficulty;
            }
            else
            {
                dayDifficulty = Math.Min(placeTodayMinDifficulty, placeTomorrowMinDifficulty);
            }
            //if (placeTomorrowMinDifficulty != 0 && placeTodayMinDifficulty < placeTomorrowMinDifficulty)
            //{
            //    dayDifficulty = placeTodayMinDifficulty;
            //}
            //else if (placeTodayMinDifficulty != 0 && placeTomorrowMinDifficulty < placeTodayMinDifficulty)
            //{
            //    dayDifficulty = placeTomorrowMinDifficulty;
            //}

            // Record min difficulty from today forward so we don't repeat our calculation
            memo.Add((jobIndex, currentDay), dayDifficulty);

            return dayDifficulty;
        }
    }
}