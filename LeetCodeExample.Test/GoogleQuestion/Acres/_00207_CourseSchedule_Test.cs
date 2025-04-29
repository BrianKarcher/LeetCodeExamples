using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
    //    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
    //Return true if you can finish all courses.Otherwise, return false.
    /// </summary>
    public class _00207_CourseSchedule_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // We use color coding to make sure we only ever visit a course once to keep it O(n).
        const int WHITE = 0;
        const int GRAY = 1;
        const int BLACK = 2;

        int[] visited;
        bool canFinish = true;

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            visited = new int[numCourses];

            // Build an Adjacency List to link courses to their prerequisites
            List<List<int>> adjList = new List<List<int>>(numCourses);
            for (int i = 0; i < numCourses; i++)
                adjList.Add(new List<int>());

            foreach (var prereq in prerequisites)
            {

                var lst = adjList[prereq[0]];
                if (lst == null)
                {
                    lst = new List<int>();
                    adjList.Add(lst);
                }
                lst.Add(prereq[1]);
            }

            // The ONLY way you cannot finish is if there is a cycle. So let's do a cycle check
            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == WHITE)
                    dfs(adjList, i);
            }
            return canFinish;
        }

        public void dfs(List<List<int>> adjList, int index)
        {
            if (!canFinish)
                return;
            // Already visited, return true;
            if (visited[index] == BLACK)
                return;

            // Cycle detected! Cannot finish!
            if (visited[index] == GRAY)
            {
                canFinish = false;
                return;
            }

            visited[index] = GRAY;

            // Visit each child BEFORE turning this node to black, very important
            foreach (var prereq in adjList[index])
            {
                dfs(adjList, prereq);
            }

            visited[index] = BLACK;
        }
    }
}