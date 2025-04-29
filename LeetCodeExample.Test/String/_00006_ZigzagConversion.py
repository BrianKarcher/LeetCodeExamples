# The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

# P   A   H   N
# A P L S I I G
# Y   I   R
# And then read line by line: "PAHNAPLSIIGYIR"

# Write the code that will take a string and make this conversion given a number of rows:

# string convert(string s, int numRows);

class Solution:
    def convert(self, s: str, numRows: int) -> str:
        rows = [''] * numRows
        pingPong = 0
        dir = 1
        for c in s:
            rows[pingPong] += c
            if pingPong + dir >= numRows or pingPong + dir < 0:
                dir = dir * -1
            pingPong += dir
        ans = ''.join(rows)
        return ans