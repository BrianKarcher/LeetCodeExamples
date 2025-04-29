# Given a binary tree with the following rules:

# root.val == 0
# For any treeNode:
# If treeNode.val has a value x and treeNode.left != null, then treeNode.left.val == 2 * x + 1
# If treeNode.val has a value x and treeNode.right != null, then treeNode.right.val == 2 * x + 2
# Now the binary tree is contaminated, which means all treeNode.val have been changed to -1.

# Implement the FindElements class:

# FindElements(TreeNode* root) Initializes the object with a contaminated binary tree and recovers it.
# bool find(int target) Returns true if the target value exists in the recovered binary tree.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import Optional
class FindElements:

    def __init__(self, root: Optional[TreeNode]):
        self.map = set()
        self.mapTree(root, 0)
    
    def mapTree(self, node: TreeNode | None, val: int):
        if node == None:
            return
        self.map.add(val)
        self.mapTree(node.left, val * 2 + 1)
        self.mapTree(node.right, val * 2 + 2)

    def find(self, target: int) -> bool:
        return target in self.map


# Your FindElements object will be instantiated and called as such:
# obj = FindElements(root)
# param_1 = obj.find(target)