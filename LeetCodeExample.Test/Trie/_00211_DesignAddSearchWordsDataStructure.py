class WordDictionary:

    def __init__(self):
        self.trie = {}

    def addRecurse(self, node, index, word):
        if index == len(word):
            node.setdefault("_end_")
            return
        self.addRecurse(node.setdefault(word[index], {}), index + 1, word)

    def addWord(self, word: str) -> None:
        self.addRecurse(self.trie, 0, word)
        #print(self.trie)

    def search(self, word: str) -> bool:
        return self.getRecurse(self.trie, 0, word)

    def getRecurse(self, node, index, word) -> bool:
        if node is None:
            return False
        if index == len(word):
            rtn = node == None or "_end_" in node
            #print(f"reached end, returning {rtn}")
            return rtn
        c = word[index]
        #print(c)
        #print(node)
        if c == '.':
            #print("dot")
            for ch in node:
                #print(f"checking letter {ch}")
                if self.getRecurse(node[ch], index + 1, word):
                    return True
            return False
        #print("not a dot")
        if c not in node:
            return False
        return self.getRecurse(node[c], index + 1, word)

# Your WordDictionary object will be instantiated and called as such:
# obj = WordDictionary()
# obj.addWord(word)
# param_2 = obj.search(word)