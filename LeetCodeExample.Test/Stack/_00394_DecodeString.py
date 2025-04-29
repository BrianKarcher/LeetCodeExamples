# Given an encoded string, return its decoded string.
# The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.
# You may assume that the input string is always valid; there are no extra white spaces, square brackets are well-formed, etc. Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there will not be input like 3a or 2[4].
# The test cases are generated so that the length of the output will never exceed 105.

class Solution:
    def decodeString(self, s: str) -> str:
        self.i = 0

        def getNum() -> int:
            # get a number
            num = 0
            while self.i < len(s) and s[self.i].isdigit():
                num = num * 10 + int(s[self.i])
                self.i += 1
            return num
        
        def recurse() -> str:
            # This function gets called whenever we need to process a group
            rtn = ''
            while self.i < len(s) and s[self.i] != ']':
                if not s[self.i].isdigit():
                    rtn = rtn + s[self.i]
                else:
                    # Encountered a numeric
                    num = getNum()
                    self.i += 1 # get past  the [
                    inside = recurse()
                    for n in range(num):
                        rtn += inside
                self.i += 1
            return rtn
        return recurse()