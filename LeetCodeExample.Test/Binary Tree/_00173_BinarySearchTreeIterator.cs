using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree(BST) :

//BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor.The pointer should be initialized to a non-existent number smaller than any element in the BST.
//boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
//int next() Moves the pointer to the right, then returns the number at the pointer.
//Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

//You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.
/// </summary>
public class _00173_BinarySearchTreeIterator
{
    public class BSTIterator
    {
        Stack<TreeNode> stack;
        public BSTIterator(TreeNode root)
        {
            stack = new();
            Traverse(root);
        }

        private void Traverse(TreeNode node)
        {
            if (node == null)
                return;
            stack.Push(node);
            Traverse(node.left);
        }

        public int Next()
        {
            TreeNode node = stack.Pop();
            Traverse(node.right);
            return node.val;
        }

        public bool HasNext()
        {
            return stack.Count != 0;
        }
    }

    /// <summary>
    /// ///////////
    /// </summary>
    public class BSTIterator2
    {
        Queue<int> q;

        public BSTIterator2(TreeNode root)
        {
            q = new();
            dfs(root);
        }

        void dfs(TreeNode node)
        {
            if (node == null)
                return;
            dfs(node.left);
            q.Enqueue(node.val);
            dfs(node.right);
        }

        public int Next()
        {
            return q.Dequeue();
        }

        public bool HasNext()
        {
            return q.Count != 0;
        }
    }
}