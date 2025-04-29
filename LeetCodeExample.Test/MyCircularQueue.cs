using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
      //  Design your implementation of the circular queue.The circular queue is a linear data structure in which the operations are performed based on FIFO(First In First Out) principle and the last position is connected back to the first position to make a circle.It is also called "Ring Buffer".
      // One of the benefits of the circular queue is that we can make use of the spaces in front of the queue. In a normal queue, once the queue becomes full, we cannot insert the next element even if there is a space in front of the queue. But using the circular queue, we can use the space to store new values.
    /// </summary>
    public class MyCircularQueueTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            MyCircularQueue myCircularQueue = new MyCircularQueue(3);
            var boolAns = myCircularQueue.EnQueue(1); // return True
            Assert.IsTrue(boolAns);
            boolAns = myCircularQueue.EnQueue(2); // return True
            Assert.IsTrue(boolAns);
            boolAns = myCircularQueue.EnQueue(3); // return True
            Assert.IsTrue(boolAns);
            boolAns = myCircularQueue.EnQueue(4); // return False
            Assert.IsFalse(boolAns);
            int iAns = myCircularQueue.Rear();     // return 3
            Assert.AreEqual(3, iAns);
            boolAns = myCircularQueue.IsFull();   // return True
            Assert.IsTrue(boolAns);
            boolAns = myCircularQueue.DeQueue();  // return True
            Assert.IsTrue(boolAns);
            boolAns = myCircularQueue.EnQueue(4); // return True
            Assert.IsTrue(boolAns);
            iAns = myCircularQueue.Rear();     // return 4
            Assert.AreEqual(4, iAns);

            myCircularQueue = new MyCircularQueue(6);
            boolAns = myCircularQueue.EnQueue(6);
            Assert.IsTrue(boolAns);
            iAns = myCircularQueue.Rear();
            Assert.AreEqual(6, iAns);
            iAns = myCircularQueue.Rear();
            Assert.AreEqual(6, iAns);
            boolAns = myCircularQueue.DeQueue();
            Assert.IsTrue(boolAns);
            boolAns = myCircularQueue.EnQueue(5);
            Assert.IsTrue(boolAns);
            iAns = myCircularQueue.Rear();
            Assert.AreEqual(5, iAns);
            boolAns = myCircularQueue.DeQueue();
            Assert.IsTrue(boolAns);
            iAns = myCircularQueue.Front();
            Assert.AreEqual(-1, iAns);
            boolAns = myCircularQueue.DeQueue();
            Assert.IsFalse(boolAns);
            boolAns = myCircularQueue.DeQueue();
            Assert.IsFalse(boolAns);
            boolAns = myCircularQueue.DeQueue();
            Assert.IsFalse(boolAns);


        }

        public class MyCircularQueue
        {
            int[] arr;
            int head = -1;
            int tail = -1;

            public MyCircularQueue(int k)
            {
                arr = new int[k];
            }

            public bool EnQueue(int value)
            {
                int newTail = tail + 1;
                if (newTail >= arr.Length)
                    newTail = 0;
                // Tail ran into the head, we are out of space
                if (newTail == head)
                    return false;

                if (head == -1)
                    head = newTail;
                tail = newTail;
                arr[tail] = value;

                return true;
            }

            public bool DeQueue()
            {
                if (head == -1)
                    return false;

                // Dequeueing last item
                if (head == tail)
                {
                    head = -1;
                    tail = -1;
                    return true;
                }

                int newHead = head + 1;
                if (newHead >= arr.Length)
                    newHead = 0;
                    

                head = newHead;
                return true;
            }

            public int Front()
            {
                if (head == -1)
                    return -1;
                return arr[head];
            }

            public int Rear()
            {
                if (tail == -1)
                    return -1;
                return arr[tail];
            }

            public bool IsEmpty()
            {
                return head == -1 && tail == -1;
            }

            public bool IsFull()
            {
                int newTail = tail;
                // Loop the tail around so when we subtract we get the correct distance
                if (newTail < head)
                    newTail += arr.Length;
                int size = newTail - head;

                return size == arr.Length - 1;
            }
        }
    }
}