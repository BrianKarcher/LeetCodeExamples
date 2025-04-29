using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class x206_ReverseLinkedList_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            ListNode answer;
            answer = ReverseList(ArrToLinkedList(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(answer.val, 5);
            Assert.AreEqual(answer.next.val, 4);
            Assert.AreEqual(answer.next.next.val, 3);
            Assert.AreEqual(answer.next.next.next.val, 2);
            Assert.AreEqual(answer.next.next.next.next.val, 1);
            //Assert.AreEqual(5, answer);
            //answer = MaxProfit(new int[] { 5, 7, 1, 5, 3, 6, 4 });
            //Assert.AreEqual(5, answer);
            //answer = MaxProfit(new int[] { 7, 6, 4, 3, 1 });
            //Assert.AreEqual(0, answer);

            answer = ReverseList(ArrToLinkedList(new int[] { 1, 2}));
            Assert.AreEqual(answer.val, 2);
            Assert.AreEqual(answer.next.val, 1);
        }

        public ListNode ArrToLinkedList(int[] val)
        {
            ListNode current = null;
            for (int i = val.Length - 1; i >= 0; i--)
            {
                ListNode previous = current;
                current = new ListNode(val[i], previous);
            }
            return current;
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode previous = null;

            ListNode current = head;
            while (current != null)
            {
                ListNode next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            // Since the last item in the old list is the new head, return the new head
            return previous;
        }
    }
}