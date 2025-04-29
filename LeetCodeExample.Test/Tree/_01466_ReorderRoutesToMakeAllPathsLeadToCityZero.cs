using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
namespace LeetCodeExample.Test;

/// <summary>
//There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way to travel between two different cities(this network form a tree). Last year, The ministry of transport decided to orient the roads in one direction because they are too narrow.
//Roads are represented by connections where connections[i] = [ai, bi] represents a road from city ai to city bi.

//This year, there will be a big event in the capital (city 0), and many people want to travel to this city.

//Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.

//It's guaranteed that each city can reach city 0 after reorder.
/// </summary>
public class _01466_ReorderRoutesToMakeAllPathsLeadToCityZero
{
    Dictionary<int, List<(int, int)>> adjList = new();
    bool[] visited;

    public int MinReorder(int n, int[][] connections)
    {
        visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            adjList.Add(i, new List<(int, int)>());
        }
        for (int i = 0; i < connections.Length; i++)
        {
            adjList[connections[i][0]].Add((connections[i][1], 1));
            adjList[connections[i][1]].Add((connections[i][0], 0));
        }

        visited[0] = true;
        return dfs(0);
    }

    int dfs(int i)
    {
        int count = 0;
        // Roads going away need to be flipped, add one to each of these
        foreach ((int n, int cost) in adjList[i])
        {
            if (visited[n])
                continue;
            visited[n] = true;
            count+= cost;
            count += dfs(n);
        }
        return count;
    }
}