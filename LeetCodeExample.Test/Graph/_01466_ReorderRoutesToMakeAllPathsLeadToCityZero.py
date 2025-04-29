# There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way to travel between two different cities (this network form a tree). Last year, The ministry of transport decided to orient the roads in one direction because they are too narrow.

# Roads are represented by connections where connections[i] = [ai, bi] represents a road from city ai to city bi.

# This year, there will be a big event in the capital (city 0), and many people want to travel to this city.

# Your task consists of reorienting some roads such that each city can visit the city 0. Return the minimum number of edges changed.

# It's guaranteed that each city can reach city 0 after reorder.'


# This isn't my answer
from typing import List
class Solution:
    def minReorder(self, n: int, connections: List[List[int]]) -> int:
        adjList = {}
        for i in range(n):
            adjList[i] = []
        for connection in connections:
            # Roads going away have a cost
            # Make it bidirectional so we can just start at 0 and reverse roads
            # as we pass
            adjList[connection[0]].append((connection[1], 1))
            adjList[connection[1]].append((connection[0], 0))
        visited = [False] * n

        def dfs(city: int) -> int:
            count = 0
            for otherCity, cost in adjList[city]:
                if visited[otherCity]:
                    continue
                visited[otherCity] = True
                count += cost
                count += dfs(otherCity)
            return count

        visited[0] = True
        return dfs(0)