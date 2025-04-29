using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.
    /// </summary>
    public class _00084_LargestRectangleInHistogramTest
    {
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxArea = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
                {
                    int currentHeight = heights[stack.Pop()];
                    int currentWidth = i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, currentHeight * currentWidth);
                }
                stack.Push(i);
            }

            while (stack.Peek() != -1)
            {
                int currentHeight = heights[stack.Pop()];
                int currentWidth = heights.Length - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);
            }
            return maxArea;
        }
    }
}