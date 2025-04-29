# Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.
# k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.
# You may not alter the values in the list's nodes, only nodes themselves may be changed.

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def reverseKGroup(self, head: Optional[ListNode], k: int) -> Optional[ListNode]:
        def reverse(first: ListNode, next: ListNode) -> ListNode:
            # print(f'Reversing {first.val} to {next.val}')
            current = first
            prev = None
            while current != next:
                temp = current.next
                current.next = prev
                prev = current
                current = temp
            first.next = next
            # return the new Head
            return prev
        
        dummyHead = ListNode(0)
        dummyHead.next = head
        current = head
        start = dummyHead
        count = 0
        while current:
            if count == k:
                count = 0
                # Current is the one after the reverse, so we don't need to worry about 
                # destroying its next pointer
                temp = start.next
                start.next = reverse(start.next, current)
                start = temp
            count += 1
            
            current = current.next
        if count == k:
            start.next = reverse(start.next, current)
        return dummyHead.next