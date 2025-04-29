# There is an integer array nums sorted in ascending order (with distinct values).
# Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
# Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
# You must write an algorithm with O(log n) runtime complexity.

from typing import List
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        l = 0
        r = len(nums) - 1
        while l <= r:
            mid = (l + r) // 2
            if nums[mid] == target:
                return mid
            elif nums[mid] >= nums[l]:
                # the left side is not rotated, we can check the range for a possible target
                if nums[l] <= target < nums[mid]:
                    # Shift left
                    r = mid - 1
                else:
                    l = mid + 1
            else:
                # The right side is not rotated
                if nums[mid] < target <= nums[r]:
                    # Shift right
                    l = mid + 1
                else:
                    r = mid - 1
        return -1
    
###########################


from typing import List
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        l = 0
        r = len(nums) - 1
        # Find the pivot point
        pivot = -1
        while l < r:
            mid = (l + r) // 2
            if nums[mid] > nums[mid + 1]:
                pivot = mid
                break
            elif nums[mid] > nums[-1]:
                # Go right
                l = mid + 1
            else:
                r = mid
        
        if pivot == -1:
            # Not a rotated array, search as normal
            l = 0
            r = len(nums) - 1
        elif nums[0] <= target <= nums[pivot]:
            # Target is left of pivot
            l = 0
            r = pivot
        else:
            l = pivot + 1
            r = len(nums) - 1
        
        while l <= r:
            mid = (l + r) // 2
            if nums[mid] == target:
                return mid
            elif target > nums[mid]:
                # Go right
                l = mid + 1
            else:
                # Go left
                r = mid - 1
        return -1