# Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
# If target is not found in the array, return [-1, -1].
# You must write an algorithm with O(log n) runtime complexity.

from typing import List
class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        if not nums:
            return [-1, -1]

        def findLeft() -> int:
            l = 0
            r = len(nums) - 1
            leftMost = -1
            while l <= r:
                mid = (l + r) // 2
                if nums[mid] == target:
                    leftMost = mid
                    r = mid - 1
                elif target < nums[mid]:
                    # Move left
                    r = mid - 1
                else:
                    l = mid + 1
            return leftMost
        
        def findRight() -> int:
            l = 0
            r = len(nums) - 1
            rightMost = -1
            while l <= r:
                mid = (l + r) // 2
                if nums[mid] == target:
                    rightMost = mid
                    l = mid + 1
                elif target < nums[mid]:
                    # Move left
                    r = mid - 1
                else:
                    l = mid + 1
            return rightMost
        
        left = findLeft()
        if left == -1:
            return [-1, -1]
        right = findRight()
        return [left, right]
    
#############################

from typing import List
class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        if not nums:
            return [-1, -1]
        l = 0
        r = len(nums) - 1
        first = -1
        # Find first index
        # 2-space search since we need to compare two values next to each other
        while l < r:
            mid = (l + r) // 2
            if nums[mid + 1] == target and nums[mid] < nums[mid + 1]:
                l = mid
                r = mid + 1
                break
            elif target == nums[mid] == nums[mid + 1]:
                # Go left
                r = mid
            elif target < nums[mid + 1]:
                # move left
                r = mid
            else:
                l = mid + 1
        # The above BS always searches for mid + 1 == target, but never checks index 0
        # print(f'{l} {r}')
        if nums[l] == target:
            first = l
        elif nums[r] == target:
            first = r
        if first == -1:
            print(f'first is -1')
            return [-1, -1]
        second = -1
        # find second index
        l = 0
        r = len(nums) - 1
        while l < r:
            mid = (l + r) // 2
            if nums[mid] == target and nums[mid + 1] > nums[mid]:
                l = mid
                r = mid + 1
                break
            elif target == nums[mid] == nums[mid + 1]:
                # Go right
                l = mid + 1
            elif target < nums[mid]:
                r = mid
            else:
                l = mid + 1
        # The above BS always searches mid == target, but never mid + 1
        # print(f'{l} {r}')
        if nums[r] == target:
            second = r
        elif nums[l] == target:
            second = l
        return [first, second]