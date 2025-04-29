using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
    // You can either start from the step with index 0, or the step with index 1.
    // Return the minimum cost to reach the top of the floor.
    /// </summary>
    public class _00746_MinCostClimbingStairs_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = MinCostClimbingStairs(new int[] { 10, 15, 20 });
            Assert.AreEqual(15, answer); // Cheapest is: start on cost[1], pay that cost, and go to the top.

            answer = MinCostClimbingStairs(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 });
            Assert.AreEqual(6, answer); // Cheapest is: start on cost[0], and only step on 1s, skipping cost[3].
        }

        Dictionary<int, int> map;

        public int MinCostClimbingStairs(int[] cost)
        {
            map = new Dictionary<int, int>();
            int oneStep = Recurse(cost, 0);
            int twoStep = Recurse(cost, 1);
            return Math.Min(oneStep, twoStep);
        }

        public int Recurse(int[] cost, int i)
        {
            // Base case
            if (i >= cost.Length)
                return 0;
            // The last step, just return the cost, we are done
            if (i == cost.Length - 1)
                return cost[i];

            if (map.ContainsKey(i))
            {
                return map[i];
            }

            // Cost if we take one step
            int minCost1 = Recurse(cost, i + 1);
            // Cost if we take two steps
            int minCost2 = Recurse(cost, i + 2);

            int minCost = Math.Min(minCost1, minCost2) + cost[i];
            map.Add(i, minCost);

            return minCost;
        }

        // Iterative approach
        //public int minCostClimbingStairs(int[] cost)
        //{
        //    // The array's length should be 1 longer than the length of cost
        //    // This is because we can treat the "top floor" as a step to reach
        //    int minimumCost[] = new int[cost.length + 1];

        //    // Start iteration from step 2, since the minimum cost of reaching
        //    // step 0 and step 1 is 0
        //    for (int i = 2; i < minimumCost.length; i++)
        //    {
        //        int takeOneStep = minimumCost[i - 1] + cost[i - 1];
        //        int takeTwoSteps = minimumCost[i - 2] + cost[i - 2];
        //        minimumCost[i] = Math.min(takeOneStep, takeTwoSteps);
        //    }

        //    // The final element in minimumCost refers to the top floor
        //    return minimumCost[minimumCost.length - 1];
        //}

        /////////////////////
        ///

        int?[] memo;

        public int MinCostClimbingStairs2(int[] cost)
        {
            memo = new int?[cost.Length];
            return Math.Min(dp(0, cost), dp(1, cost));
        }

        public int dp(int index, int[] cost)
        {
            if (index >= cost.Length)
            {
                return 0;
            }

            if (memo[index] != null)
            {
                return memo[index].Value;
            }

            int val = cost[index] + Math.Min(dp(index + 1, cost), dp(index + 2, cost));
            memo[index] = val;

            return val;
        }
    }
}