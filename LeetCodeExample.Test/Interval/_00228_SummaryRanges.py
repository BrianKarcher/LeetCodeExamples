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