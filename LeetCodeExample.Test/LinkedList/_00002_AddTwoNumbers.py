# You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

# You may assume the two numbers do not contain any leading zero, except the number 0 itself.

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def addTwoNumbers(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        carry = 0
        dummyHead = ListNode(0)
        current = dummyHead
        while l1 or l2:
            n1 = 0 if not l1 else l1.val
            n2 = 0 if not l2 else l2.val
            val = n1 + n2 + carry
            if val >= 10:
                carry = 1
                val %= 10
            else:
                carry = 0
            current.next = ListNode(val)
            current = current.next
            if l1:
                l1 = l1.next
            if l2:
                l2 = l2.next
        if carry != 0:
            current.next = ListNode(1)
        current = dummyHead
        return dummyHead.next