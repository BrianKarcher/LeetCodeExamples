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
    public class _00002_AddTwoNumbers_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carryover = 0;
            ListNode dummyHead = new ListNode(0);
            ListNode current = dummyHead;
            while (l1 != null || l2 != null)
            {
                int val1 = l1 == null ? 0 : l1.val;
                int val2 = l2 == null ? 0 : l2.val;
                int sum = val1 + val2 + carryover;

                carryover = sum / 10;

                current.next = new ListNode(sum % 10);
                current = current.next;

                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if (carryover == 1)
            {
                current.next = new ListNode(carryover);
            }
            return dummyHead.next;
        }

        //* Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}