using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a linked list, swap every two adjacent nodes and return its head.
    // You must solve the problem without modifying the values in the list's nodes
    // (i.e., only nodes themselves may be changed.)
    /// </summary>
    public class _00024_SwapNodesInPairs_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public ListNode SwapPairs(ListNode head)
        {
            return swapPairs(head);
        }

        public ListNode swapPairs(ListNode head)
        {

            // If the list has no node or has only one node left.
            if ((head == null) || (head.next == null))
            {
                return head;
            }

            // Nodes to be swapped
            ListNode firstNode = head;
            ListNode secondNode = head.next;

            // Swapping
            firstNode.next = swapPairs(secondNode.next);
            secondNode.next = firstNode;

            // Now the head is the second node
            return secondNode;
        }
    }
}