# Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
# You must not use any built-in exponent function or operator.

class Solution:
    def mySqrt(self, x: int) -> int:
        if x < 2:
            return x
        l = 2
        r = int(x / 2)
        while l <= r:
            mid = l + (r - l) // 2
            # print(f'{mid}')
            mid2 = mid ** 2
            if mid2 == x:
                return int(mid)
            elif x < mid2:
                # Move left
                r = mid - 1
            else:
                l = mid + 1
        return r