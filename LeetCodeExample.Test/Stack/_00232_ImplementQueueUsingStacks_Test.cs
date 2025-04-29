using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Implement a first in first out (FIFO) queue using only two stacks.The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).
    /// </summary>
    public class _00232_ImplementQueueUsingStacks_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            MyQueue myQueue = new MyQueue();
            myQueue.Push(1); // queue is: [1]
            myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
            var iAns = myQueue.Peek(); // return 1
            Assert.AreEqual(1, iAns);
            iAns = myQueue.Pop(); // return 1, queue is [2]
            Assert.AreEqual(1, iAns);
            var bAns = myQueue.Empty(); // return false
            Assert.IsFalse(bAns);
        }

        public class MyQueue
        {
            // Stacks are LIFO, so transferring from one stack to another will reverse the order
            // Thus the second stack is FIFO.
            Stack<int> stack;
            Stack<int> queue;
            public MyQueue()
            {
                stack = new Stack<int>();
                queue = new Stack<int>();
            }

            public void Push(int x)
            {
                stack.Push(x);
            }

            public int Pop()
            {
                PopulateQueue();
                return queue.Pop();
            }

            private void PopulateQueue()
            {
                if (queue.Count == 0)
                {
                    // This will reverse it.
                    while (stack.Any())
                        queue.Push(stack.Pop());
                }
            }

            public int Peek()
            {
                PopulateQueue();
                return queue.Peek();
            }

            public bool Empty()
            {
                return queue.Count == 0 && stack.Count == 0;
            }
        }

    }
}