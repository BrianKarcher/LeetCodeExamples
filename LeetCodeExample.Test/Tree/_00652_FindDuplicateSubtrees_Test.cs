using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the root of a binary tree, return all duplicate subtrees.

    //For each kind of duplicate subtrees, you only need to return the root node of any one of them.

    //Two trees are duplicate if they have the same structure with the same node values.
    /// </summary>
    public class _00652_FindDuplicateSubtrees_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public List<TreeNode> rtn = new List<TreeNode>();
        // The value is a counter - only add to the result set on seen value "2", not 1 or 3, etc.
        public Dictionary<string, int> seen = new Dictionary<string, int>();

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            // Do a DFS
            dfs(root);
            return rtn;
        }

        public string dfs(TreeNode root)
        {
            if (root == null)
                return "null";

            var left = dfs(root.left);
            var right = dfs(root.right);
            // Represent the entire subtree structure as a string for easy comparison
            // and duplicate removal
            string val = $"{root.val}-{left}-{right}";
            if (seen.ContainsKey(val))
            {
                seen[val]++;
            }
            else
            {
                seen.Add(val, 1);
            }

            if (seen[val] == 2)
            {
                rtn.Add(root);
            }
            return val;
        }

        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}