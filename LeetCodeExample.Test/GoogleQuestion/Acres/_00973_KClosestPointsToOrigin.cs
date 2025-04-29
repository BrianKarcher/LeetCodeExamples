using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin(0, 0).
    //The distance between two points on the X-Y plane is the Euclidean distance(i.e., √(x1 - x2)2 + (y1 - y2)2).
    //You may return the answer in any order.The answer is guaranteed to be unique (except for the order that it is in).
    /// </summary>
    public class _00973_KClosestPointsToOrigin
    {
        public int[][] KClosest(int[][] points, int k)
        {
            List<(float dist, int index)> calc = new List<(float, int)>();

            for (int i = 0; i < points.Length; i++)
            {
                int x = points[i][0];
                int y = points[i][1];
                // Using Distance Squared space. Since it is around the origin, we just need to do X*X + Y*Y
                float dist = (x * x) + (y * y);
                calc.Add((dist, i));
            }
            var orderedCalc = calc.OrderBy(i => i.dist).ToList();

            //List<int[]> rtn = new List<int[]>();
            int[][] rtn = new int[k][];
            for (int i = 0; i < k; i++)
            {
                int index = orderedCalc[i].index;
                //rtn.Add(points[index]);
                rtn[i] = points[index];
            }
            return rtn;
        }
    }
}