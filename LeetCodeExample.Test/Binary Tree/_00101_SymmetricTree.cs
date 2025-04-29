using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, check whether it is a mirror of itself(i.e., symmetric around its center).
/// </summary>
public class _00101_SymmetricTree
{
    public bool IsSymmetric(TreeNode root)
    {
        return dfs(root.left, root.right);
    }

    bool dfs(TreeNode n1, TreeNode n2)
    {
        if (n1 == null && n2 == null)
        {
            return true;
        }
        if (n1 == null && n2 != null)
        {
            return false;
        }
        if (n1 != null && n2 == null)
        {
            return false;
        }
        if (n1.val != n2.val)
        {
            return false;
        }
        // Symmetrical so we need to switch the left and right nodes down the tree.
        if (!dfs(n1.left, n2.right))
        {
            return false;
        }
        if (!dfs(n1.right, n2.left))
        {
            return false;
        }
        return true;
    }
}