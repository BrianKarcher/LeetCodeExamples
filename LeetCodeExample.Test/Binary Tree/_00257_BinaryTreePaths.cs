using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the root of a binary tree, return all root-to-leaf paths in any order.
    //A leaf is a node with no children.
    /// </summary>
    public class _00257_BinaryTreePaths
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            Recurse(root, root.val.ToString());
            return rtn;
        }

        List<string> rtn = new List<string>();

        public void Recurse(TreeNode node, string path)
        {
            if (node.left == null && node.right == null)
            {
                rtn.Add(path);
                return;
            }

            if (node.left != null)
            {
                Recurse(node.left, path + "->" + node.left.val);
            }
            if (node.right != null)
            {
                Recurse(node.right, path + "->" + node.right.val);
            }
        }
    }
}