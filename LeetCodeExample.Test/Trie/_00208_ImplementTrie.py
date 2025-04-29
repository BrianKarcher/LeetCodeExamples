# A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

# Implement the Trie class:

# Trie() Initializes the trie object.
# void insert(String word) Inserts the string word into the trie.
# boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
# boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.

class Node:
    def __init__(self):
        self.children = [None] * 26
        self.isWord = False

class Trie:

    def __init__(self):
        self.root = Node()

    def insert(self, word: str) -> None:
        node = self.root
        for c in word:
            index = ord(c) - ord('a')
            if not node.children[index]:
                node.children[index] = Node()
            node = node.children[index]
        node.isWord = True

    def search_prefix(self, word: str) -> Node:
        node = self.root
        for c in word:
            index = ord(c) - ord('a')
            if not node.children[index]:
                return None
            node = node.children[index]
        return node

    def search(self, word: str) -> bool:
        node = self.search_prefix(word)
        return node is not None and node.isWord

    def startsWith(self, prefix: str) -> bool:
        node = self.search_prefix(prefix)
        return node is not None
    
# Alternate (My attempt)
from typing import Optional
from typing import Dict, Any
class Trie:

    def __init__(self):
        self.trie = {}

    def insert(self, word: str) -> None:
        node = self.trie
        for ch in word:
            if ch not in node:
                node[ch] = {}
            node = node[ch]
        # $ marks the end of a word
        # This is simpler than having a separate Node class and a boolean flag
        node['$'] = True

    # Both search and startsWith will call this
    def find(self, word: str) -> Optional[Dict[str, Any]]:
        node = self.trie
        for ch in word:
            if ch not in node:
                return None
            node = node[ch]
        return node

    def search(self, word: str) -> bool:
        node = self.find(word)
        return node is not None and '$' in node

    def startsWith(self, prefix: str) -> bool:
        node = self.find(prefix)
        return node is not None


# Your Trie object will be instantiated and called as such:
# obj = Trie()
# obj.insert(word)
# param_2 = obj.search(word)
# param_3 = obj.startsWith(prefix)