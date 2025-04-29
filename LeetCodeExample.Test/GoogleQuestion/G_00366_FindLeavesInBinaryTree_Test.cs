using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

    //    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
    //Return true if you can finish all courses.Otherwise, return false.
    /// </summary>
    public class G_00366_FindLeavesInBinaryTree_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        private List<List<int>> solution;

        private int getHeight(TreeNode root)
        {

            // return -1 for null nodes
            if (root == null)
            {
                return -1;
            }

            // first calculate the height of the left and right children
            int leftHeight = getHeight(root.left);
            int rightHeight = getHeight(root.right);

            int currHeight = Math.Max(leftHeight, rightHeight) + 1;

            if (this.solution.Count == currHeight)
            {
                this.solution.Add(new List<int>());
            }

            this.solution[currHeight].Add(root.val);

            return currHeight;
        }

        public List<List<int>> findLeaves(TreeNode root)
        {
            this.solution = new List<List<int>>();

            getHeight(root);

            return this.solution;
        }

        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            List<IList<int>> rtn = new List<IList<int>>();

            List<int> level = new List<int>();
            while (!dfs(root, level))
            {
                rtn.Add(level);
                level = new List<int>();
            }
            // Add the root node
            rtn.Add(level);
            return rtn;
        }

        bool dfs(TreeNode node, List<int> level)
        {
            // If this is a leaf, record it and return false so it can be removed
            if (node.left == null && node.right == null)
            {
                level.Add(node.val);
                return true;
            }

            if (node.left != null)
            {
                bool isALeaf = dfs(node.left, level);
                if (isALeaf)
                    node.left = null;
            }
            if (node.right != null)
            {
                bool isALeaf = dfs(node.right, level);
                if (isALeaf)
                    node.right = null;
            }

            // Not a leaf, return false
            return false;
        }

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