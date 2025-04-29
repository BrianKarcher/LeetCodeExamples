# Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

# You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

# Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

# For the last line of text, it should be left-justified, and no extra space is inserted between words.

# Note:

# A word is defined as a character sequence consisting of non-space characters only.
# Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
# The input array words contains at least one word.

from typing import List
class Solution:
    def fullJustify(self, words: List[str], maxWidth: int) -> List[str]:
        def createFullJustLine(words: List[str]) -> str:
            alphaLength = 0
            for word in words:
                alphaLength += len(word)
            leftOver = maxWidth - alphaLength
            spaceBetween = leftOver // (len(words) - 1)
            # Extra spaces to give to gaps on the left to flesh out the line
            extraSpaces = leftOver % (len(words) - 1)
            line = ''
            first = True
            # print(f'leftOver: {leftOver}')
            # print(f'spaceBetween: {spaceBetween}')
            # print(f'extraSpaces: {extraSpaces}')
            for word in words:
                if first:
                    first = False
                else:
                    line += " " * (spaceBetween + (1 if extraSpaces > 0 else 0))
                    extraSpaces -= 1
                line += word
            line += " " * (maxWidth - len(line))
            return line

        def createLeftJustLine(words: List[str]) -> str:
            line = ''
            first = True
            for word in words:
                if first:
                    first = False
                else:
                    line += " "
                line += word
            line += " " * (maxWidth - len(line))
            return line

        ans = []
        # lines = [[]]
        line = []
        length = 0
        first = True
        for i in range(len(words)):
            word = words[i]
            # Newline check
            if not first and length + len(word) + 1 > maxWidth:
                # Record existing words
                if len(line) > 1:
                    ans.append(createFullJustLine(line))
                else:
                    ans.append(createLeftJustLine(line))
                # lines.append(line)
                line = []
                length = 0
                first = True
            
            line.append(word)
            length += len(word) + (0 if first else 1)
            first = False
        ans.append(createLeftJustLine(line))
        return ans