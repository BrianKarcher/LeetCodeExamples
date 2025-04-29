# Given a reference of a node in a connected undirected graph.
# Return a deep copy (clone) of the graph.
# Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

"""
# Definition for a Node.
class Node:
    def __init__(self, val = 0, neighbors = None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []
"""

from typing import Optional
class Solution:
    def cloneGraph(self, node: Optional['Node']) -> Optional['Node']:
        if not node:
            return None
        # Dictionary prevents duplicates
        map = {}

        def rec(node: Optional[Node]) -> Optional[Node]:
            if not node:
                return None
            if node.val in map:
                return map[node.val]

            # Clone this node
            cloneNode = Node(node.val)
            map[node.val] = cloneNode
            for neighbor in node.neighbors:
                cloneNode.neighbors.append(rec(neighbor))
            return cloneNode
        
        return rec(node)