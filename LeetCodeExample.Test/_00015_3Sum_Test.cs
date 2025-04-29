using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    /// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    /// Notice that the solution set must not contain duplicate triplets.
    /// </summary>
    public class _00015_3Sum_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            Assert.AreEqual(-1, answer[0][0]);
            Assert.AreEqual(-1, answer[0][1]);
            Assert.AreEqual(2, answer[0][2]);
            Assert.AreEqual(-1, answer[1][0]);
            Assert.AreEqual(0, answer[1][1]);
            Assert.AreEqual(1, answer[1][2]);
            Assert.AreEqual(2, answer.Count);

            answer = ThreeSum(new int[] { 3, 0, -2, -1, 1, 2 });

            Assert.AreEqual(3, answer.Count());

            //Assert.AreEqual(5, answer);
            //answer = MaxProfit(new int[] { 5, 7, 1, 5, 3, 6, 4 });
            //Assert.AreEqual(5, answer);
            //answer = MaxProfit(new int[] { 7, 6, 4, 3, 1 });
            //Assert.AreEqual(0, answer);

            //answer = ReverseList(ArrToLinkedList(new int[] { 1, 2}));
            //Assert.AreEqual(answer.val, 2);
            //Assert.AreEqual(answer.next.val, 1);
        }



        //public IList<IList<int>> ThreeSum(int[] nums)
        //{
        //    var orderedNums = nums.OrderBy(i => i).ToList();

        //    // Combination of all two pairs, with the negative sum (to find the third value)
        //    // Higher is always the first value in the tuple to prevent tuplies with duplicate values
        //    Dictionary<int, List<(int, int)>> remainingWithTwoPair = new Dictionary<int, List<(int, int)>>();

        //    // Build the twoPairWithRemaining list
        //    for (int i = 0; i < orderedNums.Count(); i++)
        //    {
        //        for (int j = i + 1; j < orderedNums.Count(); j++)
        //        {
        //            // We ordered the values ealier so i is always larger than j
        //            int higher = orderedNums[i];
        //            int lower = orderedNums[j];
        //            int sum = higher + lower;

        //            if (!remainingWithTwoPair.ContainsKey(sum))
        //            {
        //                remainingWithTwoPair.Add(sum, new List<(int, int)>() { (i, j) });
        //            }
        //        }
        //    }

        //    List<IList<int>> final = new List<IList<int>>();

        //    // Iterate through the orderedNums one last time 
        //    for (int i = 0; i < orderedNums.Count(); i++)
        //    {
        //        int val = orderedNums[i] * -1;
        //        if (!remainingWithTwoPair.ContainsKey(val))
        //            continue;

        //        var tuplesWhereSumPlusThisIsZero = remainingWithTwoPair[val];
        //        for (int k = 0; k < tuplesWhereSumPlusThisIsZero.Count(); k++)
        //        {
        //            var tuple = tuplesWhereSumPlusThisIsZero[k];
        //            if (i == tuple.Item1 || i == tuple.Item2 || tuple.Item1 == tuple.Item2)
        //            {
        //                // Don't repeat tuples.
        //                continue;
        //            }

        //            // dedup by value
        //            int val1 = orderedNums[tuple.Item1];
        //            int val2 = orderedNums[tuple.Item2];
        //            int val3 = orderedNums[i];

        //            bool abort = false;
        //            foreach (var f in final)
        //            {
        //                int count = 3;
        //                foreach (var l in f)
        //                {
        //                    if (l == val1 || l == val2 || l == val3)
        //                        count--;
        //                }
        //                if (count == 0)
        //                {
        //                    abort = true;
        //                    break;
        //                }
        //            }

        //            if (abort)
        //                continue;

        //            final.Add(new List<int>() { val1, val2, val3 });
        //        }
        //    }

        //    //bool abort = false;
        //    //foreach (var f in final)
        //    //{
        //    //    int count = 3;
        //    //    foreach (var l in f)
        //    //    {
        //    //        if (l == val1 || l == val2 || l == val3)
        //    //            count--;
        //    //    }
        //    //    if (count == 0)
        //    //    {
        //    //        abort = true;
        //    //        break;
        //    //    }
        //    //}

        //    //if (abort)
        //    //    continue;

        //    return final;
        //}

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var orderedNums = nums.OrderBy(i => i).ToList();
            List<IList<int>> result = new List<IList<int>>();
            // If nums[i] goes past zero, no more sums can equal to zero
            for (int i = 0; i < orderedNums.Count && orderedNums[i] <= 0; i++)
            {
                if (i == 0 || orderedNums[i - 1] != orderedNums[i])
                {
                    TwoSum2(orderedNums, i, result);
                }
            }
            return result;
        }

        public void TwoSum2(List<int> numbers, int i, List<IList<int>> result)
        {
            int lo = i + 1;
            int hi = numbers.Count - 1;

            while (lo < hi)
            {
                int sum = numbers[i] + numbers[lo] + numbers[hi];
                if (sum < 0)
                {
                    lo++;
                }
                else if (sum > 0)
                {
                    hi--;
                }
                else
                {
                    result.Add(new List<int> { numbers[i], numbers[lo], numbers[hi] });
                    lo++;
                    hi--;
                    while (lo < hi && numbers[lo] == numbers[lo - 1])
                        lo++;
                }
            }
        }
    }
}