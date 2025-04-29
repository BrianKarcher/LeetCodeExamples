using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
/// </summary>
public class _00102_BinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> rtn = new();
        if (root == null)
            return rtn;
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            List<int> row = new();
            rtn.Add(row);
            int count = q.Count;
            for (int i = 0; i < count; i++)
            {
                TreeNode node = q.Dequeue();
                row.Add(node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }
        return rtn;
    }
}