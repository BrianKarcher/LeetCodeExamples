# You are given an m x n matrix maze (0-indexed) with empty cells (represented as '.') and walls (represented as '+'). You are also given the entrance of the maze, where entrance = [entrancerow, entrancecol] denotes the row and column of the cell you are initially standing at.

# In one step, you can move one cell up, down, left, or right. You cannot step into a cell with a wall, and you cannot step outside the maze. Your goal is to find the nearest exit from the entrance. An exit is defined as an empty cell that is at the border of the maze. The entrance does not count as an exit.

# Return the number of steps in the shortest path from the entrance to the nearest exit, or -1 if no such path exists.

# My solution
from typing import List
from collections import deque
class Solution:
    def nearestExit(self, maze: List[List[str]], entrance: List[int]) -> int:
        visited = set()
        q = deque()
        q.append((entrance[0], entrance[1], 0))
        visited.add((entrance[0], entrance[1]))
        directions = [(1, 0), (-1, 0), (0, 1), (0, -1)]
        while q:
            cell_row, cell_col, distance = q.popleft()
            distance += 1
            for dir in directions:
                new_row, new_col = cell_row + dir[0], cell_col + dir[1]
                # bounds check, mostly used if the starting location is at an edge
                if not (0 <= new_row <= len(maze) - 1 and 0 <= new_col <= len(maze[0]) - 1):
                    continue
                if (new_row, new_col) in visited:
                    continue
                visited.add((new_row, new_col))
                if maze[new_row][new_col] == '+':
                    continue
                # border check, border = exit
                # print(f'{new_row}, {new_col}')
                if new_row == 0 or new_col == 0 or new_row == len(maze) - 1 or new_col == len(maze[0]) - 1:
                    return distance
                q.append((new_row, new_col, distance))
        return -1