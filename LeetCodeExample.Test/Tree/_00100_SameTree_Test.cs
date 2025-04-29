using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the roots of two binary trees p and q, write a function to check if they are the same or not.
    //Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
    /// </summary>
    public class _00100_SameTree_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            TreeNode One = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            TreeNode Two = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            var answer = IsSameTree(One, Two);
            Assert.AreEqual(true, answer);

            One = new TreeNode(1, new TreeNode(2), null);
            Two = new TreeNode(1, null, new TreeNode(2));

            answer = IsSameTree(One, Two);
            Assert.AreEqual(false, answer);

            One = new TreeNode(1, new TreeNode(2), new TreeNode(1));
            Two = new TreeNode(1, new TreeNode(1), new TreeNode(2));

            answer = IsSameTree(One, Two);
            Assert.AreEqual(false, answer);
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p == null && q != null)
                return false;

            if (p != null && q == null)
                return false;

            if (p.val != q.val)
                return false;

            bool leftSame = true;
            bool rightSame = true;

            leftSame = IsSameTree(p.left, q.left);
            rightSame = IsSameTree(p.right, q.right);

            if (leftSame == false || rightSame == false)
                return false;

            return true;
        }

    }
}