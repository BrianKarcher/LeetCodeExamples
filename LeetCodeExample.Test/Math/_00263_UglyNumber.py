import math
class Solution:
    def isUgly(self, n: int) -> bool:
        if n == 1:
            return True
        if n == 0:
            return False
        while n != 2 and n != 3 and n != 5:
            if n % 2 == 0:
                n = math.floor(n / 2)
            elif n % 3 == 0:
                n = math.floor(n / 3)
            elif n % 5 == 0:
                n = math.floor(n / 5)
            else:
                return False
        return True