from typing import List
class TrieNode:
    def __init__(self, char: str):
        self.chars = {}
        self.char = char
        self.count = 1 # How many words are on this node. For pruning
        self.isWord = False

class Solution:
    root = TrieNode('')
    ans = []
    height = 0
    width = 0

    def __init__(self) -> None:
        self.root = TrieNode('')
        self.ans = []

    def findWords(self, board: List[List[str]], words: List[str]) -> List[str]:
        for word in words:
            self.addWordToTrie(word)

        self.height = len(board)
        self.width = len(board[0])
        #print(f'board width: {self.width}, height: {self.height}')
        # Traverse the grid
        for r in range(self.height):
            for c in range(self.width):
                #print(f'Trie root chars: {self.root.chars}')
                if board[r][c] in self.root.chars:
                    self.searchBoardForWordsRecurse(board, r, c, self.root, '', set())
                    # This is a possible start of a word.
                #print('hi')

        return self.ans

    def searchBoardForWordsRecurse(self, board: List[List[str]], r, c, node: TrieNode, word: str, seen: set):
        # Bounds check.
        #print(f'Checking row {r} col {c}')
        if r < 0 or r >= self.height or c < 0 or c >= self.width: return
        if (r, c) in seen: return
        #print(f'Cell not yet seen')
        letter = board[r][c]
        #print(f'cell: {char}')
        if letter not in node.chars: return
        seen.add((r, c))
        child = node.chars[letter]
        #print(f'checking child {child.char}')
        newWord = word + child.char
        if child.isWord:
            self.ans.append(newWord)
            child.isWord = False
        for (rowOffset, colOffset) in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            self.searchBoardForWordsRecurse(board, r + rowOffset, c + colOffset, child, newWord, seen)
        # Backtrack because this cell can be reached from a different direction
        seen.remove((r, c))
        # Optimization: incrementally remove the matched leaf node in Trie.
        if not child.chars:
            node.chars.pop(letter)

    def addWordToTrie(self, word: str):
        node = self.root
        for char in word:
            #print(f'adding char {char}')
            if char not in node.chars:
                child = TrieNode(char)
            else:
                child = node.chars[char]
            child.count += 1
            node.chars[char] = child
            node = child
        #print(f'setting word {word}, node = {node.char}')
        node.isWord = True