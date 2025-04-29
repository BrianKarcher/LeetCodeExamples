using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //  Given a n-ary tree, find its maximum depth.
    //  The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    //  Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).
    /// </summary>
    public class _00559_MaximumDepthOfNaryTree
    {
        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;
            int depth = 0;
            Queue<Node> queue = new();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                depth++;
                int childCount = queue.Count;
                for (int i = 0; i < childCount; i++)
                {
                    Node childNode = queue.Dequeue();
                    foreach (Node child in childNode.children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
            return depth;
        }
}