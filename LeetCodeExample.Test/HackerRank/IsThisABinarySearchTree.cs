//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace LeetCodeExample.Test
//{
//    /// <summary>
//    //    For the purposes of this challenge, we define a binary search tree to be a binary tree with the following properties:
//    //    The value of every node in a node's left subtree is less than the data value of that node.
//    //The value of every node in a node's right subtree is greater than the data value of that node.
//    //The value of every node is distinct.
//    /// </summary>
//    public class IsThisABinarySearchTree
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public void Test()
//        {
//            List<Relation> input = new List<Relation>();
//            input.Add(new Relation("animal", "mammal"));
//            input.Add(new Relation("animal", "bird"));
//            input.Add(new Relation("lifeform", "animal"));
//            input.Add(new Relation("cat", "lion"));
//            input.Add(new Relation("mammal", "cat"));
//            input.Add(new Relation("animal", "fish"));
//            var ans = printTree2(input);
//            Assert.AreEqual("", ans);
//        }

//        public class Node
//        {
//            int data;
//            Node left;
//            Node right;
//        }

//        bool checkBST(Node root)
//        {

//        }

//        public bool Recurse(Node node)
//        {

//        }
//    }
//}