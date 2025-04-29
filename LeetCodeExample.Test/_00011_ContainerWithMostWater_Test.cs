using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
     //   Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate(i, ai). n vertical lines are drawn such that the two endpoints of the line i is at(i, ai) and(i, 0). Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.
     // Notice that you may not slant the container.
    /// </summary>
    public class _00011_ContainerWithMostWater_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int MaxArea(int[] height)
        {
            List<string> lst = new List<string>();
            //lst.OrderBy();
            string[] log = new string[];
            Array.Sort(log);
            Char.IsDigit()
            int lo = 0;
            int hi = height.Length - 1;
            int maxArea = 0;
            while (lo <= hi)
            {
                int area = Math.Min(height[lo], height[hi]) * (hi - lo);
                maxArea = Math.Max(maxArea, area);
                if (height[lo] < height[hi])
                    lo++;
                else
                    hi--;
            }
            return maxArea;
        }
    }
}