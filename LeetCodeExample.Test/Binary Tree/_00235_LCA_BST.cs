using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a binary search tree(BST), find the lowest common ancestor(LCA) node of two given nodes in the BST.
    // According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”
    /// </summary>
    public class _00235_LCA_BST
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Queue<TreeNode> pQueue = new Queue<TreeNode>();
            Search(root, p.val, pQueue);
            Queue<TreeNode> qQueue = new Queue<TreeNode>();
            Search(root, q.val, qQueue);
            // LCA - remove like first elements
            TreeNode lca = pQueue.Peek();
            while (pQueue.Count != 0 && qQueue.Count != 0 && pQueue.Peek() == qQueue.Peek())
            {
                lca = pQueue.Dequeue();
                qQueue.Dequeue();
            }
            return lca;
        }

        public void Search(TreeNode node, int val, Queue<TreeNode> queue)
        {
            if (node == null)
                return;

            queue.Enqueue(node);
            if (val == node.val)
                return;
            else if (val < node.val)
                Search(node.left, val, queue);
            else
                Search(node.right, val, queue);
        }
    }
}