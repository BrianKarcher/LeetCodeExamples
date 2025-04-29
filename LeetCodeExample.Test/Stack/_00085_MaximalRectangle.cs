using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
    /// </summary>
    public class _00085_MaximalRectangle
    {
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxArea = 0;

            // swipe right, find the left index that is a smaller height than the current bar
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

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0)
                return 0;

            int maxArea = 0;

            // array of columns
            int[] hist = new int[matrix[0].Length];

            for (int r = 0; r < matrix.Length; r++)
            {
                // Create the histogram for this row so we can use the largest rectangle in histogram algorithm
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == '1')
                        hist[c]++;
                    else
                        hist[c] = 0; // Histogram gets reset if we hit a zero
                }
                int area = LargestRectangleArea(hist);
                maxArea = Math.Max(maxArea, area);
            }
            return maxArea;
        }
    }
}