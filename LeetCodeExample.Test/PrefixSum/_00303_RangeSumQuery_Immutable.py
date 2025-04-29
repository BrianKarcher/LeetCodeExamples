# Given an integer array nums, handle multiple queries of the following type:

# Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
# Implement the NumArray class:

# NumArray(int[] nums) Initializes the object with the integer array nums.
# int sumRange(int left, int right) Returns the sum of the elements of nums between indices left and right inclusive (i.e. nums[left] + nums[left + 1] + ... + nums[right]).

class NumArray:

    def __init__(self, nums: List[int]):
        self.prefixSum = [0] * len(nums)
        sum = 0
        for i in range(len(nums)):
            sum += nums[i]
            self.prefixSum[i] = sum
            #print(sum)

    def sumRange(self, left: int, right: int) -> int:
        if left == 0:
            return self.prefixSum[right]
        return self.prefixSum[right] - self.prefixSum[left - 1]


# Your NumArray object will be instantiated and called as such:
# obj = NumArray(nums)
# param_1 = obj.sumRange(left,right)