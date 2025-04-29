using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class G_00210_CourseScheduleII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FindOrder(4, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } });
            Assert.AreEqual(0, answer);

            answer = FindOrder(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } });
            Assert.AreEqual(0, answer);

        }

        // Topoligical Sort to find the answer
        int WHITE = 0;
        int GRAY = 1;
        int BLACK = 2;
        int[] colors;
        Dictionary<int, List<int>> adj;
        List<int> topologicalOrder;

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            topologicalOrder = new List<int>();
            colors = new int[numCourses];
            adj = new Dictionary<int, List<int>>();
            // Initialization
            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(i, new List<int>());
            }

            // Set up directional graph
            for (int i = 0; i < prerequisites.Length; i++)
            {
                adj[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (colors[i] == WHITE)
                {
                    dfs(i);
                }
            }

            if (!isPossible)
                return new int[0];

            return topologicalOrder.ToArray();
        }

        bool isPossible = true;
        //int[] complete;
        // Do topoligical sort
        void dfs(int course)
        {
            if (!isPossible)
                return;

            if (colors[course] == BLACK)
            {
                return;
            }

            // Cycle check
            if (colors[course] == GRAY)
            {
                isPossible = false;
                return;
            }

            colors[course] = GRAY;

            var lstAdj = adj[course];
            for (int j = 0; j < lstAdj.Count; j++)
            {
                dfs(lstAdj[j]);
            }
            topologicalOrder.Add(course);

            colors[course] = BLACK;
            return;
        }

        //// Haven't touched it yet
        //const int WHITE = 0;
        //// Seen it, if see gray again then we have cycled - invalid graph!
        //const int GRAY = 1;
        //// Completed node
        //const int BLACK = 2;

        //Dictionary<int, List<int>> AdjList;
        //int[] Color;
        //bool IsPossible = true;

        //List<int> finalList;

        //public int[] FindOrder(int numCourses, int[][] prerequisites)
        //{
        //    AdjList = new Dictionary<int, List<int>>();
        //    // int's default to 0, so no need to set these to white
        //    Color = new int[numCourses];

        //    // Fill Adj List
        //    for (int i = 0; i < prerequisites.Length; i++)
        //    {
        //        var adj = AdjList.GetValueOrDefault(prerequisites[i][0], new List<int>());
        //        adj.Add(prerequisites[i][1]);
        //        AdjList.TryAdd(prerequisites[i][0], adj);
        //    }

        //    finalList = new List<int>();

        //    for (int i = 0; i < numCourses; i++)
        //    {
        //        if (Color[i] == WHITE)
        //        {
        //            dfs(i);
        //        }
        //    }

        //    if (!IsPossible)
        //        return new int[0];

        //    return finalList.ToArray();
        //}

        //void dfs(int node)
        //{
        //    if (!IsPossible)
        //        return;

        //    if (Color[node] == BLACK)
        //        return;

        //    // Revisited node, topolography graph is not possible.
        //    if (Color[node] == GRAY)
        //    {
        //        IsPossible = false;
        //        return;
        //    }

        //    Color[node] = GRAY;

        //    // It's a DFS so the farthest prerequisite gets added to the list first
        //    if (AdjList.TryGetValue(node, out var adjList))
        //    {
        //        foreach (var adj in adjList)
        //        {
        //            dfs(adj);
        //        }
        //    }

        //    Color[node] = BLACK;

        //    finalList.Add(node);
        //}
    }
}