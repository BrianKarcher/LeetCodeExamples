# Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


from typing import Optional
import sys
class Solution:
    def getMinimumDifference(self, root: Optional[TreeNode]) -> int:
        self.ans = sys.maxsize
        self.prevNode = None
        def rec(node: Optional[TreeNode]):
            if not node:
                return
            rec(node.left)
            if self.prevNode:
                self.ans = min(self.ans, node.val - self.prevNode.val)
            self.prevNode = node
            rec(node.right)
        rec(root)
        return self.ans





#################################


from typing import Optional
import sys
class Solution:
    def getMinimumDifference(self, root: Optional[TreeNode]) -> int:
        ans = sys.maxsize
        def rec(node: Optional[TreeNode]):
            nonlocal ans
            if not node:
                return None
            left = rec(node.left)
            if left:
                ans = min(ans, abs(left[1] - node.val))
            right = rec(node.right)
            if right:
                ans = min(ans, abs(right[0] - node.val))
            return (left[0] if left else node.val, right[1] if right else node.val)
        rec(root)
        return ans