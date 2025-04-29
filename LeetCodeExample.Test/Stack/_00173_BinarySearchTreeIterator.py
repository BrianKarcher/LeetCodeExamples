# Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):

# BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor. The pointer should be initialized to a non-existent number smaller than any element in the BST.
# boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
# int next() Moves the pointer to the right, then returns the number at the pointer.
# Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

# You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
from collections import deque
class BSTIterator:
    # Uses in-order traversal
    def __init__(self, root: Optional[TreeNode]):
        self.root = root
        self.stack = deque()
        # self.stack always points to the next node
        self.traverseLeft(root)

    # Finds the next number, adding nodes to the stack as it goes
    # Next number is found when left is null
    def traverseLeft(self, node: Optional[TreeNode]):
        if not node:
            return
        self.stack.append(node)
        self.traverseLeft(node.left)

    def next(self) -> int:
        item = self.stack.pop()
        # Find the next node after this one, if possible
        self.traverseLeft(item.right)
        return item.val

    def hasNext(self) -> bool:
        return len(self.stack) != 0


# Your BSTIterator object will be instantiated and called as such:
# obj = BSTIterator(root)
# param_1 = obj.next()
# param_2 = obj.hasNext()