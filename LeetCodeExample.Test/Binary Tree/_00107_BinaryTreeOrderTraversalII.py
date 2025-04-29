from collections import deque
from typing import Optional
from typing import List
# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def levelOrderBottom(self, root: Optional[TreeNode]) -> List[List[int]]:
        if root == None:
            return []
        queue = deque()
        rtn = []
        queue.append(root)
        while len(queue) > 0:
            size = len(queue)
            row = []
            rtn.append(row)
            for i in range(size):
                item = queue.popleft()
                row.append(item.val)
                if item.left != None:
                    queue.append(item.left)
                if item.right != None:
                    queue.append(item.right)
        return list(reversed(rtn))