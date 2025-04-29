# Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
from typing import List
from collections import deque
class Solution:
    def rightSideView(self, root: Optional[TreeNode]) -> List[int]:
        if root == None:
            return []
        ans = []
        q = deque()
        q.append(root)
        # do BFS
        while len(q) != 0:
            # Append right side
            ans.append(q[-1].val)
            count = len(q)
            # Consume this entire level while setting up next level
            for i in range(count):
                item = q.popleft()
                if item.left != None:
                    q.append(item.left)
                if item.right != None:
                    q.append(item.right)
        return ans