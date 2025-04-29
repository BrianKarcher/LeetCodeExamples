using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given the root of a full binary tree with the following properties:

//Leaf nodes have either the value 0 or 1, where 0 represents False and 1 represents True.
//Non-leaf nodes have either the value 2 or 3, where 2 represents the boolean OR and 3 represents the boolean AND.
//The evaluation of a node is as follows:

//If the node is a leaf node, the evaluation is the value of the node, i.e.True or False.
//Otherwise, evaluate the node's two children and apply the boolean operation of its value with the children's evaluations.
//Return the boolean result of evaluating the root node.

//A full binary tree is a binary tree where each node has either 0 or 2 children.

//A leaf node is a node that has zero children.
/// </summary>
public class _02331_EvaluateBooleanBinaryTree
{
    public bool EvaluateTree(TreeNode root)
    {
        return dfs(root);
    }

    bool dfs(TreeNode node)
    {
        // Leaf? Just return value
        if (node.left == null && node.right == null)
            return node.val == 0 ? false : true;

        bool left = dfs(node.left);
        // Short circuit if possible.
        if (node.val == 2 && left)
            return true;
        if (node.val == 3 && !left)
            return false;
        bool right = dfs(node.right);
        if (node.val == 2)
            return left || right;
        else
            return left && right;
    }
}