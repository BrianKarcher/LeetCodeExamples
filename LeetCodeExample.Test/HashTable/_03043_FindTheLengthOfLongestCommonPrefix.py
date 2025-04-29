# You are given two arrays with positive integers arr1 and arr2.
# A prefix of a positive integer is an integer formed by one or more of its digits, starting from its leftmost digit. For example, 123 is a prefix of the integer 12345, while 234 is not.
# A common prefix of two integers a and b is an integer c, such that c is a prefix of both a and b. For example, 5655359 and 56554 have common prefixes 565 and 5655 while 1223 and 43456 do not have a common prefix.
# You need to find the length of the longest common prefix between all pairs of integers (x, y) such that x belongs to arr1 and y belongs to arr2.
# Return the length of the longest common prefix among all pairs. If no common prefix exists among them, return 0.

from typing import List
class TrieNode:
    def __init__(self):
        self.children = [None] * 10

class Trie:
    def __init__(self):
        self.root = TrieNode()

    def insert(self, num):
        node = self.root
        s = str(num)
        for c in s:
            d = int(c)
            if not node.children[d]:
                node.children[d] = TrieNode()
            node = node.children[d]

    def search(self, num: int) -> int:
        node = self.root
        s = str(num)
        len = 0
        for c in s:
            d = int(c)
            if not node.children[d]:
                break
            node = node.children[d]
            len += 1
        return len

class Solution:
    def longestCommonPrefix(self, arr1: List[int], arr2: List[int]) -> int:
        trie = Trie()
        for arr in arr1:
            trie.insert(arr)
        longest = 0
        for a2 in arr2:
            len = trie.search(a2)
            longest = max(longest, len)
        return longest
    
#############

from typing import List
class Solution:
    def longestCommonPrefix(self, arr1: List[int], arr2: List[int]) -> int:
        def len_int(n: int) -> int:
            len = 0
            while n != 0:
                n = n // 10
                len += 1
            return len
        s = {}
        for arr in arr1:
            n = arr
            while n != 0:
                s[n] = len_int(n)
                n = n // 10
        longest = 0
        for sarray in arr2:
            m = sarray
            while m != 0:
                if m in s:
                    # found the longest common prefix for this int
                    longest = max(longest, s[m])
                    break
                m = m // 10
        return longest