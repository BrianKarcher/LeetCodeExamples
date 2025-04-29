using LeetCodeExample.Test.UnionFind2;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.InteropServices;
namespace LeetCodeExample.Test;

/// <summary>
//You are given a positive integer n representing n cities numbered from 1 to n.You are also given a 2D array roads where roads[i] = [ai, bi, distancei] indicates that there is a bidirectional road between cities ai and bi with a distance equal to distancei. The cities graph is not necessarily connected.
//The score of a path between two cities is defined as the minimum distance of a road in this path.

//Return the minimum possible score of a path between cities 1 and n.

//Note:

//A path is a sequence of roads between two cities.
//It is allowed for a path to contain the same road multiple times, and you can visit cities 1 and n multiple times along the path.
//The test cases are generated such that there is at least one path between 1 and n.
/// </summary>
public class _02492_MinimumScoreofPathBetweenTwoCities
{
    List<(int d, int c)>[] adjList;
    HashSet<int> visited = new();
    int min = Int32.MaxValue;

    public int MinScore(int n, int[][] roads)
    {
        adjList = new List<(int, int)>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            adjList[i] = new List<(int, int)>();
        }
        for (int i = 0; i < roads.Length; i++)
        {
            adjList[roads[i][0]].Add((roads[i][1], roads[i][2]));
            adjList[roads[i][1]].Add((roads[i][0], roads[i][2]));
        }
        visited.Add(1);
        dfs(1);
        return min;
    }

    public void dfs(int curr)
    {
        foreach ((int dest, int cost) in adjList[curr])
        {
            min = Math.Min(min, cost);
            if (visited.Contains(dest))
            {
                continue;
            }
            visited.Add(dest);
            dfs(dest);
        }
    }
}