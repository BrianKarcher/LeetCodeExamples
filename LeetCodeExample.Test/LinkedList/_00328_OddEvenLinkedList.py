# Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.

# The first node is considered odd, and the second node is even, and so on.

# Note that the relative order inside both the even and odd groups should remain as it was in the input.

# You must solve the problem in O(1) extra space complexity and O(n) time complexity.

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def oddEvenList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head or not head.next:
            return head
        
        evenStart = head.next
        currentOdd = head
        currentEven = evenStart
        while currentEven and currentEven.next:
            currentOdd.next = currentEven.next
            currentOdd = currentOdd.next
            currentEven.next = currentOdd.next
            currentEven = currentEven.next
        
        currentOdd.next = evenStart
        # The head stays the same
        return head