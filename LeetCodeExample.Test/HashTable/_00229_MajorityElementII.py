# Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

class Solution:
    def majorityElement(self, nums: List[int]) -> List[int]:
        counts = defaultdict(int)
        for num in nums:
            counts[num] += 1
        rtn = []
        for k, v in counts.items():
            if v > len(nums) // 3:
                rtn.append(k)
        return rtn