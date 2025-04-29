# Given two non-negative integers, num1 and num2 represented as string, return the sum of num1 and num2 as a string.

# You must solve the problem without using any built-in library for handling large integers (such as BigInteger). You must also not convert the inputs to integers directly.

class Solution:
    def addStrings(self, num1: str, num2: str) -> str:
        i = len(num1) - 1
        j = len(num2) - 1
        carry = 0
        ans = ""
        while i >= 0 or j >= 0 or carry == 1:
            add = carry
            if i >= 0:
                add += int(num1[i])
                i -= 1
            if j >= 0:
                add += int(num2[j])
                j -= 1
            ans = str(add % 10) + ans
            carry = 1 if add >= 10 else 0
        return ans
    


class Solution:
     def addStrings(self, num1: str, num2: str) -> str:
        l = max(len(num1), len(num2))
        carry = 0
        ans = ""
        for i in range(-1, -l - 1, -1):
            i1 = 0
            if len(num1) >= -i:
                i1 = int(num1[i])
            i2 = 0
            if len(num2) >= -i:
                i2 = int(num2[i])
            i3 = i1 + i2 + carry
            if i3 >= 10:
                i3 = i3 % 10
                carry = 1
            else:
                carry = 0
            ans = str(i3) + ans
        if carry != 0:
            ans = "1" + ans
        return ans