using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, return the postorder traversal of its nodes' values.
/// </summary>
public class _00145_BinaryTreePreorderTraversal
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        List<int> rtn = new();
        dfs(rtn, root);
        return rtn;
    }

    void dfs(List<int> rtn, TreeNode node)
    {
        if (node == null)
            return;
        dfs(rtn, node.left);
        dfs(rtn, node.right);
        rtn.Add(node.val);
    }
}