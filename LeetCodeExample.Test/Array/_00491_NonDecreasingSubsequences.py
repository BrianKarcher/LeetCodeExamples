# Given an integer array nums, return all the different possible non-decreasing subsequences of the given array with at least two elements. You may return the answer in any order.

class Solution:
    def findSubsequences(self, nums: List[int]) -> List[List[int]]:
        result = set()
        seq = []
        def dfs(start_index: int):
            if len(seq) >= 2:
                result.add(tuple(seq)) # sets support tuples to remove duplicates
            
            for i in range(start_index, len(nums)):
                if not seq or nums[i] >= seq[-1]:
                    seq.append(nums[i])
                    dfs(i + 1)
                    seq.pop() # backtrack

        dfs(0)
        return [list(seq) for seq in result]