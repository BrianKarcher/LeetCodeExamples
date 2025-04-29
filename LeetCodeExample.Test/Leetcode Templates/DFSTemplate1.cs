using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Leetcode_Templates
{
    public class DFSTemplate1
    {
        /*
         * Return true if there is a path from cur to target.
         */
        bool DFS(Node cur, Node target, HashSet<Node> visited)
        {
            if (cur == target)
                return true;

            for (int i = 0; i < cur.neighbors.Count; i++)
            {
                if (visited.Contains(cur.neighbors[i]))
                    continue;
                visited.Add(cur.neighbors[i]);

                if (DFS(cur.neighbors[i], target, visited) == true)
                    return true;
            }
            return false;
        }

        public class Node
        {
            public int val;
            public List<Node> neighbors;
        }
    }
}
