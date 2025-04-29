# You are given the head of a linked list. Delete the middle node, and return the head of the modified linked list.
# The middle node of a linked list of size n is the ⌊n / 2⌋th node from the start using 0-based indexing, where ⌊x⌋ denotes the largest integer less than or equal to x.
# For n = 1, 2, 3, 4, and 5, the middle nodes are 0, 1, 1, 2, and 2, respectively.

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
from typing import Optional
class Solution:
    def deleteMiddle(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not head or not head.next:
            return None
        
        prev = None
        # The dummy head reduces complexity of the algorithm
        dummy = ListNode(0, head)
        fast = dummy
        slow: ListNode = dummy
        # Slow is the middle node since it goes half speed
        # fast always needs to be on a real value
        while fast and fast.next and fast.next.next:
            fast = fast.next.next
            slow = slow.next
            # print(f'slow: {slow.val}, fast: {-1 if not fast else fast.val}')
        
        # Based on the problem, on both even and odd ll sizes the NEXT slow is the middle
        # Which we are deleting, so...
        slow.next = slow.next.next
        return dummy.next