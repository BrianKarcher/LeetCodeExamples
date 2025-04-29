using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, return the preorder traversal of its nodes' values.
/// </summary>
public class _00144_BinaryTreePreorderTraversal
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> rtn = new();
        dfs(rtn, root);
        return rtn;
    }

    void dfs(List<int> rtn, TreeNode node)
    {
        if (node == null)
            return;
        rtn.Add(node.val);
        dfs(rtn, node.left);
        dfs(rtn, node.right);
    }

    ///////////////
    ///

    public IList<int> PreorderTraversal2(TreeNode root)
    {
        List<int> rtn = new();
        Stack<TreeNode> stack = new();
        stack.Push(root);
        while (stack.Count != 0)
        {
            TreeNode node = stack.Pop();
            if (node == null)
                continue;
            rtn.Add(node.val);
            stack.Push(node.right);
            stack.Push(node.left);
        }
        return rtn;
    }
}