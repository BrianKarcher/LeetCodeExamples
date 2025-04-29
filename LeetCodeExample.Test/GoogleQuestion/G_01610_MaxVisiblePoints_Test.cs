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
    public class G_01610_MaxVisiblePoints_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = VisiblePoints(new List<IList<int>> { new List<int> { 2, 1 }, new List<int> { 2, 2 }, new List<int> { 3, 3 } }, 
                90, new List<int> { 1,1 });
            Assert.AreEqual(3, answer);

            answer = VisiblePoints(new List<IList<int>> { new List<int> { 2, 1 }, new List<int> { 2, 2 }, new List<int> { 3, 3 } },
                30, new List<int> { 1, 1 });
            Assert.AreEqual(2, answer);


            answer = VisiblePoints(new List<IList<int>> { new List<int> { 2, 1 }, new List<int> { 2, 2 }, new List<int> { 3, 4 }, new List<int> { 1, 1 } },
                90, new List<int> { 1, 1 });
            Assert.AreEqual(4, answer);

            answer = VisiblePoints(new List<IList<int>> { new List<int> { 1, 0 }, new List<int> { 2, 1 } },
                13, new List<int> { 1, 1 });
            Assert.AreEqual(1, answer);

            answer = VisiblePoints(new List<IList<int>> { new List<int> { 2, 1 }, new List<int> { 2, 2 }, new List<int> { 3, 4 }, new List<int> { 1, 1 } },
                90, new List<int> { 1, 1 });
            Assert.AreEqual(4, answer);
        }

        //public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location)
        //{
        //    var pointAngles = new List<(int id, float angle)>(points.Count);

        //    int homeLocationCount = 0;
        //    for (int i = 0; i < points.Count; i++)
        //    {
        //        // The FOV calculations will miss the "home location" points edge case, so add those manually
        //        if (points[i][0] == location[0] && points[i][1] == location[1])
        //        {
        //            homeLocationCount++;
        //        }
        //        else
        //        {
        //            pointAngles.Add((i, CalculateAngleBetweenPoints(location[0], location[1], points[i][0], points[i][1])));
        //        }
        //    }

        //    var orderedAngles = pointAngles.OrderBy(i => i.angle).ToList();

        //    // Append the list to itself to handle the cyclic condition
        //    //orderedAngles.AddRange(orderedAngles);

        //    int max = 0;

        //    List<(int id, float angle)> window = new List<(int id, float angle)>();
        //    HashSet<int> pointsInWindow = new HashSet<int>();

        //    // Do two loops to handle the cyclic condition
        //    for (int loop = 0; loop < 2; loop++)
        //    {
        //        // Perform sliding window - does an entire loop to find the max grouping of points within a FOV
        //        for (int i = 0; i < orderedAngles.Count; i++)
        //        {
        //            // Can't include the same point twice
        //            if (pointsInWindow.Contains(orderedAngles[i].id))
        //                continue;

        //            pointsInWindow.Add(orderedAngles[i].id);

        //            window.Add((orderedAngles[i].id, orderedAngles[i].angle));

        //            // If we have moved outside the FOV, trim off points to the left until all points are within the FOV
        //            while (AngleDifference(window[0].angle, window[window.Count - 1].angle) > angle)
        //            {
        //                pointsInWindow.Remove(window[0].id);
        //                window.RemoveAt(0);
        //            }

        //            max = Math.Max(max, window.Count);
        //        }
        //    }
        //    return max + homeLocationCount;
        //}

        public float CalculateAngleBetweenPoints(int x1, int y1, int x2, int y2)
        {
            // atan2 gives a result between -pi and pi.
            var angleInRadians = MathF.Atan2(y2 - y1, x2 - x1);
            // Convert radians to degrees
            return (180f / MathF.PI) * angleInRadians;
        }

        //public float AngleDifference(float a1, float a2)
        //{
        //    // We're going clockwise, keep the signs correct
        //    float a = a2 - a1;
        //    // Ensure the angle is the interior angle
        //    //if (a < -180)
        //    //    a += 360f;
        //    //else if (a > 180)
        //    //    a -= 360f;
        //    return a;
        //}

        public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location)
        {
            var pointAngles = new List<float>(points.Count);

            int homeLocationCount = 0;
            for (int i = 0; i < points.Count; i++)
            {
                // The FOV calculations will miss the "home location" points edge case, so add those manually
                if (points[i][0] == location[0] && points[i][1] == location[1])
                {
                    homeLocationCount++;
                }
                else
                {
                    pointAngles.Add(CalculateAngleBetweenPoints(location[0], location[1], points[i][0], points[i][1]));
                }
            }

            var orderedAngles = pointAngles.OrderBy(i => i).ToList();

            // Do two loops to handle the cyclic condition
            // Append the list to itself to handle the cyclic condition
            int angleCount = orderedAngles.Count;
            for (int i = 0; i < angleCount; i++)
            {
                orderedAngles.Add(orderedAngles[i] + 360);
            }
            

            int max = 0;
            
            // Perform sliding window - does an entire loop to find the max grouping of points within a FOV
            // SLIDING WINDOWS HAVE TWO POINTERS!!!!!!!!!!
            int left = 0;
            int right = 0;
            while (right < orderedAngles.Count)
            {
                while (right < orderedAngles.Count && orderedAngles[right] - orderedAngles[left] <= angle)
                {
                    right++;
                }

                max = Math.Max(max, right - left);
                left++;
            }
            return max + homeLocationCount;
        }
    }
}