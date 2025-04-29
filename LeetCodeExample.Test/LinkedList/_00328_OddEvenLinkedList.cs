using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.
    // The first node is considered odd, and the second node is even, and so on.
    // Note that the relative order inside both the even and odd groups should remain as it was in the input.
    // You must solve the problem in O(1) extra space complexity and O(n) time complexity.
    /// </summary>
    public class _00328_OddEvenLinkedList
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;
            // FirstEven goes after the Last Odd
            ListNode firstEven = null;
            ListNode lastOdd = null;
            int count = 1;
            ListNode current = head;

            while (current != null)
            {
                bool isEven = count % 2 == 0;
                ListNode next = current.next;
                if (current.next?.next != null)
                {
                    //Console.WriteLine($"pointing {current.val} to {current.next.next.val}");
                    current.next = current.next.next;
                }
                else
                {
                    // We reached the end of either even or odd, set next to null to prevent
                    // infinite loop
                    current.next = null;
                }

                if (isEven && firstEven == null)
                    firstEven = current;
                else if (!isEven)
                    lastOdd = current;

                current = next;
                count++;
            }

            if (lastOdd != null)
            {
                //Console.WriteLine($"Pointing {lastOdd.val} to {firstEven.val}");
                lastOdd.next = firstEven;
            }

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