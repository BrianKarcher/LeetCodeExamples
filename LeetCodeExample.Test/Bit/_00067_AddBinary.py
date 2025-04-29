#Given two binary strings a and b, return their sum as a binary string.

class Solution:
    def addBinary(self, a: str, b: str) -> str:
        m = len(a) - 1
        n = len(b) - 1
        carry = 0
        ans = ""
        while m >= 0 or n >= 0 or carry:
            digit = 0
            if m >= 0 and a[m] == "1":
                digit += 1
            if n >= 0 and b[n] == "1":
                digit += 1
            digit += carry
            if digit >= 2:
                digit -= 2
                carry = 1
            else:
                carry = 0
            m -= 1
            n -= 1
            ans = ("0" if digit == 0 else "1") + ans
        return ans
    
##############

class Solution:
    def addBinary(self, a: str, b: str) -> str:
        length = max(len(a), len(b))
        carry = False
        rtn = ""
        for i in range(length):
            count = 0
            if carry:
                count += 1
                carry = False
            if i < len(a) and a[i * -1 - 1] == "1":
                count += 1
            if i < len(b) and b[i * -1 - 1] == "1":
                count += 1
            
            #print(f"{i}, {count}")
            if count == 0:
                rtn = "0" + rtn
            elif count == 1:
                rtn = "1" + rtn
            elif count == 2:
                rtn = "0" + rtn
                carry = True
            elif count == 3:
                rtn = "1" + rtn
                carry = True
        if carry == True:
            rtn = "1" + rtn
        return rtn