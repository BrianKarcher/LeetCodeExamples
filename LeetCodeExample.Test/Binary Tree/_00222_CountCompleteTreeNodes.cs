using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a complete binary tree, return the number of the nodes in the tree.
//According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, and all nodes in the last level are as far left as possible.It can have between 1 and 2h nodes inclusive at the last level h.
//Design an algorithm that runs in less than O(n) time complexity.
/// </summary>
public class _00222_CountCompleteTreeNodes
{
    public int CountNodes(TreeNode root)
    {
        if (root == null)
            return 0;
        int height = GetHeight(root);
        return GetCount(root, 1, 1, height);
    }

    int GetHeight(TreeNode node)
    {
        // The left side of a complete binary tree will always have the height.
        // This is O(h).
        if (node == null)
            return 0;
        return GetHeight(node.left) + 1;
    }

    int GetCount(TreeNode node, int c, int h, int target_height)
    {
        // base case
        if (node.left == null && node.right == null)
        {
            if (h == target_height)
            {
                // Bingo.
                //Console.WriteLine($"c {c}, h {h}");
                int count = 0;
                for (int i = 0; i < h - 1; i++)
                {
                    count += (int)Math.Pow(2, i);
                }
                return count + c;
                //return (int)Math.Pow(2, h - 1) / 2 + c;
                //return 2 * (h - 1) + c;
            }
            return -1;
        }

        // Opportunistically traverse down the right side to locate 
        // the last node.
        if (node.right != null)
        {
            int rCount = GetCount(node.right, c * 2, h + 1, target_height);
            // If the right path does not lead to the target height we 
            // need to check the left path.
            if (rCount != -1)
            {
                return rCount;
            }
        }
        if (node.left != null)
        {
            return GetCount(node.left, c * 2 - 1, h + 1, target_height);
        }
        // If neither paths reach the target height then we need to try 
        // another route from above.
        return -1;
    }
}