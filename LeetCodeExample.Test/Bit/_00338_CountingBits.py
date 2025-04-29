# Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.

# Official
# Approach 4: DP + Last Set Bit
# Note that x &= x - 1 sets the last set bit to zero
class Solution:
    def countBits(self, n: int) -> List[int]:
        ans = [0] * (n + 1)
        for x in range(1, n + 1):
            ans[x] = ans[x & (x - 1)] + 1
        return ans 


# My answer
from typing import List
class Solution:
    def countBits(self, n: int) -> List[int]:
        if n == 0:
            return [0]
        if n == 1:
            return [0, 1]
        dp = [0] * (n + 1)
        dp[0] = 0
        dp[1] = 1
        major = 2
        # This requires an explanation
        # To do this in a single pass, we need to locate a previous value
        # Since this is a bit operation, we can find a previous value by removing the most significant bit.
        # 15, bitwise, is 0x1111. To find a previously calculated bit, we subtact the MSB, which is 0x1000. 0x1000 is 8.
        # 15 - 8 = 7. 7, bitwise, is 0x111. Which has three 1's. We add the one for the 8 we lopped off of 15, so 15 has four 1's.
        # Ex. 2. 14 = 0x1110. 14 - 8 = 6. 6 = 0x110, two one bits. 8 = 0x1000, single one bit. So 14 has three 1 bits.
        # We can calculate this quickly since we have previously calculated the number of 1 bits in 6.
        # dp[14] = dp[6] + 1
        
        for i in range(2, n + 1):
            # The only exception to this is the MSB's themselves. We check that here. Those will always be 1.
            if i == major * 2:
                dp[i] = 1
            else:
                dp[i] = dp[i - major] + 1
            if major * 2 == i:
                major *= 2
        return dp