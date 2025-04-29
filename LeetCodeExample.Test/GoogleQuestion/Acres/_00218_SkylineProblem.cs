using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. Given the locations and heights of all the buildings, return the skyline formed by these buildings collectively.

    //The geometric information of each building is given in the array buildings where buildings[i] = [lefti, righti, heighti]:

    //lefti is the x coordinate of the left edge of the ith building.
    //righti is the x coordinate of the right edge of the ith building.
    //heighti is the height of the ith building.
    //You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.

    //The skyline should be represented as a list of "key points" sorted by their x-coordinate in the form [[x1, y1], [x2, y2],...]. Each key point is the left endpoint of some horizontal segment in the skyline except the last point in the list, which always has a y-coordinate 0 and is used to mark the skyline's termination where the rightmost building ends. Any ground between the leftmost and rightmost buildings should be part of the skyline's contour.

    //   Note: There must be no consecutive horizontal lines of equal height in the output skyline.For instance, [...,[2 3], [4 5], [7 5], [11 5], [12 7],...] is not acceptable; the three lines of height 5 should be merged into one in the final output as such: [...,[2 3],[4 5],[12 7],...]
    /// </summary>
    public class _00218_SkylineProblem
    {
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            List<(int x, int h, bool isStart)> buildingPoints = new List<(int x, int h, bool isStart)>();

            // Fill in the building points
            for (int i = 0; i < buildings.Length; i++)
            {
                // Add building starting point
                buildingPoints.Add((buildings[i][0], buildings[i][2], true));
                // Add building ending point
                buildingPoints.Add((buildings[i][1], buildings[i][2], false));
            }

            buildingPoints.Sort(Comparer<(int x, int h, bool isStart)>.Create((i1, i2) => {
                if (i1.x != i2.x)
                    return i1.x.CompareTo(i2.x);
                else
                    return (i1.isStart ? -i1.h : i1.h) - (i2.isStart ? -i2.h : i2.h);
            }));

            // height : count of buildings at that height
            // I am not using a Heap because heaps have slow, or no, Remove operations for items not at the top of the Heap
            SortedDictionary<int, int> sd = new SortedDictionary<int, int>(Comparer<int>.Create((i1, i2) => {
                return i2.CompareTo(i1);
            }));
            // Removes edge cases and extra if statements
            sd.Add(0, 1);
            IList<IList<int>> rtn = new List<IList<int>>();

            int prevHeight = 0;
            for (int i = 0; i < buildingPoints.Count; i++)
            {
                if (buildingPoints[i].isStart)
                {
                    // Start of new building, let's add it to the dictionary
                    if (!sd.ContainsKey(buildingPoints[i].h))
                        sd.Add(buildingPoints[i].h, 0);
                    sd[buildingPoints[i].h]++;
                }
                else
                {
                    if (!sd.ContainsKey(buildingPoints[i].h))
                        sd.Add(buildingPoints[i].h, 0);
                    sd[buildingPoints[i].h]--;
                    if (sd[buildingPoints[i].h] == 0)
                        sd.Remove(buildingPoints[i].h);
                }

                // The last height is always the biggest because sorting
                var highestHeight = sd.First().Key;
                if (prevHeight != highestHeight)
                {
                    rtn.Add(new List<int>() { buildingPoints[i].x, highestHeight });
                    prevHeight = highestHeight;
                }
            }
            return rtn;
        }


        public IList<IList<int>> GetSkyline2(int[][] buildings)
        {
            // Sort of an advanced Merge Intervals problem
            // The horizontal lines at the top of the buildings being the intervals
            // Main differences are the differing heights, and what to do on an overlap

            // Returned list of points
            List<IList<int>> rtn = new List<IList<int>>();

            // Buildings are already sorted by "left" position. There are a variety of ways to 
            // deal with an overlap
            // OVERLAP CONDITIONS
            // Lower segment covers the range of an upper segment. Create upper segment, cut lower segment 
            // into two pieces to remove all overlap

            /*List<(int l, int r, int h)> active = new List<(int l, int r, int h)>();
            for (int i = 0; i < buildings; i++) {
                if (active.Count > 0) {

                }
                active.Add((buildings[i][0], buildings[i][1], buildings[i][2]));
            }*/

            // Thinking about starting with the tallest structure first. It might make 
            // calculations easier and reduces edge cases

            PriorityQueue<(int l, int r, int h)> pq = new PriorityQueue<(int l, int r, int h)>((i1, i2) =>
            {
                if (i1.h == i2.h)
                    return 0;
                if (i1.h > i2.h)
                    return -1;
                return 1;
            });

            // Go left to right. The buildings are already sorted by "left".
            // Find clustered (overlapping) buildings and place them in a PriorityQueue
            // The PriorityQueue sorts them by Height. Sorting this way makes it easier
            // to build the line segments since the tallest building in the cluster takes priority
            // You can also use two pointers that extend outwards from the cluster as you add each building
            // to make adding the next line segment easy
            int l = 0;
            int r = 0;
            for (int i = 0; i < buildings.Length; i++)
            {
                if (pq.Count() == 0)
                {
                    l = buildings[i][0];
                    r = buildings[i][1];
                    pq.Enqueue((buildings[i][0], buildings[i][1], buildings[i][2]));
                }
                else
                {
                    // Determine whether or not we need to do a merge
                    if (buildings[i][0] <= r)
                    {
                        // Extend the size of the cluster, if needed
                        r = Math.Max(r, buildings[i][1]);
                        // Buildings overlap, add it to the pq
                        pq.Enqueue((buildings[i][0], buildings[i][1], buildings[i][2]));
                    }
                    else
                    {
                        ConvertPriorityQueue(pq, rtn);

                        // This is the beginning of a new cluster so let's reset l and r for this building
                        l = buildings[i][0];
                        r = buildings[i][1];
                        // pq is now empty, so we can finally add this building
                        pq.Enqueue((buildings[i][0], buildings[i][1], buildings[i][2]));
                    }
                }
            }
            ConvertPriorityQueue(pq, rtn);
            var orderedRtn = rtn.OrderBy(i => i[0]).ToList();
            return orderedRtn;
        }

        void ConvertPriorityQueue(PriorityQueue<(int l, int r, int h)> pq, List<IList<int>> rtn)
        {
            if (pq.Count() == 0)
                return;
            // This is the start of a new cluster
            // So let's empty the PriorityQueue and merge the line segments
            int r = Int32.MinValue;
            int l = Int32.MaxValue;
            int h = 0;
            bool isFirst = true;

            while (pq.Count() != 0)
            {
                var building = pq.Dequeue();
                Console.WriteLine($"Dequeued Building: ({building.l}, {building.r}, {building.h})");
                if (isFirst)
                {
                    isFirst = false;
                    // First building? Just add the line segment
                    l = building.l;
                    r = building.r;
                    h = building.h;
                    rtn.Add(new List<int> { building.l, building.h });
                }
                else if (building.h == h)
                {
                    // Line segments at the same height, just extend the r and l, but don't create
                    // a new point
                    l = Math.Min(l, building.l);
                    r = Math.Max(r, building.r);
                }
                else if (building.l < l)
                {
                    // Poking out to the left, create a point and extend left pointer
                    rtn.Add(new List<int> { building.l, building.h });
                    l = building.l;
                }
                else if (building.r > r)
                {
                    // Poking out to the right
                    rtn.Add(new List<int> { r, building.h });
                    r = building.r;
                }
            }
            // Need one more point at the bottom right of the rightmost building
            rtn.Add(new List<int> { r, 0 });
        }
    }
}