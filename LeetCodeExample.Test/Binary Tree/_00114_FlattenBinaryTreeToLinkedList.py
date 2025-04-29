# Given the root of a binary tree, flatten the tree into a "linked list":

# The "linked list" should use the same TreeNode class where the right child pointer points to the next node in the list and the left child pointer is always null.
# The "linked list" should be in the same order as a pre-order traversal of the binary tree.

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def flatten(self, root: Optional[TreeNode]) -> None:
        """
        Do not return anything, modify root in-place instead.
        """
        def sub(root: Optional[TreeNode]) -> Optional[TreeNode]:
            if root is None:
                return None
            #print(root)
            left = sub(root.left)
            #print(left)
            right = sub(root.right)
            if (left is not None):
                # attach right leg to the end of the left leg
                left.right = root.right
                root.right = root.left
            root.left = None
            #print(root.val)
            #print(left)
            #print(right)
            #print(right or left or root)
            return right or left or root
        sub(root)