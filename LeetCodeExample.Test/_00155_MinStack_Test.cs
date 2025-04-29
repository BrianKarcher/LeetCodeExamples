using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00155_MinStack_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            var iAns = minStack.GetMin(); // return -3
            Assert.AreEqual(-3, iAns);
            minStack.Pop();
            iAns = minStack.Top();    // return 0
            Assert.AreEqual(0, iAns);
            iAns = minStack.GetMin(); // return -2
            Assert.AreEqual(-2, iAns);

            minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-1);
            iAns = minStack.GetMin();
            Assert.AreEqual(-2, iAns);
            iAns = minStack.Top();
            Assert.AreEqual(-1, iAns);
            minStack.Pop();
            iAns = minStack.GetMin();
            Assert.AreEqual(-2, iAns);
        }

        public class MinStack
        {
            Stack<StackItem> stack;
            int min = Int32.MaxValue;

            public MinStack()
            {
                stack = new Stack<StackItem>();
            }

            public void Push(int val)
            {
                stack.Push(new StackItem(val, min));
                min = Math.Min(min, val);
            }

            public void Pop()
            {
                var item = stack.Pop();
                min = item.prevMin;
            }

            public int Top()
            {
                return stack.Peek().value;
            }

            public int GetMin()
            {
                return min;
            }

            public class StackItem
            {
                public int value;
                public int prevMin;

                public StackItem(int value, int prevMin)
                {
                    this.value = value;
                    this.prevMin = prevMin;
                }
            }
        }
    }
}