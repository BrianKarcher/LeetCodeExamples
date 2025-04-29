using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given the head of a singly linked list, reverse the list, and return the reversed list.
    /// </summary>
    public class _00206_ReverseLinkedList2_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // Recursively
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            return Recurse(head, null);
        }

        ListNode Recurse(ListNode head, ListNode prev)
        {
            ListNode next = head.next;
            head.next = prev;
            // base case
            // The new head only gets found at the end of the linked list
            if (next == null)
                return head;

            return Recurse(next, head);
        }

        // LeetCode's Recursive solution
        public ListNode reverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode p = reverseList(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
    }
}