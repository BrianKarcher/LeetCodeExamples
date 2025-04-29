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
            print(f'{dummyHead}')
        if carry != 0:
            current.next = ListNode(1)
        current = dummyHead
        while current:
            print(f'{current.val}')
            current = current.next
        return dummyHead.next