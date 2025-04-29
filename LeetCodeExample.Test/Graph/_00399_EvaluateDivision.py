# You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.

# You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.

# Return the answers to all queries. If a single answer cannot be determined, return -1.0.

# Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.

# Note: The variables that do not occur in the list of equations are undefined, so the answer cannot be determined for them.

from typing import List
from collections import defaultdict
class Solution:
    def calcEquation(self, equations: List[List[str]], values: List[float], queries: List[List[str]]) -> List[float]:
        adjList = defaultdict(list)
        for i in range(len(equations)):
            adjList[equations[i][0]].append((equations[i][1], values[i]))
            adjList[equations[i][1]].append((equations[i][0], 1 / values[i]))
        
        self.seen = set()
        self.ans = -1
        def rec(cur: str, loc: str, calc: float):
            if cur in self.seen:
                return
            self.seen.add(cur)
            for adj, val in adjList[cur]:
                newVal = val * calc
                if adj == loc:
                    self.ans = newVal
                    return
                rec(adj, loc, newVal)
        
        ans = []
        for query in queries:
            if query[0] not in adjList or query[1] not in adjList:
                ans.append(-1)
            elif query[0] == query[1]:
                ans.append(1)
            else:
                self.ans = -1
                self.seen = set()
                rec(query[0], query[1], 1)
                ans.append(self.ans)
        return ans