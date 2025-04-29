using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given an array trees where trees[i] = [xi, yi] represents the location of a tree in the garden.

//Fence the entire garden using the minimum length of rope, as it is expensive.The garden is well-fenced only if all the trees are enclosed.

//Return the coordinates of trees that are exactly located on the fence perimeter.You may return the answer in any order.
/// </summary>
public class _00587_ErectTheFence
{
    // This has a bug.
    public int[][] OuterTrees(int[][] trees)
    {
        // Ordered points that we will return.
        List<int[]> points = new();
        // Quick check 
        //HashSet<(int, int)> hash = new();  

        // Find any of the left-most points as a starting point.
        // It doesn't matter which left-most point since the algorithm will handle any.
        (int x, int y) nextPoint = (0, 0);
        int minX = Int32.MaxValue;
        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i][0] < minX)
            {
                nextPoint = (trees[i][0], trees[i][1]);
                minX = trees[i][0];
            }
        }

        points.Add(new int[] { nextPoint.x, nextPoint.y });
        // Start with a vector pointing straight down.
        // Going forward this is the vector between the last two points.
        (int x, int y) currentVector = (0, -1);

        while (true)
        {
            // Find the tree with the minimum angle between it and the last point, 
            // and this vector.
            // Can be any tree so check them all.
            Console.WriteLine($"CurrentVector: {currentVector}");
            nextPoint = (0, 0);
            double minAngle = double.MaxValue;
            (int x, int y) lastPoint = (points[points.Count - 1][0], points[points.Count - 1][1]);
            for (int i = 0; i < trees.Length; i++)
            {
                // Skip the last point added.
                if (trees[i][0] == lastPoint.x && trees[i][1] == lastPoint.y)
                {
                    continue;
                }
                Console.WriteLine($"Checking ({trees[i][0]}, {trees[i][1]})");
                (int x, int y) newVector = (lastPoint.x - trees[i][0], lastPoint.y - trees[i][1]);
                double angle = Math.Atan2(currentVector.y - newVector.y, currentVector.x - newVector.x);
                Console.WriteLine($"Performing atan2 on ({currentVector.y - newVector.y}, {currentVector.x - newVector.x})");
                Console.WriteLine($"Angle between {currentVector} and {newVector}: {angle}");
                if (angle < minAngle)
                {
                    Console.WriteLine($"Setting angle to {angle}");
                    minAngle = angle;
                    nextPoint = (trees[i][0], trees[i][1]);
                }
            }

            // If the loop is complete, just return the points.
            if (points[0][0] == nextPoint.x && points[0][1] == nextPoint.y)
            {
                return points.ToArray();
            }
            points.Add(new int[] { nextPoint.x, nextPoint.y });
            currentVector = (lastPoint.x - nextPoint.x, lastPoint.y - nextPoint.y);
        }
    }
}