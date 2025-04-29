using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
    /// </summary>
    public class _00199_BinaryTreeRightSide
    {
        public void rightView(TreeNode root, List<int> list, int currDepth)
        {
            if (root == null) return;

            // To get the current level, check the size of the list
            // Eg : For 0 elements added it's 0, we go one level deeper by adding the root
            // For 1 element it's size is 1, again we add the right most node and go one level deeper
            // For 2 elements it's size is 2, again we add the right most node and go one level deeper
            // ... and so on....
            if (currDepth == list.Count)
            {
                list.Add(root.val);
            }

            //Reverse PreOrder Traversal i.e, Root, Right, Left
            rightView(root.right, list, currDepth + 1);
            rightView(root.left, list, currDepth + 1);

            //For leftSide View
            //Do PreOrder Traversal 
        }

        public List<int> rightSideView(TreeNode root)
        {

            //Approach:
            //Go from Right to left ( by Reverse PreOrder Traversal i.e root, right, left)
            //When coming at a level for the first time
            //Add the root val in data structure, as it's the right most node of the tree of that level

            List<int> list = new List<int>();
            rightView(root, list, 0);
            return list;


        }

        //public IList<int> RightSideView(TreeNode root)
        //{
        //    List<int> rtn = new List<int>();
        //    if (root == null)
        //        return rtn;
        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    queue.Enqueue(root);
        //    rtn.Add(root.val);
        //    while (queue.Count != 0)
        //    {
        //        // Go level by level (BFS)
        //        int lastVal = Int32.MinValue;
        //        int size = queue.Count;
        //        bool foundItem = false;
        //        for (int i = 0; i < size; i++)
        //        {
        //            var node = queue.Dequeue();
        //            if (node.left != null)
        //            {
        //                lastVal = node.left.val;
        //                queue.Enqueue(node.left);
        //                foundItem = true;
        //            }
        //            if (node.right != null)
        //            {
        //                lastVal = node.right.val;
        //                queue.Enqueue(node.right);
        //                foundItem = true;
        //            }
        //        }
        //        if (foundItem)
        //            rtn.Add(lastVal);
        //    }
        //    return rtn;
        //}
    }
}