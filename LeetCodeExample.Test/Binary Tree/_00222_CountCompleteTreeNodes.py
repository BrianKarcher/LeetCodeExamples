# Given the root of a complete binary tree, return the number of the nodes in the tree.

# According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

# Design an algorithm that runs in less than O(n) time complexity.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def countNodes(self, root: Optional[TreeNode]) -> int:
        return 1 + self.countNodes(root.right) + self.countNodes(root.left) if root else 0
    


class Solution:
    def countNodes(self, root: Optional[TreeNode]) -> int:
        self.maxHeight = 0
        self.ans = 0
        self.isDone = False
        def rec(node: Optional[TreeNode], h: int, val: int):
            if not node:
                return 0
            if self.isDone:
                return 0
            # Traverse down the right side until we get to that level
            self.maxHeight = max(self.maxHeight, h)
            self.ans = max(self.ans, val)
            
            rec(node.left, h + 1, val * 2)
            if node.left and not node.right:
                self.isDone = True
                return
            rec(node.right, h + 1, val * 2 + 1)

        rec(root, 1, 1)
        return self.ans