# Your task is to calculate ab mod 1337 where a is a positive integer and b is an extremely large positive integer given in the form of an array.

 

# Example 1:

# Input: a = 2, b = [3]
# Output: 8
# Example 2:

# Input: a = 2, b = [1,0]
# Output: 1024
# Example 3:

# Input: a = 1, b = [4,3,3,8,5,2]
# Output: 1

# This solution involves a little math, refer to https://leetcode.com/problems/super-pow/solutions/84472/c-clean-and-short-solution/
# The crux is a^1234567 % k = (a^1234560 % k) * (a^7 % k) % k = (a^123456 % k)^10 % k * (a^7 % k) % k
# which you iterate once for each digit

class Solution:

    def powmod(self, a: int, k: int) -> int:
        a %= 1337
        result = 1
        for n in range(k):
            result = (result * a) % 1337
        return result

    def superPow(self, a: int, b: List[int]) -> int:
        if len(b) == 0:
            return 1

        lastdigit = b[len(b) - 1]
        b = b[0:-1]

        return self.powmod(self.superPow(a, b), 10) * self.powmod(a, lastdigit) % 1337

class Solution:
    def superPow(self, a: int, b: List[int]) -> int:
        base = 1
        for i in range(len(b) - 1):
            base *= 10
        print(base)
        ans = 1
        for n in b:
            ans = (ans * (pow(a, int(n * base)))) % 1337
            base /= 10
            
        return int(ans)