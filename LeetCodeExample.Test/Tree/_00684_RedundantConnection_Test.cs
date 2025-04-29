using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //In this problem, a tree is an undirected graph that is connected and has no cycles.
    //You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional edge added.The added edge has two different vertices chosen from 1 to n, and was not an edge that already existed. The graph is represented as an array edges of length n where edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi in the graph.
    //Return an edge that can be removed so that the resulting graph is a tree of n nodes.If there are multiple answers, return the answer that occurs last in the input.
    /// </summary>
    public class _00684_RedundantConnection_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FindRedundantConnection(new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } });
            Assert.AreEqual(new int[] { 2, 3 }, answer);

            answer = FindRedundantConnection(new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 1, 4 }, new int[] { 1, 5 } });
            Assert.AreEqual(new int[] { 1, 4 }, answer);

            answer = FindRedundantConnection(new int[][] { new int[] { 9, 10 }, new int[] { 5, 8 }, new int[] { 2, 6 }, new int[] { 1, 5 },
                new int[]{ 3, 8 },new int[]{ 4, 9 },new int[]{ 8, 10 },new int[]{ 4, 10 },new int[]{ 6, 8 },new int[] { 7, 9 } });
            Assert.AreEqual(new int[] { 4, 10 }, answer);
        }

        Dictionary<int, List<int>> AdjList;

        public int[] FindRedundantConnection(int[][] edges)
        {
            AdjList = new Dictionary<int, List<int>>();

            //int[] rtn = new int[] { };
            foreach (var edge in edges)
            {
                if (CheckCycle(edge[0], edge[1]))
                    return edge;
                var adj1 = AdjList.GetValueOrDefault(edge[0], new List<int>());
                adj1.Add(edge[1]);
                AdjList.TryAdd(edge[0], adj1);
                var adj2 = AdjList.GetValueOrDefault(edge[1], new List<int>());
                adj2.Add(edge[0]);
                AdjList.TryAdd(edge[1], adj2);
            }
            return new int[] { };
        }

        public bool CheckCycle(int a, int b)
        {
            // Check to see if there is a cycle from a to b.
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue(a);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (!AdjList.ContainsKey(node))
                    continue;
                var list = AdjList[node];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == b)
                        return true;
                    // The graph is undirected, so we added adjacencies both directions. We are just checking if a meets b,
                    // ignore other cycles
                    if (!visited.Contains(list[i]))
                    {
                        visited.Add(list[i]);
                        queue.Enqueue(list[i]);
                    }
                }
            }

            return false;
        }
    }
}