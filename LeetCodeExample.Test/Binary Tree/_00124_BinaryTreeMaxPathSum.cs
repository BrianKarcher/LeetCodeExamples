using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //  A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them.A node can only appear in the sequence at most once.Note that the path does not need to pass through the root.
    // The path sum of a path is the sum of the node's values in the path.
    // Given the root of a binary tree, return the maximum path sum of any non-empty path.
    /// </summary>
    public class _00124_BinaryTreeMaxPathSum
    {
        public int MaxPathSum(TreeNode root)
        {
            Recurse(root);
            return max;
        }

        int max = Int32.MinValue;
        int Recurse(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            // First let's get the maximum possible value for this Node
            int thisValue = node.val;
            int leftValue = Recurse(node.left);
            int rightValue = Recurse(node.right);

            // Possible paths:
            // Just this node
            max = Math.Max(max, node.val);

            // Up Left node, this node, and down right node
            int val = thisValue + leftValue + rightValue;
            max = Math.Max(max, val);

            // left value + this value, ending here
            val = thisValue + leftValue;
            max = Math.Max(max, val);

            // right value + this value, ending here
            val = thisValue + rightValue;
            max = Math.Max(max, val);

            // Another possible path is to go up. If both children are less than 0, just return this node's value
            if (leftValue <= 0 && rightValue <= 0)
                return thisValue;

            // If left is bigger than right, send that one up WITH this node (otherwise it isn't a full path
            if (leftValue > rightValue)
                return leftValue + thisValue;
            else
                return rightValue + thisValue;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}