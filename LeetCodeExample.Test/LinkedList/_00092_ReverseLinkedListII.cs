using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static LeetCodeExample.Test._00002_AddTwoNumbers_Test;

namespace LeetCodeExample.Test;

/// <summary>
//Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.
/// </summary>
public class _00092_ReverseLinkedListII
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head.next == null || left == right)
            return head;
        ListNode current = head;
        int i = 1;
        ListNode beforeReverse = null;
        ListNode reverseStart = null;
        ListNode reverseEnd = null;
        ListNode afterReverse = null;
        while (current != null)
        {
            if (i == left - 1)
                beforeReverse = current;
            else if (i == left)
                reverseStart = current;
            else if (i == right)
                reverseEnd = current;
            else if (i == right + 1)
                afterReverse = current;
            current = current.next;
            i++;
        }

        //Console.WriteLine($"b{beforeReverse.val}");
        //Console.WriteLine($"rs{reverseStart.val}");
        //Console.WriteLine($"re{reverseEnd.val}");
        //Console.WriteLine($"ar{afterReverse.val}");

        current = reverseStart;
        ListNode prev = afterReverse;
        for (int j = 0; j < right - left + 1; j++)
        {
            ListNode next = current.next;
            //Console.WriteLine($"Setting {current.val} to {prev.val}");
            current.next = prev;
            prev = current;
            current = next;
        }

        if (beforeReverse != null)
            beforeReverse.next = reverseEnd;
        // Return the new head
        return left == 1 ? reverseEnd : head;
    }
}