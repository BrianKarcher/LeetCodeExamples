using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given n non-negative integers representing an elevation map where the width of each bar is 1,
    // compute how much water it can trap after raining.
    /// </summary>
    public class _00042_TrappingRainWater_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public int Trap(int[] height)
        {
            int[] max_left = new int[height.Length];
            int[] max_right = new int[height.Length];

            // Do two passes - one left to right, the other right to left, recording the current max water level during
            // the pass

            max_left[0] = height[0];
            for (int i = 1; i < height.Length; i++)
            {
                max_left[i] = Math.Max(height[i], max_left[i - 1]);
            }

            // Same, but for other direction

            max_right[height.Length - 1] = height[height.Length - 1];
            for (int i = height.Length - 2; i >= 0; i--)
            {
                max_right[i] = Math.Max(height[i], max_right[i + 1]);
            }

            // Now we find where max_left and max_right overlap, subtracted by height
            int waterArea = 0;

            for (int i = 0; i < height.Length; i++)
            {
                waterArea += Math.Min(max_left[i], max_right[i]) - height[i];
            }
            return waterArea;
        }
    }
}