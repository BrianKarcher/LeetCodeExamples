using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    We have n jobs, where every job is scheduled to be done from startTime[i] to endTime[i], obtaining a profit of profit[i].

    //You're given the startTime, endTime and profit arrays, return the maximum profit you can take such that there are no two jobs in the subset with overlapping time range.

    //If you choose a job that ends at time X you will be able to start another job that starts at time X.
    /// </summary>
    public class _01235_MaximumProfitInJobScheduling_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        int[] memo = new int[50001];

        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            // Unsure if the start times are in order, so let's sort them and toss into Tuple while we are at it
            List<(int start, int end, int profit)> jobs = new List<(int, int, int)>();
            for (int i = 0; i < startTime.Length; i++)
            {
                jobs.Add((startTime[i], endTime[i], profit[i]));
            }
            // sort by Start times to find overlaps - it is these overlaps where we will have to recurse
            // to find the optimal profit.
            jobs = jobs.OrderBy(i => i.start).ToList();
            Array.Fill(memo, -1);

            return FindMaxProfit(jobs, 0);
        }

        public int FindMaxProfit(List<(int start, int end, int profit)> jobs, int index)
        {
            // 0 profit if we have already iterated over all the jobs
            if (index == jobs.Count)
                return 0;

            if (memo[index] != -1)
                return memo[index];

            // Two options can be taken for any job. We can take it or we can skip it.
            // We will find the maximum profit if we take a job or skip it, then return the max profit
            // from that decision incremented with this jobs profit if we took the job

            // use Binary Search to find the next job - the closest one to this job's ending value
            int nextIndex = FindNextJob(jobs, jobs[index].end);

            // If we skip this job, no profit from this job
            int maxProfit = Math.Max(jobs[index].profit + FindMaxProfit(jobs, nextIndex),
                                     FindMaxProfit(jobs, index + 1));

            memo[index] = maxProfit;
            return maxProfit;
        }

        public int FindNextJob(List<(int start, int end, int profit)> jobs, int endTime)
        {
            int start = 0;
            int end = jobs.Count - 1;
            int nextIndex = jobs.Count;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (jobs[mid].start >= endTime)
                {
                    nextIndex = mid;
                    end = mid - 1;
                }
                else
                    start = mid + 1;
            }
            return nextIndex;
        }
    }
}