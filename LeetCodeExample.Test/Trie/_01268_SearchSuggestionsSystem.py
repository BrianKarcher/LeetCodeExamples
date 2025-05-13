# 1268
# You are given an array of strings products and a string searchWord.
# Design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.
# Return a list of lists of the suggested products after each character of searchWord is typed.

from typing import List

# class Solution:
#     def suggestedProducts(self, products: List[str], searchWord: str) -> List[List[str]]:
#         sorted_products = sorted(products)

# Official, translated to Python.

class Trie:
    def __init__(self):
        self.root = self.Node()
    
    class Node:
        def __init__(self):
            self.children = [None] * 26
            self.is_word = False

    def insert(self, word: str):
        node = self.root
        for char in word:
            idx = ord(char) - ord('a')
            if not node.children[idx]:
                node.children[idx] = self.Node()
            node = node.children[idx]
        node.is_word = True # Mark a word

    # DFS to find words with prefix
    def _list_with_prefix(self, node: Node, word: str, lst: list[str]):
        # Base case, speed up with abort mechanism.
        if len(lst) >= 3:
            return
        if node.is_word:
            lst.append(word)
        for letter in range(ord('a'), ord('z') + 1):
            idx = letter - ord('a')
            if node.children[idx]:
                self._list_with_prefix(node.children[idx], word + chr(letter), lst)

    def get_words_starting_with(self, prefix: str) -> list[str]:
        node = self.root
        # First search for the node
        for char in prefix:
            idx = ord(char) - ord('a')
            if not node.children[idx]:
                return []
            node = node.children[idx]
        
        rtn = []
        self._list_with_prefix(node, prefix, rtn)
        return rtn

class Solution:
    def suggestedProducts(self, products: List[str], searchWord: str) -> List[List[str]]:
        self.trie = Trie()

        # Populate trie
        for prod in products:
            self.trie.insert(prod)

        rtn = []
        prefix = ''
        for char in searchWord:
            prefix += char
            rtn.append(self.trie.get_words_starting_with(prefix))
        
        return rtn