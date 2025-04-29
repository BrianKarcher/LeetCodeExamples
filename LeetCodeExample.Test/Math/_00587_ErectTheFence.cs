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
    // This has a bug. But it's close.
    public int[][] OuterTrees(int[][] trees)
    {
        // Ordered points that we will return.
        List<int[]> points = new();
        // Quick check 
        HashSet<(int, int)> hash = new();  

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
        Console.WriteLine($"Adding point {nextPoint}");
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
            double minDistance = double.MaxValue;
            (int x, int y) lastPoint = (points[points.Count - 1][0], points[points.Count - 1][1]);
            Console.WriteLine($"LastPoint: {lastPoint}");
            for (int i = 0; i < trees.Length; i++)
            {
                // Skip the last point added.
                if (trees[i][0] == lastPoint.x && trees[i][1] == lastPoint.y)
                {
                    continue;
                }
                Console.WriteLine($"Checking ({trees[i][0]}, {trees[i][1]})");
                (int x, int y) thisPoint = (trees[i][0], trees[i][1]);
                (int x, int y) newVector = (thisPoint.x - lastPoint.x, thisPoint.y - lastPoint.y);
                Console.WriteLine($"New vector: {newVector}");
                // TODO - Atan2 is NOT the function to get the angle between vectors. To get angle between vectors, do:
                // https://byjus.com/maths/angle-between-two-vectors/
                // acos((A DOT B) / len(A)*len(b))
                // To optimize the solution create a vector length function using the Distance formula
                // and a Get Angle function using the formula above
                //double angle = Math.Atan2(newVector.y - currentVector.y, newVector.x - currentVector.x);
                double angle = Angle(currentVector, newVector);
                Console.WriteLine($"Performing atan2 on ({newVector.y - currentVector.y}, {newVector.x - currentVector.x})");
                Console.WriteLine($"Angle between {currentVector} and {newVector}: {angle}");
                if (angle < minAngle)
                {
                    Console.WriteLine($"Setting angle to {angle}");
                    minAngle = angle;
                    nextPoint = thisPoint;
                    minDistance = Distance(lastPoint, nextPoint);
                }
                else if (angle - minAngle < double.Epsilon && Distance(lastPoint, thisPoint) < minDistance)
                {
                    Console.WriteLine($"Setting angle to {angle}");
                    minAngle = angle;
                    nextPoint = thisPoint;
                    minDistance = Distance(lastPoint, nextPoint);
                }
            }

            // If the loop is complete, just return the points.
            if (points[0][0] == nextPoint.x && points[0][1] == nextPoint.y)
            {
                return points.ToArray();
            }
            Console.WriteLine($"Adding point {nextPoint}");
            if (hash.Contains(nextPoint))
            {
                return points.ToArray();
            }
            points.Add(new int[] { nextPoint.x, nextPoint.y });
            hash.Add(nextPoint);
            currentVector = (nextPoint.x - lastPoint.x, nextPoint.y - lastPoint.y);
            lastPoint = nextPoint;
        }
    }

    double Angle((int x, int y) v1, (int x, int y) v2)
    {
        return Math.Acos(Dot(v1, v2) / (Magnitude(v1) * Magnitude(v2)));
    }

    int Dot((int x, int y) v1, (int x, int y) v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }

    double Distance((int x, int y) v1, (int x, int y) v2)
    {
        int x = v1.x - v2.x;
        int y = v1.y - v2.y;
        return Magnitude((x, y));
    }

    double Magnitude((int x, int y) v)
    {
        return Math.Sqrt(v.x * v.x + v.y * v.y);
    }
}