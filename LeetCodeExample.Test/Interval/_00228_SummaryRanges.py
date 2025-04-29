from typing import List
class Solution:
    def summaryRanges(self, nums: List[int]) -> List[str]:
        if len(nums) == 0:
            return []
        ans = []
        bi = 0

        def addRange(bi, ei):
            if bi == -1:
                return
            range = ""
            if nums[bi] == nums[ei]:
                range = str(nums[bi])
            else:
                range = f'{nums[bi]}->{nums[ei]}'
            ans.append(range)

        for i in range(1, len(nums)):
            # Starting a new range?
            if nums[i] != nums[i - 1] + 1:
                addRange(bi, i - 1)
                bi = i
        addRange(bi, len(nums) - 1)
        return ans
    
class Solution:
    def summaryRanges(self, nums: List[int]) -> List[str]:
        if nums == None:
            return None
        rtn = []
        r = 0
        while r < len(nums):
            start = nums[r]
            while r + 1 < len(nums) and nums[r] + 1 == nums[r + 1]:
                r += 1
            if start != nums[r]:
                rtn.append(f"{start}->{nums[r]}")
            else:
                rtn.append(f"{start}")
            r += 1
        return rtn