using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given a list of bombs.The range of a bomb is defined as the area where its effect can be felt.This area is in the shape of a circle with the center as the location of the bomb.
    //The bombs are represented by a 0-indexed 2D integer array bombs where bombs[i] = [xi, yi, ri].xi and yi denote the X-coordinate and Y-coordinate of the location of the ith bomb, whereas ri denotes the radius of its range.
    //You may choose to detonate a single bomb. When a bomb is detonated, it will detonate all bombs that lie in its range. These bombs will further detonate the bombs that lie in their ranges.

    //Given the list of bombs, return the maximum number of bombs that can be detonated if you are allowed to detonate only one bomb.
    /// </summary>
    public class _02101_DetonateTheMaximumBombs
    {
        Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
        public int MaximumDetonation(int[][] bombs)
        {
            // Init adj list
            for (int i = 0; i < bombs.Length; i++)
            {
                adjList.Add(i, new List<int>());
            }
            // Store which bombs can detonate another bomb in an adj list.
            // Need to check each bomb against each other
            for (int i = 0; i < bombs.Length; i++)
            {
                for (int j = i + 1; j < bombs.Length; j++)
                {
                    double xdist = bombs[i][0] - bombs[j][0];
                    double ydist = bombs[i][1] - bombs[j][1];
                    double dist = Math.Sqrt(xdist * xdist + ydist * ydist);
                    //Console.WriteLine($"{i} {j} {xdist} {ydist} {dist}");

                    if (dist <= bombs[i][2])
                    {
                        // i can blow up j
                        adjList[i].Add(j);
                    }
                    if (dist <= bombs[j][2])
                    {
                        // j can blow up i
                        adjList[j].Add(i);
                    }
                }
            }

            int max = 0;
            // Blow up each initial bomb, then traverse down the graph and count up the other bombs
            // that explode
            // use dfs
            for (int i = 0; i < bombs.Length; i++)
            {
                max = Math.Max(max, BlowUp(i, new HashSet<int>()));
            }
            return max;
        }

        public int BlowUp(int i, HashSet<int> visited)
        {
            if (visited.Contains(i))
            {
                return 0;
            }

            visited.Add(i);
            int count = 1;
            foreach (int j in adjList[i])
            {
                count += BlowUp(j, visited);
            }
            return count;
        }
    }
}