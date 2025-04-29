using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00785_IsGraphBipartite
    {
        // Node : isLeft
        Dictionary<int, bool> color = new Dictionary<int, bool>();

        public bool IsBipartite(int[][] graph)
        {
            // We need to traverse the entire graph to make sure we visit all nodes
            // As not all nodes are guaranteed to be connected
            for (int i = 0; i < graph.Length; i++)
            {
                // Skip viisted nodes
                if (!color.ContainsKey(i))
                {
                    color.Add(i, true);
                    if (!IsBipartite(true, i, graph))
                        return false;
                }
            }
            return true;
        }

        // Recurse
        bool IsBipartite(bool isLeft, int node, int[][] graph)
        {
            // Get adjacent nodes
            var adjArr = graph[node];
            for (int i = 0; i < adjArr.Length; i++)
            {
                // Have we already visited this node?
                if (!color.ContainsKey(adjArr[i]))
                {
                    color.Add(adjArr[i], !isLeft);
                    // We switch between left and right
                    if (!IsBipartite(!isLeft, adjArr[i], graph))
                    {
                        return false;
                    }
                }
                else
                {
                    // Check to see if the node is already in the wrong list. If it is in the wrong list already,
                    // then the graph is NOT bipartite
                    bool clr = color[adjArr[i]];
                    if (isLeft && clr)
                        return false;
                    if (!isLeft && !clr)
                        return false;
                }
            }
            return true;
        }
    }
}