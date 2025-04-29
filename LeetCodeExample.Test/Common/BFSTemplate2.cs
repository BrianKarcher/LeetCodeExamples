using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test.Leetcode_Templates
{
    class BFSTemplate2
    {
        bool BFS(Node root, int target)
        {
            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();
            while (queue.Any())
            {
                Node cur = queue.Dequeue();
                if (cur.val == target)
                    return true;

                for (int i = 0; i < cur.neighbors.Count; i++)
                {
                    if (visited.Contains(cur.neighbors[i]))
                        continue;
                    visited.Add(cur.neighbors[i]);
                    queue.Enqueue(cur.neighbors[i]);
                }
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
