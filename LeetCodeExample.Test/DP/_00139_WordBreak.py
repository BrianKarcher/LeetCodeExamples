# Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

# Note that the same word in the dictionary may be reused multiple times in the segmentation.

from typing import List
from collections import defaultdict
class Trie:
    def __init__(self):
        self.childs = defaultdict(Trie)
        self.isWord = False

    # def add(word: str):


class Solution:
    def wordBreak(self, s: str, wordDict: List[str]) -> bool:
        root = Trie()
        def buildTrie():
            # build Trie
            for word in wordDict:
                node = root
                for c in word:
                    # defaultdict takes care of the "not exists" condition
                    node = node.childs[c]
                node.isWord = True

        # def searchTrie()

        buildTrie()
        # Record if we can finish a word sequence from the given index
        dp = [False] * len(s)
        # Start from the end
        for i in range(len(s) - 1, -1, -1):
            node = root
            j = i
            while j < len(s) and node:
                if s[j] not in node.childs:
                    break
                node = node.childs[s[j]]
                if node.isWord:
                    # Is this the last word? Or, is the next word a continuation to the last word?
                    if j == len(s) - 1 or dp[j + 1]:
                        dp[i] = True
                        break
                # We continue down the Trie if it is not yet a word
                j += 1
        return dp[0]