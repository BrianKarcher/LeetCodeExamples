# Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.

# Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

# Return k after placing the final result in the first k slots of nums.

# Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

from typing import List
class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        l = 1
        count = 1
        for r in range(1, len(nums)):
            if nums[r] == nums[r - 1]:
                count += 1
            else:
                count = 1
            if count < 3:
                nums[l] = nums[r]
                l += 1
        return l



from typing import List
class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        l = 0
        count = 1
        for r in range(1, len(nums)):
            # print(f'{r} {nums[r]}')
            if nums[r] == nums[r - 1]:
                count += 1
                if count < 3:
                    l += 1
                    # print(f'setting {nums[r]}')
                    nums[l] = nums[r]
            else:
                l += 1
                # print(f'setting {nums[r]}')
                nums[l] = nums[r]
                count = 1
        # if count < 3 and l != len(nums):
        #     l += 1
        #     nums[l] = nums[-1]
        return l + 1