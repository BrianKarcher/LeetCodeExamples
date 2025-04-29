# You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

# Merge all the linked-lists into one sorted linked-list and return it.

from typing import Optional
from typing import List
class ListNode:
    def __init__(self, val=0, next=None):
         self.val = val
         self.next = next
class Solution:
    def mergeKLists(self, lists: List[Optional[ListNode]]) -> Optional[ListNode]:
        def merge2Lists(l1, l2) -> Optional[ListNode]:
            head = point = ListNode(0)
            while l1 and l2:
                if l1.val < l2.val:
                    point.next = l1
                    l1 = l1.next
                else:
                    point.next = l2
                    l2 = l2.next
                point = point.next
            # Add any last remaining node
            point.next = l1 or l2
            return head.next

        interval = 1
        amount = len(lists)
        while interval < amount:
            for i in range(0, amount - interval, interval * 2):
                lists[i] = merge2Lists(lists[i], lists[i + interval])
            interval *= 2

        return lists[0] if amount > 0 else None