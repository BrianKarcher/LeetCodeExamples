using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given the head of a singly linked list, return true if it is a
//palindrome
// or false otherwise.
/// </summary>
public class _00234_PalindromeLinkedList
{
    public bool IsPalindrome(ListNode head)
    {
        Stack<int> stack = new();
        ListNode node = head;
        while (node != null)
        {
            stack.Push(node.val);
            node = node.next;
        }
        node = head;
        while (node != null && stack.Peek() == node.val)
        {
            stack.Pop();
            node = node.next;
        }
        return stack.Count == 0;
    }
}