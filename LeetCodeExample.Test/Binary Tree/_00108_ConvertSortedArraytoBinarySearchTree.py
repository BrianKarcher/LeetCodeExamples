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
        return self.recurse(nums, 0, len(nums) - 1)
    
    def recurse(self, nums: List[int], l: int, r: int):
        # base case
        if r < l:
            return None
        if r == l:
            return TreeNode(nums[r])
        
        # split the list in two around the mid point
        mid = int((l + r) / 2)
        left = self.recurse(nums, l, mid - 1)
        right = self.recurse(nums, mid + 1, r)
        # the mid point is this node
        return TreeNode(nums[mid], left, right)