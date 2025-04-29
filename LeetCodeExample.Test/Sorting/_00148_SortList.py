# Given the head of a linked list, return the list after sorting it in ascending order.

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional
class Solution:
    def sortList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        def merge(list1: Optional[ListNode], list2: Optional[ListNode]) -> Optional[ListNode]:
            dummyHead = ListNode(0)
            tail = dummyHead
            while list1 and list2:
                if list1.val < list2.val:
                    tail.next = list1
                    list1 = list1.next
                else:
                    tail.next = list2
                    list2 = list2.next
                tail = tail.next
            tail.next = list1 if list1 else list2
            return dummyHead.next
        
        def split(node: Optional[ListNode]) -> Optional[ListNode]:
            slow = None
            while node and node.next:
                slow = node if not slow else slow.next
                node = node.next.next
            mid = slow.next
            slow.next = None
            return mid

        def recurse(node: Optional[ListNode]) -> Optional[ListNode]:
            if not node or not node.next:
                return node
            mid = split(node)
            # Split the list to left and right and sort them
            left = recurse(node)
            right = recurse(mid)
            # merge the sorted lists
            return merge(left, right)
        
        return recurse(head)

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