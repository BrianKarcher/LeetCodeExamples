# Given the head of a linked list, rotate the list to the right by k places.

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def rotateRight(self, head: Optional[ListNode], k: int) -> Optional[ListNode]:
        if not head:
            return None
        # We need to find the length of the linked list first so we can mod k
        # We don't know what we are looking for yet until k gets modularized
        length = 0
        prevTail = head
        while prevTail.next:
            length += 1
            prevTail = prevTail.next
        
        # print(f'k: {k}, length: {length}')
        k = k % length
        # print(f'new k: {k}')
        # Will we end up where we started? No change
        if k == 0:
            return head

        splitPoint = None
        d = 0
        current = head
        while current:
            d += 1
            if d >= length - k:
                splitPoint = current
                break
            current = current.next
        
        newHead = splitPoint.next
        # splitPoint is the new tail 
        splitPoint.next = None
        prevTail.next = head
        return newHead