using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the root of a binary tree, construct a 0-indexed m x n string matrix res that represents a formatted layout of the tree.The formatted layout matrix should be constructed using the following rules:

//The height of the tree is height and the number of rows m should be equal to height + 1.
//The number of columns n should be equal to 2height+1 - 1.
//Place the root node in the middle of the top row(more formally, at location res[0][(n - 1) / 2]).
//For each node that has been placed in the matrix at position res[r][c], place its left child at res[r + 1][c-2height-r-1] and its right child at res[r + 1][c+2height-r-1].
//Continue this process until all the nodes in the tree have been placed.
//Any empty cells should contain the empty string "".
//Return the constructed matrix res.
/// </summary>
public class _00655_PrintBinaryTree
{
    int height;

    int GetHeight(TreeNode node)
    {
        if (node == null)
            return 0;
        return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
    }

    void dfs(IList<IList<string>> res, TreeNode node, int row, int col)
    {
        if (node == null)
            return;
        //Console.WriteLine($"({row}, {col})");
        res[row][col] = node.val.ToString();
        dfs(res, node.left, row + 1, col - (int)Math.Pow(2, (int)height - row - 2));
        dfs(res, node.right, row + 1, col + (int)Math.Pow(2, (int)height - row - 2));
    }

    public IList<IList<string>> PrintTree(TreeNode root)
    {
        height = GetHeight(root);
        //Console.WriteLine($"Height: {height}");
        List<IList<string>> res = new();
        int colCount = (int)Math.Pow(2, (int)height) - 1;
        //Console.WriteLine($"colCount: {colCount}");
        // Build the matrix which we will fill in later
        for (int i = 0; i < height; i++)
        {
            res.Add(new List<string>());
            for (int j = 0; j < colCount; j++)
            {
                res[i].Add(string.Empty);
            }
        }
        dfs(res, root, 0, (colCount - 1) / 2);
        return res;
    }
}