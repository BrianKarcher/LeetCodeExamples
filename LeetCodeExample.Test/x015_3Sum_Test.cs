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
    public class x015_3Sum_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            Assert.AreEqual(answer[0][0], -1);
            Assert.AreEqual(answer[0][1], 2);
            Assert.AreEqual(answer[0][2], -1);
            Assert.AreEqual(answer[1][0], -1);
            Assert.AreEqual(answer[1][1], 1);
            Assert.AreEqual(answer[1][2], 0);

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



        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var orderedNums = nums.OrderBy(i => i).ToList();

            // Combination of all two pairs, with the negative sum (to find the third value)
            // Higher is always the first value in the tuple to prevent tuplies with duplicate values
            Dictionary<int, List<(int, int)>> remainingWithTwoPair = new Dictionary<int, List<(int, int)>>();

            // Build the twoPairWithRemaining list
            for (int i = 0; i < orderedNums.Count(); i++)
            {
                for (int j = i + 1; j < orderedNums.Count(); j++)
                {
                    // We ordered the values ealier so i is always larger than j
                    int higher = orderedNums[i];
                    int lower = orderedNums[j];
                    int sum = higher + lower;

                    if (!remainingWithTwoPair.ContainsKey(sum))
                    {
                        remainingWithTwoPair.Add(sum, new List<(int, int)>() { (i, j) });
                    }
                }
            }

            List<IList<int>> final = new List<IList<int>>();

            // Iterate through the orderedNums one last time 
            for (int i = 0; i < orderedNums.Count(); i++)
            {
                int val = orderedNums[i] * -1;
                if (!remainingWithTwoPair.ContainsKey(val))
                    continue;

                var tuplesWhereSumPlusThisIsZero = remainingWithTwoPair[val];
                for (int k = 0; k < tuplesWhereSumPlusThisIsZero.Count(); k++)
                {
                    var tuple = tuplesWhereSumPlusThisIsZero[k];
                    if (i == tuple.Item1 || i == tuple.Item2 || tuple.Item1 == tuple.Item2)
                    {
                        // Don't repeat tuples.
                        continue;
                    }

                    // dedup by value
                    int val1 = orderedNums[tuple.Item1];
                    int val2 = orderedNums[tuple.Item2];
                    int val3 = orderedNums[i];

                    bool abort = false;
                    foreach (var f in final)
                    {
                        int count = 3;
                        foreach (var l in f)
                        {
                            if (l == val1 || l == val2 || l == val3)
                                count--;
                        }
                        if (count == 0)
                        {
                            abort = true;
                            break;
                        }
                    }

                    if (abort)
                        continue;

                    final.Add(new List<int>() { val1, val2, val3 });
                }
            }

            //bool abort = false;
            //foreach (var f in final)
            //{
            //    int count = 3;
            //    foreach (var l in f)
            //    {
            //        if (l == val1 || l == val2 || l == val3)
            //            count--;
            //    }
            //    if (count == 0)
            //    {
            //        abort = true;
            //        break;
            //    }
            //}

            //if (abort)
            //    continue;

            return final;
        }
    }
}