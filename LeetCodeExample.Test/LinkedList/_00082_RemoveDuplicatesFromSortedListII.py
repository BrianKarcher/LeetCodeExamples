# Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
from typing import Optional
class Solution:
    def deleteDuplicates(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head:
            return None
        dummyHead = ListNode(0)
        current = dummyHead
        iter = head
        while iter:
            # Duplicate check
            # We do a nested while loop in the case that the next series of numbers is another duplicate
            if iter.next and iter.val == iter.next.val:
                while iter.next and iter.val == iter.next.val:
                    iter = iter.next
                # Skip all duplicates
                current.next = iter.next
            else:
                current.next = iter
                current = current.next
            iter = iter.next
        return dummyHead.next