# Given a binary tree

# struct Node {
#   int val;
#   Node *left;
#   Node *right;
#   Node *next;
# }
# Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.
# Initially, all next pointers are set to NULL.
# Definition for a Node.

# Follow-up:

# You may only use constant extra space.
# The recursive approach is fine. You may assume implicit stack space does not count as extra space for this problem.

class Node:
    def __init__(self, val: int = 0, left: 'Node' = None, right: 'Node' = None, next: 'Node' = None):
        self.val = val
        self.left = left
        self.right = right
        self.next = next


# Optimal, uses O(1) extra space by using the "next" pointers as a linked list for the level.
class Solution:
    def processChild(self, child, leftmost, prev):
        if child:
            if prev:
                prev.next = child
            else:
                leftmost = child
            prev = child
        return leftmost, prev
    def connect(self, root: 'Node') -> 'Node':
        if not root:
            return None
        leftmost = root
        while leftmost:
            prev = None
            current = leftmost
            leftmost = None
            while current:
                leftmost, prev = self.processChild(current.left, leftmost, prev)
                leftmost, prev = self.processChild(current.right, leftmost, prev)
                current = current.next
        return root
    

# Uses O(N) extra space

from collections import deque
class Solution:
    def connect(self, root: 'Node') -> 'Node':
        if not root:
            return None
        q = deque()
        q.append(root)
        while q:
            prev = None
            count = len(q)
            for _ in range(count):
                item = q.popleft()
                if prev:
                    prev.next = item
                prev = item
                if item.left:
                    q.append(item.left)
                if item.right:
                    q.append(item.right)
        return root