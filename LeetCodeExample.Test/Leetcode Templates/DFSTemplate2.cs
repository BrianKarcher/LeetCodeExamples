using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test.Leetcode_Templates
{
    /// <summary>
    /// The advantage of the recursion solution is that it is easier to implement. 
    /// However, there is a huge disadvantage: if the depth of recursion is too high, 
    /// you will suffer from stack overflow. In that case, you might want to use BFS instead or 
    /// implement DFS using an explicit stack.
    /// </summary>
    public class DFSTemplate2
    {
        bool DFS(Node root, int target)
        {
            HashSet<Node> visited = new HashSet<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Any())
            {
                Node cur = stack.Pop();
                if (cur.val == target)
                    return true;

                for (int i = 0; i < cur.neighbors.Count; i++)
                {
                    if (visited.Contains(cur.neighbors[i]))
                        continue;
                    visited.Add(cur.neighbors[i]);
                    stack.Push(cur.neighbors[i]);
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
