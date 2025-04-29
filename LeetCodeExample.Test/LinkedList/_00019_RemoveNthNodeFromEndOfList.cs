using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the head of a linked list, remove the nth node from the end of the list and return its head.
    /// </summary>
    public class _00019_RemoveNthNodeFromEndOfList
    {
        // 2 pointer method
        public ListNode removeNthFromEnd(ListNode head, int n)
        {
            ListNode left = head;
            ListNode right = head;
            int count = 0;

            while (right.next != null)
            {
                right = right.next;
                if (count >= n)
                {
                    left = left.next;
                }
                count++;
            }
            //IF we have to remove first node ELSE just delete the node
            if (count < n)
            {
                head = head.next;
            }
            else
            {
                left.next = left.next.next;
            }

            return head;

        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            // n is index from end, so let's create the linkedlist as a List so we can easily find the n from last value
            List<ListNode> lst = new List<ListNode>();
            var current = head;
            while (current != null)
            {
                lst.Add(current);
                current = current.next;
            }

            if (lst.Count == 1)
                return null;

            // Removing the head? Just return the next value from the head as the new head
            if (n == lst.Count)
                return head.next;

            var nodeToRemove = lst.Count - n;
            lst[nodeToRemove - 1].next = lst[nodeToRemove].next;
            return head;
        }

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