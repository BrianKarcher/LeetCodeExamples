# Given the head of a linked list, remove the nth node from the end of the list and return its head.

# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
from typing import Optional
class Solution:
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:
        size = 0
        dummyHead = ListNode(0)
        dummyHead.next = head
        current = head
        prev = dummyHead
        while current:
            size += 1
            current = current.next
            if size > n:
                prev = prev.next
        # print(f'{prev.val}')
        prev.next = prev.next.next
        return dummyHead.next
    

#################

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:
        size = 0
        current = head
        while current:
            size += 1
            current = current.next
        dummyHead = ListNode(0)
        dummyHead.next = head
        remove = size - n
        current = dummyHead.next
        prev = dummyHead
        while current:
            # print(f'{remove}')
            if remove == 0:
                prev.next = current.next
                return dummyHead.next
            prev = current
            current = current.next
            remove -= 1