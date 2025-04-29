# Given a string s representing a valid expression, implement a basic calculator to evaluate it, and return the result of the evaluation.
# Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().

class Solution:
    def calculate(self, s: str) -> int:
        s = s.replace(" ", "")
        # Order of operations is the crux of this problem. Solve parenthesis via stack/recursion first.
        # The other thing to pay CLOSE attention to is the index. When and when not to increment it is vital.
        # Multiplication and division are not part of the problem and can be safely ignored. THANKFULLY!!!
        
        self.idx = 0

        def getNum() -> int:
            num = 0
            while self.idx < len(s) and ord('0') <= ord(s[self.idx]) <= ord('9'):
                num *= 10
                num += int(s[self.idx])
                self.idx += 1
            return num

        # Used to calculate a series of operations inside a paranthesis
        def rec() -> int:
            ans = 0
            isAdd = True
            while self.idx < len(s):
                match s[self.idx]:
                    case '+':
                        isAdd = True
                    case '-':
                        isAdd = False
                    case '(':
                        self.idx += 1
                        # We recurse on parenthesis
                        num = rec()
                        if not isAdd:
                            num = -num
                        ans += num
                    case ')':
                        # move index past the )
                        # self.idx += 1
                        return ans
                    case _:
                        # Only other option is the beginning of a number
                        num = getNum()
                        if not isAdd:
                            num = -num
                        ans += num
                         # the index is already one past the number, don't double increment
                        continue
                self.idx += 1
            return ans
        return rec()