# Reverse bits of a given 32 bits unsigned integer.

# Note:

# Note that in some languages, such as Java, there is no unsigned integer type. In this case, both input and output will be given as a signed integer type. They should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
# In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 2 above, the input represents the signed integer -3 and the output represents the signed integer -1073741825.


class Solution:
    def reverseBits(self, n: int) -> int:
        rtn = 0
        for x in range(32):
            # Get the bit from the right
            bit = n & 1
            # Shift n
            n = n >> 1
            # Due to the order of the shifting, the new bits end up on the left
            rtn = rtn << 1
            rtn += bit
        return rtn