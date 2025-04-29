#Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.

class Solution:
    def findDisappearedNumbers(self, nums: List[int]) -> List[int]:
        hash = set()
        for num in nums:
            hash.add(num)
        
        rtn = []
        for i in range(1, len(nums) + 1):
            if i not in hash:
                rtn.append(i)
                
        return rtn