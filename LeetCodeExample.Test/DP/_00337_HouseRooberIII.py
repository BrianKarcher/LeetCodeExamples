# The thief has found himself a new place for his thievery again. There is only one entrance to this area, called root.

# Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that all houses in this place form a binary tree. It will automatically contact the police if two directly-linked houses were broken into on the same night.

# Given the root of the binary tree, return the maximum amount of money the thief can rob without alerting the police.

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def rob(self, root: Optional[TreeNode]) -> int:
        def dfs(root):
            if root == None:
                return [0, 0]
            left = dfs(root.left)
            right = dfs(root.right)
            # return both Pick and Not Pick so the root can choose the correct one
            # 0 = Pick
            # 1 = Not Pick
            return [root.val + left[1] + right[1],
                max(left[0], left[1]) + max(right[0], right[1])] # Not pick -> Not Pick is a valid choice

        if root.left == None and root.right == None:
            return root.val
        val = dfs(root)
        return max(val[0], val[1])