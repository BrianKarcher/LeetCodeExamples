# Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

# Basically, the deletion can be divided into two stages:

# Search for a node to remove.
# If the node is found, delete the node.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import Optional
class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        def findInOrderSuccessor(node: TreeNode) -> TreeNode:
            while (node.left):
                node = node.left
            return node

        def find(node: Optional[TreeNode], key: int) -> Optional[TreeNode]:
            if not node:
                return None
            if key < node.val:
                node.left = find(node.left, key)
            elif key > node.val:
                node.right = find(node.right, key)
            else:
                # case 1: Leaf node
                if not node.left and not node.right:
                    return None
                # case 2: One child
                if not node.left:
                    return node.right
                if not node.right:
                    return node.left
                # case 3: Two children

                # Found! Delete!
                #right = node.right
                IS = findInOrderSuccessor(node.right)
                node.val = IS.val
                node.right = find(node.right, IS.val)
                #if not node:
                #    return right
                #node.right = right
            return node
        return find(root, key)