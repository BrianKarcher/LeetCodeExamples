using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.
    /// </summary>
    public class _00203_RemoveLinkedListElements_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        //public ListNode RemoveElements(ListNode head, int val)
        //{
        //    if (head == null)
        //        return null;

        //    ListNode current = head;
        //    ListNode previous = null;

        //    while (current != null)
        //    {
        //        if (val != current.val)
        //        {
        //            // No match, just increment
        //            previous = current;
        //            current = current.next;
        //        }
        //        else if (previous == null)
        //        {
        //            // We are removing the head
        //            // Set the head and the current to the next node
        //            // Previous remains as null
        //            head = head.next;
        //            current = head;
        //        }
        //        else
        //        {
        //            // We are not at the head, so remove this node
        //            previous.next = current.next;
        //            current = current.next;
        //        }
        //    }

        //    return head;
        //}

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode sentinel = new ListNode(0);
            sentinel.next = head;

            ListNode prev = sentinel, curr = head;
            while (curr != null)
            {
                if (curr.val == val) prev.next = curr.next;
                else prev = curr;
                curr = curr.next;
            }
            return sentinel.next;
        }
    }
}