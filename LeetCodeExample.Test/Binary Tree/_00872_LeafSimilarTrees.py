# Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def leafSimilar(self, root1: Optional[TreeNode], root2: Optional[TreeNode]) -> bool:
        leaf1 = []
        def build_leafs(node: Optional[TreeNode]):
            if node is None:
                return
            if node.left == node.right == None:
                leaf1.append(node.val)
                return
            build_leafs(node.left)
            build_leafs(node.right)
        
        build_leafs(root1)
        self.leaf1_index = 0
        self.is_valid = True
        def check_similar(node: Optional[TreeNode]):
            if node is None:
                return False
            if not self.is_valid:
                return
            if node.left == node.right == None:
                if self.leaf1_index >= len(leaf1):
                    self.is_valid = False
                    return
                if leaf1[self.leaf1_index] == node.val:
                    self.leaf1_index += 1
                else:
                    self.is_valid = False
            check_similar(node.left)
            check_similar(node.right)
        check_similar(root2)
        # print(leaf1)
        # print(self.is_valid)
        # print(self.leaf1_index)
        return self.is_valid and self.leaf1_index == len(leaf1)