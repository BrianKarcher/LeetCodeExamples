using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array nums, you are allowed to choose one element of nums and change it by any value in one move.
    // Return the minimum difference between the largest and smallest value of nums after perfoming at most 3 moves.
    /// </summary>
    public class _001509_3MovesMinDifference_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = MinDifference_Online(new int[] { 5, 3, 2, 4 });
            Assert.AreEqual(0, answer);

            answer = MinDifference_Online(new int[] { 1, 5, 0, 10, 14 });
            Assert.AreEqual(1, answer);

            answer = MinDifference_Online(new int[] { 6, 6, 0, 1, 1, 4, 6 });
            Assert.AreEqual(2, answer);

            answer = MinDifference_Online(new int[] { 1, 5, 6, 14, 15 });
            Assert.AreEqual(1, answer);
        }

        public int MinDifference(int[] nums)
        {
            if (nums.Length <= 3)
                return 0;

            var sortedNums = nums.OrderBy(i => i).ToArray();
            //int lo = sortedNums[0];
            //int hi = sortedNums[sortedNums.Length - 1];
            //int diff = hi - lo;

            int loIndex = 0;
            int hiIndex = sortedNums.Length - 1;

            for (int i = 0; i < 3; i++)
            {
                int lowDelta = sortedNums[loIndex + 1] - sortedNums[loIndex];
                int hiDelta = sortedNums[hiIndex] - sortedNums[hiIndex - 1];
                // If the difference between the lowest value and its next lowest value is
                // higher than the difference between the higest value and its next highest value
                if (lowDelta > hiDelta)
                {
                    // Increment the lo index
                    loIndex++;
                }
                else
                {
                    hiIndex--;
                }

            }

            return sortedNums[hiIndex] - sortedNums[loIndex];
        }

        public int MinDifference_BruteForce(int[] nums)
        {
            if (nums.Length <= 3)
                return 0;

            var sortedNums = nums.OrderBy(i => i).ToArray();

            int lo = 0;
            int hi = sortedNums.Length - 1;

            return BruteForceRecursive(sortedNums, lo, hi, 0);
        }

        public int BruteForceRecursive(int[] nums, int lo, int hi, int count)
        {
            if (count == 3)
                return nums[hi] - nums[lo];
            count++;

            int loVal = BruteForceRecursive(nums, lo + 1, hi, count);
            int hiVal = BruteForceRecursive(nums, lo, hi - 1, count);

            return loVal < hiVal ? loVal : hiVal;
        }




        /// <summary>
        /// //////////////////////////////
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>



        private const int reducedSize = 4;
        // Uses a Greedy Sort, O(n)
        public int MinDifference_Online(int[] nums)
        {
            if (nums.Length < reducedSize)
                return 0;

            int[] mins = new int[reducedSize];
            int[] maxs = new int[reducedSize];

            for (int i = 0; i < reducedSize; i++)
            {
                mins[i] = int.MaxValue;
                maxs[i] = int.MinValue;
            }

            foreach (int num in nums)
            {
                for (int i = 0; i < reducedSize; i++)
                    if (num <= mins[i])
                    {
                        PushDown(mins, num, i);
                        break;
                    }

                for (int i = 0; i < reducedSize; i++)
                    if (num >= maxs[i])
                    {
                        PushDown(maxs, num, i);
                        break;
                    }
            }

            return BestDistance(mins, maxs);
        }

        private int BestDistance(int[] mins, int[] maxs)
        {
            int result = maxs[0] - mins[0];

            // Sliding Window
            for (int i = 0; i < reducedSize; ++i)
            {
                result = Math.Min(result, maxs[i] - mins[reducedSize - 1 - i]);
            }

            return result;
        }

        private void PushDown(int[] arr, int num, int pushIndex)
        {
            int toPushDown = arr[pushIndex];
            arr[pushIndex] = num;

            if (pushIndex >= arr.Length - 1)
                return;

            PushDown(arr, toPushDown, pushIndex + 1);
        }
    }
}