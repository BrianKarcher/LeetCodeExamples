using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _02013_DetectSquares
    {
        // For a particular x value, store all the distinct y's
        Dictionary<int, HashSet<int>> xs = new Dictionary<int, HashSet<int>>();
        int[,] points;

        public _02013_DetectSquares()
        {
            points = new int[1001,1001];
        }

        public void Add(int[] point)
        {
            if (!xs.ContainsKey(point[0]))
            {
                xs.Add(point[0], new HashSet<int>());
            }
            xs[point[0]].Add(point[1]);

            points[point[0], point[1]]++;
        }

        public int Count(int[] point)
        {
            if (!xs.ContainsKey(point[0]))
            {
                return 0;
            }
            int x2 = point[0];
            int rtn = 0;
            foreach (var y1 in xs[x2])
            {
                // We have a point and a given y. From that we can check all points in a square
                if (y1 == point[1])
                {
                    continue;
                }
                int y2 = point[1];
                // There are two ways to form a square, left or right. Check left first.
                int x1 = point[0] - Math.Abs(y2 - y1);
                rtn += points[x1, y1] * points[x2, y1] * points[x1, y2];
                // Now check right
                x1 = point[0] + Math.Abs(y2 - y1);
                rtn += points[x1, y1] * points[x2, y1] * points[x1, y2];
            }
            return rtn;
        }
    }
}