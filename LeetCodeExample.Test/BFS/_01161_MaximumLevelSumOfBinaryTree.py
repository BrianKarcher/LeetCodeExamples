# Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
# Return the smallest level x such that the sum of all the values of nodes at level x is maximal.

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

from typing import Optional
from collections import deque
class Solution:
    def maxLevelSum(self, root: Optional[TreeNode]) -> int:
        q = deque()
        q.append(root)
        level = 0
        max_sum = float('-inf')
        ans = 0
        while q:
            level += 1
            count = len(q)
            level_sum = 0
            for i in range(count):
                item = q.popleft()
                level_sum += item.val
                if item.left:
                    q.append(item.left)
                if item.right:
                    q.append(item.right)
            if level_sum > max_sum:
                max_sum = level_sum
                ans = level
        return ans