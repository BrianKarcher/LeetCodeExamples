# Given the head of a linked list, return the list after sorting it in ascending order.

from typing import List, Optional
# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def sortList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head or not head.next:
            return head

        # Do a bubble sort. It's not the fastest but I can get this out within interview time limits. O(n^2)
        # This gives a TLE
        while True:
            swaps = 0
            prev = head
            current = prev.next
            while current != None:
                if prev.val > current.val:
                    prev.val, current.val = current.val, prev.val
                    swaps += 1
                prev = current
                current = current.next
            if swaps == 0:
                break
        return head