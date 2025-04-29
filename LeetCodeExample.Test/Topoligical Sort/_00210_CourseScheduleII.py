# There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

# For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
# Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

from typing import List
from collections import defaultdict
class Solution:
    def __init__(self):
        self.seen = []
        self.visited = []
        self.adjList = defaultdict(list)

    def rec(self, idx: int, lst: list) -> bool:
        if self.visited[idx]:
            return False
        if self.seen[idx]:
            return True
        self.seen[idx] = True
        self.visited[idx] = True
        for i in self.adjList[idx]:
            if not self.rec(i, lst):
                return False
        self.visited[idx] = False
        lst.append(idx)
        return True

    def findOrder(self, numCourses: int, prerequisites: List[List[int]]) -> List[int]:
        for preq in prerequisites:
            self.adjList[preq[0]].append(preq[1])
        
        self.seen = [False] * numCourses
        ans = []
        for i in range(numCourses):
            self.visited = [False] * numCourses
            if not self.rec(i, ans):
                return []
        # ans.reverse()
        return ans