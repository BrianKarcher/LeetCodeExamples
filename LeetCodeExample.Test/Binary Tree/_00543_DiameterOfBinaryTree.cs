using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, return the length of the diameter of the tree.
//The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.
//The length of a path between two nodes is represented by the number of edges between them.
/// </summary>
public class _00543_DiameterOfBinaryTree
{
    int width = 0;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        Recurse(root);
        return width;
    }

    public int Recurse(TreeNode node)
    {
        if (node == null)
            return 0;
        int leftLength = Recurse(node.left);
        int rightLength = Recurse(node.right);
        // Check length.
        width = Math.Max(width, leftLength + rightLength);
        // return the longest one between left_path and right_path;
        // remember to add 1 for the path connecting the node and its parent
        return Math.Max(leftLength, rightLength) + 1;
    }

    /// <summary>
    /// /////////////////
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    // FOLLOW UP : Print the list

    List<int> max = new();
    public List<int> RecursePrint(TreeNode node)
    {
        if (node == null)
            return new List<int>();
        List<int> leftList = RecursePrint(node.left);
        List<int> rightList = RecursePrint(node.right);
        // Check length.
        if (leftList.Count + rightList.Count + 1 > max.Count)
        {
            max = new List<int>();
            max.AddRange(leftList);
            max.Add(node.val);
            // TODO : Reverse the Right list before adding it to Max.
            max.AddRange(rightList);
        }
        // return the longest one between left_path and right_path;
        // remember to add 1 for the path connecting the node and its parent
        if (leftList.Count > rightList.Count)
        {
            leftList.Add(node.val);
            return leftList;
        }
        else
        {
            rightList.Add(node.val);
            return rightList;
        }
    }
}