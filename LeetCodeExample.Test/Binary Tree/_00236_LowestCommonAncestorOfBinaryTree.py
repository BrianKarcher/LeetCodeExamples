# Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

# According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

from typing import Optional
class Solution:
    def lowestCommonAncestor(self, root: 'TreeNode', p: 'TreeNode', q: 'TreeNode') -> 'TreeNode':
        self.isComplete = False
        self.ans = TreeNode(0)
        def dfs(node: Optional[TreeNode]) -> bool:
            if self.isComplete:
                return False
            if node == None:
                return False
            left = dfs(node.left)
            right = dfs(node.right)
            if left and right:
                self.isComplete = True
                self.ans = node
                return False
            if node == p or node == q:
                if left or right:
                    self.ans = node
                return True
            return left or right
            
        dfs(root)
        return self.ans