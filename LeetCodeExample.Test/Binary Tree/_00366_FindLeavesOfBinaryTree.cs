using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given the root of a binary tree, collect a tree's nodes as if you were doing this:

    //Collect all the leaf nodes.
    //Remove all the leaf nodes.
    //Repeat until the tree is empty.
    /// </summary>
    public class _00366_FindLeavesOfBinaryTree
    {
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
                this.solution.Add(new());
            }

            this.solution[currHeight].Add(root.val);

            return currHeight;
        }

        public List<List<int>> findLeaves(TreeNode root)
        {
            this.solution = new();

            getHeight(root);

            return this.solution;
        }



        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            bool exit = false;
            List<IList<int>> rtn = new List<IList<int>>();
            while (!exit)
            {
                List<int> leaves = new List<int>();
                // Keep recursing until all leaves are plucked
                exit = Recurse(root, leaves);
                rtn.Add(leaves);
            }
            return rtn;
        }

        // returns true if a leaf, false if not
        public bool Recurse(TreeNode node, IList<int> lst)
        {
            if (node == null)
            {
                return false;
            }

            // If it is a leaf then pluck it
            if (node.left == null && node.right == null)
            {
                lst.Add(node.val);
                return true;
            }

            if (Recurse(node.left, lst))
            {
                // Pluck a leaf
                node.left = null;
            }

            if (Recurse(node.right, lst))
            {
                // Pluck a leaf
                node.right = null;
            }

            return false;
        }
    }
}