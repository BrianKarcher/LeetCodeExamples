using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum.Each path should be returned as a list of the node values, not node references.
    // A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.
    /// </summary>
    public class _00113_PathSumII
    {
        private List<IList<int>> returnList;

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            returnList = new();
            List<int> path = new();
            dfs(root, 0, targetSum, path);
            return returnList;
        }

        public void dfs(TreeNode node, int count, int targetSum, List<int> path)
        {
            if (node == null)
            {
                return;
            }

            count += node.val;
            path.Add(node.val);

            // Count matches and is a leaf?
            if (count == targetSum && node.left == null && node.right == null)
            {
                // Add a cloned list to result set
                returnList.Add(new List<int>(path));
            }

            dfs(node.left, count, targetSum, path);
            dfs(node.right, count, targetSum, path);

            // Backtrack
            path.RemoveAt(path.Count - 1);
        }
    }
}