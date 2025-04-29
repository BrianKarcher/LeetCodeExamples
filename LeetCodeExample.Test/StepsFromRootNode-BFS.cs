using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class StepsFromRootNodeBFS
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Test()
        //{
        //    var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        //    Assert.AreEqual(0, answer[0]);
        //    Assert.AreEqual(1, answer[1]);

        //    answer = TwoSum(new int[] { 3, 2, 4 }, 6);
        //    Assert.AreEqual(1, answer[0]);
        //    Assert.AreEqual(2, answer[1]);

        //    answer = TwoSum(new int[] { 3, 3 }, 6);
        //    Assert.AreEqual(0, answer[0]);
        //    Assert.AreEqual(1, answer[1]);
        //}

        public int BFS(Node root, Node target)
        {
            //Queue<Node> queue;  // store all nodes which are waiting to be processed
            int step = 0;       // number of steps neeeded from root to current node
                                // initialize
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            //add root to queue;
            // BFS
            while (queue.Any())
            {
                step = step + 1;
                // iterate the nodes which are already in the queue
                int size = queue.Count();
                for (int i = 0; i < size; ++i)
                {
                    Node cur = queue.Peek();
                    //Node cur = the first node in queue;
                    //return step if cur is target;
                    if (cur == target)
                        return step;
                    for (int k = 0; k < cur.Children.Count; k++)
                    {
                        //add next to queue;
                        queue.Enqueue(cur.Children[k]);
                    }
                    //remove the first node from queue;
                }
            }
            return -1;          // there is no path from root to target
        }

        public class Node
        {
            public List<Node> Children;
        }
    }
}