# There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, and city b is connected directly with city c, then city a is connected indirectly with city c.

# A province is a group of directly or indirectly connected cities and no other cities outside of the group.

# You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, and isConnected[i][j] = 0 otherwise.

# Return the total number of provinces.

from typing import List

# Corrected via reference to my answer # 305
from typing import List

class UnionFind:
    def __init__(self, n):
        self.rank = [0] * n
        self.parent = [i for i in range(n)]
        self.count = n
        # I forgot how to keep track of group counts quickly
        # self.distinct_count = n

    def find(self, idx: int) -> int:
        # Collapse the tree to make joins O(1)
        if self.parent[idx] != idx:
            self.parent[idx] = self.find(self.parent[idx])
        return self.parent[idx]

    def union(self, a, b):
        roota = self.find(a)
        rootb = self.find(b)
        # smaller joins with the bigger, it's faster
        if (roota != rootb):
            if self.rank[a] < self.rank[b]:
                self.parent[roota] = rootb
            elif self.rank[b] < self.rank[a]:
                self.parent[rootb] = roota
            else:
                self.parent[rootb] = roota
                self.rank[roota] += 1
            self.count -= 1

class Solution:
    def findCircleNum(self, isConnected: List[List[int]]) -> int:
        union = UnionFind(len(isConnected))
        for i in range(len(isConnected)):
            for j in range(i + 1, len(isConnected)):
                if (isConnected[i][j]):
                    union.union(i, j)

        # print(union.parent)
        return union.count
    

########################

# Saving for posterity. This fails on test case # 76.
class UnionFind:
    def __init__(self, n):
        self.rank = [0] * n
        self.parent = [i for i in range(n)]
        # I forgot how to keep track of group counts quickly
        # self.distinct_count = n

    def find(self, idx: int) -> int:
        if self.parent[idx] == idx:
            return idx
        # Collapse the tree to make joins O(1)
        self.parent[idx] = self.find(self.parent[idx])
        return self.parent[idx]

    def join(self, a, b):
        # if parent[a]
        # smaller joins with the bigger, it's faster
        if self.rank[a] < self.rank[b]:
            parent_a = self.find(a)
            parent_b = self.find(b)
            self.parent[parent_a] = parent_b
            self.rank[b] += 1
        else:
            parent_a = self.find(a)
            parent_b = self.find(b)
            self.parent[parent_b] = parent_a
            self.rank[a] += 1

class Solution:
    def findCircleNum(self, isConnected: List[List[int]]) -> int:
        union = UnionFind(len(isConnected))
        for i in range(len(isConnected)):
            for j in range(i + 1, len(isConnected)):
                if (isConnected[i][j]):
                    union.join(i, j)
        hash = set()
        print(union.parent)
        for i in range(len(isConnected)):
            hash.add(union.parent[i])
        return len(hash)