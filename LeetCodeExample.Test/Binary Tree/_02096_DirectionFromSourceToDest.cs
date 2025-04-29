using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given the root of a binary tree with n nodes.Each node is uniquely assigned a value from 1 to n. You are also given an integer startValue representing the value of the start node s, and a different integer destValue representing the value of the destination node t.

    //    Find the shortest path starting from node s and ending at node t.Generate step-by-step directions of such path as a string consisting of only the uppercase letters 'L', 'R', and 'U'. Each letter indicates a specific direction:

    //'L' means to go from a node to its left child node.
    //    'R' means to go from a node to its right child node.
    //    'U' means to go from a node to its parent node.
    //Return the step-by-step directions of the shortest path from node s to node t.
    /// </summary>
    public class _02096_DirectionFromSourceToDest
    {
        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            List<char> src = new List<char>();
            Search(root, startValue, src);

            List<char> dest = new List<char>();
            Search(root, destValue, dest);

            // Most direct path has a Lowest Common Ancestor. Find it and remove entries prior to that.
            // Find the Lowest Common Ancestor
            int ancestor = 0;

            //Trim the same prefix of both the path (i.e. the path upto LCA is not needed)
            int sIdx = 0;
            int dIdx = 0;
            while (sIdx < src.Count && dIdx < dest.Count && src[sIdx] == dest[dIdx])
            {
                sIdx++;
                dIdx++;
            }

            List<char> final = new List<char>();

            for (int i = sIdx; i < src.Count; i++)
            {
                final.Add('U'); // since we go up, everthing will be 'U'
            }

            for (int i = dIdx; i < dest.Count; i++)
            {
                final.Add(dest[i]);
            }

            return new String(final.ToArray());
        }

        public bool Search(TreeNode root, int val, List<char> path)
        {
            if (root == null)
                return false;

            if (root.val == val)
            {
                return true;
            }

            path.Add('L');
            // Going left
            if (Search(root.left, val, path))
                return true;

            // Backtracking
            path.RemoveAt(path.Count - 1);

            // Going right
            path.Add('R');
            if (Search(root.right, val, path))
                return true;

            // Backtracking
            path.RemoveAt(path.Count - 1);

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