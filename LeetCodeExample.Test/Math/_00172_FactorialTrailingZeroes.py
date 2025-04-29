# Given an integer n, return the number of trailing zeroes in n!.

# Note that n! = n * (n - 1) * (n - 2) * ... * 3 * 2 * 1.

# This one is math heavy. Refer to https://leetcode.com/problems/factorial-trailing-zeroes/editorial/?envType=study-plan-v2&envId=top-interview-150
class Solution:
    def trailingZeroes(self, n: int) -> int:
        zeroes = 0
        while n > 0:
            n //= 5
            zero_count += n
        return zero_count

# This was an interesting idea and almost worked.
class Solution:
    def trailingZeroes(self, n: int) -> int:
        # For a trailing zero check, we just need to keep track of the right-most digit
        ans = 0
        last_digit = 1
        for i in range(1, n + 1):
            mul = last_digit * i
            last_digit = mul % 10
            print(f'{i} {last_digit} {mul}')
            while last_digit == 0:
                ans += 1
                # Get the new last digit after consuming the zero
                mul = mul // 10
                last_digit = mul % 10
        return ans