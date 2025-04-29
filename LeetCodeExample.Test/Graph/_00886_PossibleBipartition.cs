using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test;

/// <summary>
//We want to split a group of n people(labeled from 1 to n) into two groups of any size.Each person may dislike some other people, and they should not go into the same group.

//Given the integer n and the array dislikes where dislikes[i] = [ai, bi] indicates that the person labeled ai does not like the person labeled bi, return true if it is possible to split everyone into two groups in this way.
/// </summary>
public class _00886_PossibleBipartition
{
    int NOCOLOR = 0;
    int BLACK = 1;
    int WHITE = 2;
    int[] colors;
    Dictionary<int, List<int>> adjList = new();

    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        colors = new int[n + 1];
        Array.Fill(colors, NOCOLOR);
        for (int i = 1; i <= n; i++)
        {
            adjList.Add(i, new List<int>());
        }
        // Fill adjacency list.
        for (int i = 0; i < dislikes.Length; i++)
        {
            adjList[dislikes[i][0]].Add(dislikes[i][1]);
            adjList[dislikes[i][1]].Add(dislikes[i][0]);
        }

        for (int i = 0; i < dislikes.Length; i++)
        {
            if (colors[dislikes[i][0]] != NOCOLOR)
            {
                continue;
            }
            if (!Recurse(dislikes[i][0], BLACK))
                return false;
        }
        return true;
    }

    bool Recurse(int n, int requestedColor)
    {
        // base case
        if (colors[n] != NOCOLOR)
        {
            //Console.WriteLine($"{n} - Comparing color {colors[n]} to color {requestedColor}");
            return colors[n] == requestedColor;
        }

        //Console.WriteLine($"Setting index {n} to color {requestedColor}");
        colors[n] = requestedColor;
        foreach (int child in adjList[n])
        {
            if (!Recurse(child, requestedColor == BLACK ? WHITE : BLACK))
            {
                return false;
            }
        }
        return true;
    }
}