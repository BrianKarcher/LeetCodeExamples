using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.
    /// </summary>
    public class _00149_MaxPointsOnALine
    {
        public int MaxPoints(int[][] points)
        {
            if (points.Length == 1)
                return 1;
            // line : points on line
            //Dictionary<(float yInt, float slope), int> lines = new Dictionary<(float yInt, float slope), int>();
            Dictionary<(float yInt, float slope), HashSet<(int, int)>> lines = new Dictionary<(float yInt, float slope), HashSet<(int, int)>>();
            // X-Int : points on line
            //Dictionary<float, int> vertLines = new Dictionary<float, int>();
            Dictionary<float, HashSet<(int, int)>> vertLines = new Dictionary<float, HashSet<(int, int)>>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    // A verticle line would return a divide by zero error, put those in a different dictionary
                    if (points[i][0] == points[j][0])
                    {
                        if (!vertLines.ContainsKey(points[i][0]))
                            vertLines.Add(points[i][0], new HashSet<(int, int)>());
                        vertLines[points[i][0]].Add((points[i][0], points[i][1]));
                        vertLines[points[j][0]].Add((points[j][0], points[j][1]));
                    }
                    else
                    {
                        var line = GetLine(points[i][0], points[i][1], points[j][0], points[j][1]);
                        if (!lines.ContainsKey(line))
                            lines.Add(line, new HashSet<(int, int)>());
                        lines[line].Add((points[i][0], points[i][1]));
                        lines[line].Add((points[j][0], points[j][1]));
                    }
                }
            }

            int max = 0;
            foreach (var line in lines)
            {
                //Console.WriteLine($"{line.Key.yInt}, {line.Key.slope}, {line.Value}");
                max = Math.Max(max, line.Value.Count);
            }
            foreach (var line in vertLines)
            {
                max = Math.Max(max, line.Value.Count);
            }
            return max;
        }

        (float yInt, float slope) GetLine(int x1, int y1, int x2, int y2)
        {
            float slope = (float)(y2 - y1) / (float)(x2 - x1);
            // Gotta get y-intercept
            // y = mx + b
            // b = y - mx
            float yInt = y1 - slope * x1;
            return (yInt, slope);
        }
    }
}