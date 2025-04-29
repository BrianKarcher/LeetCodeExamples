using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.
/// </summary>
public class _00572_SubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return SearchForStartOfSecond(root, subRoot);
    }

    bool SearchForStartOfSecond(TreeNode node, TreeNode subNode)
    {
        if (node == null || subNode == null)
            return false;
        if (node.val == subNode.val && TreesMatch(node, subNode))
        {
            return true;
        }
        if (SearchForStartOfSecond(node.left, subNode) == true)
            return true;
        return SearchForStartOfSecond(node.right, subNode);
    }

    bool TreesMatch(TreeNode node, TreeNode subNode)
    {
        if (node == null && subNode == null)
            return true;
        if (node == null && subNode != null)
            return false;
        if (node != null && subNode == null)
            return false;
        if (node.val != subNode.val)
        {
            return false;
        }

        bool leftMatch = TreesMatch(node.left, subNode.left);
        bool rightMatch = TreesMatch(node.right, subNode.right);
        return leftMatch && rightMatch;
    }

    /*public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        string tree = PrintTree(root);
        string subTree = PrintTree(subRoot);
        return tree.Contains(subTree);
    }

    public string PrintTree(TreeNode node) {
        if (node == null) {
            return "null";
        }
        return PrintTree(node.left) + "|" + node.val + "|" + PrintTree(node.right);
    }*/
}