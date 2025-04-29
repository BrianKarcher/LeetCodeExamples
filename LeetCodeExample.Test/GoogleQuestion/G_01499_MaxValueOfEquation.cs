using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //You are given an array points containing the coordinates of points on a 2D plane, sorted by the x-values, where points[i] = [xi, yi] such that xi<xj for all 1 <= i<j <= points.length.You are also given an integer k.

    //Return the maximum value of the equation yi + yj + |xi - xj| where |xi - xj| <= k and 1 <= i<j <= points.length.

    //It is guaranteed that there exists at least one pair of points that satisfy the constraint |xi - xj| <= k.
    /// </summary>
    public class G_01499_MaxValueOfEquation
    {
        public int FindMaxValueOfEquation(int[][] points, int k)
        {
            PriorityQueue<(int dist, int i)> pq = new PriorityQueue<(int dist, int i)>(Comparer<(int dist, int i)>.Create((i1, i2) => i1.dist > i2.dist ? 1 : -1));

            int max = Int32.MinValue;
            foreach (var point in points)
            {
                // Remove any item that is greater than k distance on the X axis
                while (pq.Count() != 0 && pq.Peek().i + k < point[0])
                {
                    pq.Dequeue();
                }

                if (pq.Count() != 0)
                {
                    var dist = pq.Peek().dist + point[0] + point[1];
                    max = Math.Max(max, dist);
                }

                pq.Enqueue((point[1] - point[0], point[0]));
            }
            return max;
        }
    }
}