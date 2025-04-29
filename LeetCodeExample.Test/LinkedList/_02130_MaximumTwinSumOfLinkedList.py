# In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1.

# For example, if n = 4, then node 0 is the twin of node 3, and node 1 is the twin of node 2. These are the only nodes with twins for n = 4.
# The twin sum is defined as the sum of a node and its twin.

# Given the head of a linked list with even length, return the maximum twin sum of the linked list.

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

# Optimal
# Reverses the second half of the list, then compares. Space is O(1)
class Solution(object):
    def pairSum(self, head):
        slow, fast = head, head
        maximumSum = 0

        # Get middle of the linked list.
        while fast and fast.next:
            fast = fast.next.next
            slow = slow.next

        # Reverse second half of the linked list.
        curr, prev = slow, None
        while curr:       
            curr.next, prev, curr = prev, curr, curr.next
        
        start = head
        while prev:
            maximumSum = max(maximumSum, start.val + prev.val)
            prev = prev.next
            start = start.next

        return maximumSum

# My answer, space is O(n)
from typing import Optional
class Solution:
    def pairSum(self, head: Optional[ListNode]) -> int:
        if not head:
            return -1
        stack = []
        fast = head
        slow = head
        # Find the midpoint, building the stack as we go
        while fast and fast.next:
            stack.append(slow.val)
            fast = fast.next.next
            slow = slow.next
        
        ans = 0
        # Finish the slow while we compare to the stack
        while slow:
            item = stack.pop()
            # print(f'comparing {item} to {slow.val}')
            ans = max(ans, item + slow.val)
            slow = slow.next
        return ans