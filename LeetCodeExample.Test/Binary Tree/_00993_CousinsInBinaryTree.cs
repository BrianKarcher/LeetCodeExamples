using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree with unique values and the values of two different nodes of the tree x and y, return true if the nodes corresponding to the values x and y in the tree are cousins, or false otherwise.
//Two nodes of a binary tree are cousins if they have the same depth with different parents.
//Note that in a binary tree, the root node is at the depth 0, and children of each depth k node are at the depth k + 1.
/// </summary>
public class _00993_CousinsInBinaryTree
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            // Traverse level by level.
            int count = q.Count;
            bool foundX = false;
            bool foundY = false;
            for (int i = 0; i < count; i++)
            {
                TreeNode node = q.Dequeue();
                if (node.val == x)
                {
                    foundX = true;
                }
                if (node.val == y)
                {
                    foundY = true;
                }
                if (node.left != null && node.right != null && ((node.left.val == x || node.left.val == y) && (node.right.val == x || node.right.val == y)))
                {
                    // x and y have the same parents.
                    return false;
                }
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            if (foundX && foundY)
                return true;
            else if (foundX && !foundY)
                return false;
            else if (!foundX && foundY)
                return false;
        }
        return false;
    }
}