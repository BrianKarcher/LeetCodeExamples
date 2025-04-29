using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    // You must write an algorithm that runs in O(n) time.
    /// </summary>
    public class _00128_LongestConsecutiveSequence_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> num_set = new HashSet<int>();
            foreach (int num in nums)
            {
                num_set.Add(num);
            }

            int longestStreak = 0;

            foreach (int num in num_set)
            {
                if (!num_set.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (num_set.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }

        public int LongestConsecutive2(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            var orderedNums = nums.OrderBy(i => i).ToList();

            int maxConsec = 1;
            int currentConsec = 1;
            for (int i = 1; i < orderedNums.Count; i++)
            {
                // Just skip if the same number
                if (orderedNums[i - 1] == orderedNums[i])
                    continue;
                if (orderedNums[i - 1] == orderedNums[i] - 1)
                {
                    currentConsec++;
                    maxConsec = Math.Max(maxConsec, currentConsec);
                }
                else
                    currentConsec = 1;
            }
            return maxConsec;
        }
    }
}