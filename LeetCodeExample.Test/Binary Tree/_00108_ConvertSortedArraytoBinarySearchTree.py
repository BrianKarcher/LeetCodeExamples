# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
from typing import Optional
from typing import List
class Solution:
    def sortedArrayToBST(self, nums: List[int]) -> Optional[TreeNode]:
        def recurse(l: int, r: int) -> Optional[TreeNode]:
            if l > r:
                return None
            mid = (l + r) // 2
            return TreeNode(nums[mid], recurse(l, mid - 1), recurse(mid + 1, r))
        return recurse(0, len(nums) - 1)