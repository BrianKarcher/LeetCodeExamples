# Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
# You should preserve the original relative order of the nodes in each of the two partitions.

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
# Definition for singly-linked list.

# Optimal
from typing import Optional
class Solution:
    def partition(self, head: Optional[ListNode], x: int) -> Optional[ListNode]:
        before = before_head = ListNode(0)
        after = after_head = ListNode(0)
        while head:
            if head.val < x:
                before.next = head
                before = before.next
            else:
                after.next = head
                after = after.next
            head = head.next
        after.next = None
        before.next = after_head.next
        return before_head.next

# My dumb answer
from typing import Optional
class Solution:
    def partition(self, head: Optional[ListNode], x: int) -> Optional[ListNode]:
        dummyHead = ListNode(0)
        dummyHead.next = head
        r = dummyHead
        # lCurrent = head
        l = dummyHead
        # We only ever move r.next
        while r and r.next:
            # print(f'{l.val} {r.val} {r.next.val}')
            if r.next.val < x:
                # Move r.next to after l
                # Pop r.next from the linked list
                popped = r.next
                # print(f'moving {popped.val}')
                r.next = r.next.next
                # Place it after l 
                l_temp = l.next
                l.next = popped 
                popped.next = l_temp
                if r == l:
                    r = r.next
                if l.next.val < x:
                    l = l.next
            else:
                r = r.next
                # Keep in-place ordering but l.val must always be less than x
                if l.next.val < x:
                    l = l.next
        return dummyHead.next