using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    Given n cuboids where the dimensions of the ith cuboid is cuboids[i] = [widthi, lengthi, heighti] (0-indexed). Choose a subset of cuboids and place them on each other.

    //    You can place cuboid i on cuboid j if widthi <= widthj and lengthi <= lengthj and heighti <= heightj.You can rearrange any cuboid's dimensions by rotating it to put it on another cuboid.

    //Return the maximum height of the stacked cuboids.
    /// </summary>
    public class _01691_MaxHeightByStackingCuboids
    {
        [Test]
        public void Test()
        {
            //var ans = MaxHeight(new int[][] { new int[] { 50, 45, 20 }, new int[] { 95, 37, 53 }, new int[] { 45, 23, 12 } });
            //Assert.AreEqual(190, ans);
            //memo = new Dictionary<int, int>();

            // [[],[],[],[],[],[],[],[],[]]
            var ans = MaxHeight(new int[][] { new int[] { 34, 29, 33 }, new int[] { 7, 25, 75 }, new int[] { 31, 15, 68 },
            new int[] { 80, 80, 38 }, new int[] { 72, 21, 30 }, new int[] { 2, 66, 25 }, new int[] { 59, 36, 6 },
            new int[] { 39, 48, 95 }, new int[] { 35, 85, 71 }, new int[] { 17, 14, 78 } });
            Assert.AreEqual(236, ans);
            //Console.WriteLine($"Ans: {ans}");
        }

        public int MaxHeight(int[][] cuboids)
        {
            // Orient the cubes so width (0) is smallest, length (1) is second smallest, and height (2) is biggest
            for (int i = 0; i < cuboids.Length; i++)
            {
                Array.Sort(cuboids[i]);
            }

            // sort the cuboids from largest to smallest order
            Array.Sort(cuboids, new CustomCompare());

            int[] dp = new int[cuboids.Length]; // dp[i] means max height upto cuboid 'i' (row i)
            int res = 0;

            for (int i = 0; i < cuboids.Length; i++)
            {
                dp[i] = cuboids[i][2]; // we chose the largest side of cuboid to be height to maximize it

                for (int j = 0; j < i; j++)
                {
                    if (cuboids[j][0] >= cuboids[i][0] && cuboids[j][1] >= cuboids[i][1] && cuboids[j][2] >= cuboids[i][2])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + cuboids[i][2]);
                    }
                }

                res = Math.Max(res, dp[i]);
            }

            return res;
        }

        public class CustomCompare : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a[0] != b[0])
                {
                    return b[0] - a[0];
                }
                if (a[1] != b[1])
                {
                    return b[1] - a[1];
                }

                return b[2] - a[2];
            }
        }

        // Order by the height descending
        //var orderedCuboids = cuboids.OrderByDescending(i => i[2]).ToArray();
        //Array.Sort
        //cuboids.OrderBy()
        //Console.WriteLine($"Ordered Cubes Length: {orderedCuboids.Length}");

        //int maxHeight = Int32.MinValue;
        //// We do not know which block is the best one to start on, so need them all to be possible starting blocks
        //for (int i = 0; i < cuboids.Length; i++)
        //{
        //    int height = dp(cuboids, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, i);
        //    //Console.WriteLine($"dp Height: {height}");
        //    maxHeight = Math.Max(maxHeight, height);
        //}
        //return maxHeight;

        //// Key: i, value: height
        //Dictionary<int, int> memo = new Dictionary<int, int>();

        //int dp(int[][] cuboids, int prevWidth, int prevLength, int prevHeight, int i)
        //{
        //    // base case
        //    if (i == cuboids.Length)
        //        return 0;

        //    // If the cube cannot be placed on top of the previous one, skip it
        //    if (cuboids[i][0] > prevWidth || cuboids[i][1] > prevLength || cuboids[i][2] > prevHeight)
        //    {
        //        // No memoization, we only memo on cubes we have actually calculated
        //        //Console.WriteLine($"({cuboids[i][0]}, {cuboids[i][1]}, {cuboids[i][2]} greater than ({prevWidth}, {prevLength}, {prevHeight}))");
        //        return dp(cuboids, prevWidth, prevLength, prevHeight, i + 1);
        //    }

        //    if (memo.ContainsKey(i))
        //        return memo[i];

        //    int height = cuboids[i][2];
        //    int nextHeight = dp(cuboids, cuboids[i][0], cuboids[i][1], cuboids[i][2], i + 1);
        //    //Console.WriteLine($"{height} + {nextHeight}");
        //    height += nextHeight;
        //    memo.Add(i, height);
        //    return height;
        //}
    }
}