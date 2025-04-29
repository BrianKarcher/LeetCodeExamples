# There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

# For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
# Return true if you can finish all courses. Otherwise, return false.

class Solution:
    def dfs(self, node, adj, visit, inStack):
        # If the node is already in the stack, we have a cycle.
        if inStack[node]:
            return True
        if visit[node]:
            return False
        # Mark the current node as visited and part of current recursion stack.
        visit[node] = True
        inStack[node] = True
        for neighbor in adj[node]:
            if self.dfs(neighbor, adj, visit, inStack):
                return True
        # Remove the node from the stack.
        inStack[node] = False
        return False

    def canFinish(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        adj = [[] for _ in range(numCourses)]
        for prerequisite in prerequisites:
            adj[prerequisite[1]].append(prerequisite[0])

        visit = [False] * numCourses
        inStack = [False] * numCourses
        for i in range(numCourses):
            if self.dfs(i, adj, visit, inStack):
                return False
        return True


##################




from typing import List
class Solution:
    def canFinish(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        adjList = {}
        for preq in prerequisites:
            if preq[0] not in adjList:
                adjList[preq[0]] = set()
            adjList[preq[0]].add(preq[1])
        # print(f'adjList: {adjList}')
        BLACK = 0
        GRAY = 1
        WHITE = 2
        COLORS = [WHITE] * numCourses
        self.ans = True
        def topSort(idx: int):
            if not self.ans:
                return
            # print(f'idx: {idx}')
            if COLORS[idx] == BLACK:
                return
            if COLORS[idx] == GRAY:
                self.ans = False
                return
            COLORS[idx] = GRAY
            if idx in adjList:
                for val in adjList[idx]:
                    topSort(val)
            COLORS[idx] = BLACK
        
        for i in range(numCourses):
            if COLORS[i] == WHITE:
                topSort(i)
                if not self.ans:
                    return False
        return True