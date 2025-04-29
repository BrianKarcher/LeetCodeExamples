# You are given two integers n and x. You have to construct an array of positive integers nums of size n where for every 0 <= i < n - 1, nums[i + 1] is greater than nums[i], and the result of the bitwise AND operation between all elements of nums is x.

# Return the minimum possible value of nums[n - 1].

class Solution:
    def minEnd(self, n: int, x: int) -> int:
        n_1 = n - 1
        ans = 0
        j = 0
        for i in range(56):
            if (x >> i) & 1:
                ans |= 1 << i
            else:
                if (n_1 >> j) & 1:
                    ans |= 1 << i
                j += 1
        return ans