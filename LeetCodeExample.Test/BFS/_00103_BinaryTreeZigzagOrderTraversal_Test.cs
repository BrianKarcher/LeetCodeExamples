using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).
    /// </summary>
    public class _00103_BinaryTreeZigzagOrderTraversal_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> rtn = new List<IList<int>>();
            if (root == null)
                return rtn;

            bool leftToRight = true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                List<int> items = new List<int>();
                rtn.Add(items);

                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var item = queue.Dequeue();
                    // Always queue the items up in the normal left-to-right order
                    if (item.left != null)
                        queue.Enqueue(item.left);
                    if (item.right != null)
                        queue.Enqueue(item.right);
                    // Cache the item for the zig-zag later
                    items.Add(item.val);
                }
                // This is where we apply the zig-zag
                if (!leftToRight)
                {
                    items.Reverse();
                }
                leftToRight = !leftToRight;
            }
            return rtn;
        }

        // DFS
        //public IList<IList<int>> ZigzagLevelOrderDFS(TreeNode root)
        //{
        //    Dfs(root, 0);
        //    // Do zig zag
        //    bool flip = false;
        //    for (int i = 0; i < lst.Count; i++)
        //    {
        //        if (flip)
        //            (lst[i] as List<int>).Reverse();
        //        flip = !flip;
        //    }
        //    return lst;
        //}

        //List<IList<int>> lst = new List<IList<int>>();

        //public void Dfs(TreeNode node, int level)
        //{
        //    if (node == null)
        //        return;
        //    // Add a new level if needed
        //    if (level > lst.Count - 1)
        //        lst.Add(new List<int>());
        //    lst[level].Add(node.val);
        //    if (node.left != null)
        //        Dfs(node.left, level + 1);
        //    if (node.right != null)
        //        Dfs(node.right, level + 1);
        //}



        // DFS with LinkedList
        public IList<LinkedList<int>> ZigzagLevelOrderDFS(TreeNode root)
        {
            Dfs(root, 0);

            return lst;
        }

        List<LinkedList<int>> lst = new List<LinkedList<int>>();

        public void Dfs(TreeNode node, int level)
        {
            if (node == null)
                return;
            // Add a new level if needed
            if (level > lst.Count - 1)
            {
                lst.Add(new LinkedList<int>());
                lst[level].AddFirst(node.val);
            }
            else if (level % 2 == 0) // Do the zig zag
                lst[level].AddFirst(node.val);
            else
                lst[level].AddLast(node.val);

            if (node.left != null)
                Dfs(node.left, level + 1);
            if (node.right != null)
                Dfs(node.right, level + 1);
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