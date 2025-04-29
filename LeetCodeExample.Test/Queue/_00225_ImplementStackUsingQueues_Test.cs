using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Implement a last-in-first-out (LIFO) stack using only two queues.The implemented stack should support all the functions of a normal stack (push, top, pop, and empty).
    /// </summary>
    public class _00225_ImplementStackUsingQueues_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            var iAns = myStack.Top(); // return 2
            Assert.AreEqual(2, iAns);
            iAns = myStack.Pop(); // return 2
            Assert.AreEqual(2, iAns);
            var bAns = myStack.Empty(); // return False
            Assert.IsFalse(bAns);

            myStack = new MyStack();
            myStack.Push(1);
            iAns = myStack.Pop();
            Assert.AreEqual(1, iAns);
            bAns = myStack.Empty();
            Assert.IsTrue(bAns);
        }
    }

    public class MyStack
    {
        public Queue<int> q1;
        public Queue<int> q2;
        //public int whichQueue;

        public MyStack()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();
        }

        public void Push(int x)
        {
            q1.Enqueue(x);
        }

        public int Pop()
        {
            int lastItem = 0;
            while (q1.Count != 0)
            {
                int item = q1.Dequeue();
                if (q1.Count == 0)
                    lastItem = item;
                else // Popping, don't keep the last item
                    q2.Enqueue(item);
            }
            // Keep q1 as the one to populate
            var temp = q1;
            q1 = q2;
            q2 = temp;

            return lastItem;
        }

        public int Top()
        {
            int lastItem = 0;
            while (q1.Count != 0)
            {
                int item = q1.Dequeue();
                if (q1.Count == 0)
                    lastItem = item;
                q2.Enqueue(item);
            }
            // Keep q1 as the one to populate
            var temp = q1;
            q1 = q2;
            q2 = temp;

            return lastItem;
        }

        public bool Empty()
        {
            return q1.Count == 0;
        }
    }
}