using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Merge two sorted linked lists and return it as a sorted list.The list should be made by splicing together the nodes of the first two lists.
    /// </summary>
    public class _00021_MergeTwoSortedLists_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            return mergeTwoLists(l1, l2);
        }

        //public ListNode Recurse(ListNode l1, ListNode l2)
        //{
        //    // Base cases
        //    if (l1 == null && l2 == null)
        //        return null;

        //    bool pickFirst = true;
        //    if (l1 == null)
        //    {
        //        pickFirst = false;
        //    }
        //    else if (l2 == null)
        //    {
        //        pickFirst = true;
        //    }
        //    else
        //    {
        //        if (l1.val < l2.val)
        //        {
        //            pickFirst = true;
        //        }
        //        else
        //        {
        //            pickFirst = false;
        //        }
        //    }

        //    if (pickFirst == true)
        //    {
        //        return new ListNode(l1.val, Recurse(l1.next, l2));
        //    }
        //    else
        //    {
        //        return new ListNode(l2.val, Recurse(l1, l2.next));
        //    }
        //}

        public ListNode mergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = mergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = mergeTwoLists(l1, l2.next);
                return l2;
            }

        }

        // Definition for singly-linked list.
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