# You are given a string s and an array of strings words. All the strings of words are of the same length.

# A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

# For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
# Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

from typing import List
from collections import Counter, deque
class Solution:
    def findSubstring(self, s: str, words: List[str]) -> List[int]:
        wordLength = len(words[0])
        windowSize = len(words) * wordLength
        if windowSize > len(s):
            return []
        mainCounter = Counter(words)
        
        # All words are the same length. We are going to split s into words of equal sizes
        # up to the size of len(words). We will take those words in s and subtract their counts
        # from Counter. As we shift the sliding window to the right, we will add a word on the
        # right and remove a word on the left.

        # If at any time, Counter reaches 0, we have a valid index
        # We repeat this until the end of the string.
        # We need to repeat with an offset that will go from 0 to len(words[0]). This will max 30.

        ans = []
        # This will execute 1 to 30 times
        for offset in range(wordLength):
            count = len(words)
            counter = Counter(mainCounter)
            # def counterCheck():

            # Preprocess the initial sliding window
            # for i in range(windowSize):
            wordList = deque()
            l = 0
            for r in range(len(s) // wordLength):
                if r - l > len(words) - 1:
                    # Move left pointer
                    leftMost = wordList.popleft()
                    if leftMost in counter:
                        if counter[leftMost] >= 0:
                            count += 1
                        counter[leftMost] += 1
                    l += 1

                string = s[offset + r * wordLength:offset + r * wordLength + wordLength]
                wordList.append(string)
                if string in counter:
                    counter[string] -= 1
                    if counter[string] >= 0:
                        count -= 1
                        if count == 0:
                            ans.append(offset + l * wordLength)
                            # print(f'appending {offset + l * wordLength}')
                # print(string)
                # print(count)
                # print(counter)
                # print(wordList)
        return ans