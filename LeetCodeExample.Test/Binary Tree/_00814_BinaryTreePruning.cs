using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, return the same tree where every subtree(of the given tree) not containing a 1 has been removed.
//A subtree of a node node is node plus every node that is a descendant of node
/// </summary>
public class _00814_BinaryTreePruning
{
    public TreeNode PruneTree(TreeNode root)
    {
        if (root == null) return null;

        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);

        if (root.val == 0 && root.left == null && root.right == null) return null;

        return root;
    }


    /// <summary>
    /// /////////////
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode PruneTree2(TreeNode root)
    {
        if (dfs(root))
        {
            return null;
        }
        return root;
    }

    bool dfs(TreeNode node)
    {
        if (node == null)
        {
            return true;
        }
        bool canPruneLeft = dfs(node.left);
        if (canPruneLeft)
        {
            node.left = null;
        }
        bool canPruneRight = dfs(node.right);
        if (canPruneRight)
        {
            node.right = null;
        }
        return canPruneLeft && canPruneRight && node.val == 0;
    }
}