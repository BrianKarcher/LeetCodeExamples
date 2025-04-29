# Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def reverseBetween(self, head: Optional[ListNode], left: int, right: int) -> Optional[ListNode]:
        if left == right:
            return head
        before, begin, end, afterEnd = None, None, None, None
        i = 1
        current = head
        while current:
            if i == left - 1:
                before = current
            elif i == left:
                begin = current
            elif i == right:
                end = current
            elif i == right + 1:
                afterEnd = current
            i += 1
            current = current.next
        
        # Detach end from the list so the reverse doesn't include unwanted nodes
        end.next = None
        
        # Reverse the inner list
        prev = None
        current = begin
        while current:
            temp = current.next
            current.next = prev
            prev = current
            current = temp
        
        if before:
            before.next = prev
        begin.next = afterEnd
        return end if left == 1 else head