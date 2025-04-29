# Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i], nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].

# Return true if there is a 132 pattern in nums, otherwise, return false.
# https://leetcode.com/problems/132-pattern/solutions/94071/single-pass-c-o-n-space-and-time-solution-8-lines-with-detailed-explanation/
# https://leetcode.com/problems/132-pattern/solutions/4107421/99-35-stack-left-approach-binary-search/
class Solution:
    def find132pattern(self, nums: List[int]) -> bool:
        s3 = float('-inf')
        # Monotonic increasing stack
        stack = []
        # Go from right to left
        # for i in range(len(nums) - 1, -1, -1):
        for num in reversed(nums):
            if num < s3:
                return True
            while len(stack) != 0 and num > stack[-1]:
                s3 = stack.pop()
            stack.append(num)
        return False