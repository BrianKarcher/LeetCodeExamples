using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Leetcode_Templates
{
    class BFSTemplate1
    {
        /**
         * Return the length of the shortest path between root and target node.
         */
        int BFS(Node root, Node target)
        {
            Queue<Node> queue = new Queue<Node>();  // store all nodes which are waiting to be processed
            HashSet<Node> visited = new HashSet<Node>();
            int step = 0;       // number of steps neeeded from root to current node
                                // initialize
                                //add root to queue;
            queue.Enqueue(root);
            visited.Add(root);
            // BFS
            while (queue.Count != 0)
            {
                step = step + 1;
                // iterate the nodes which are already in the queue
                int size = queue.Count;
                for (int i = 0; i < size; ++i)
                {
                    //Node cur = the first node in queue;
                    Node cur = queue.Dequeue();
                    //return step if cur is target;
                    if (cur == target)
                        return step;
                    //for (Node next : the neighbors of cur)
                    //{
                    //    add next to queue;
                    //}
                    foreach (var node in cur.neighbors)
                    {
                        if (!visited.Contains(node))
                        {
                            visited.Add(node);
                            queue.Enqueue(node);
                        }
                        
                    }
                    //remove the first node from queue;
                }
            }
            return -1;          // there is no path from root to target
        }

        public class Node
        {
            public int val;
            public List<Node> neighbors;
        }
    }

}
