# You are given row x col grid representing a map where grid[i][j] = 1 represents land and grid[i][j] = 0 represents water.

# Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).

# The island doesn't have "lakes", meaning the water inside isn't connected to the water around the island. One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.



class Solution:
    def islandPerimeter(self, grid: List[List[int]]) -> int:
        count = 0
        dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)]
        for r in range(len(grid)):
            for c in range(len(grid[0])):
                if grid[r][c] == 0:
                    #print(f'Skipping {r},{c}')
                    continue
                for d in dirs:
                    y = r + d[1]
                    x = c + d[0]
                    if x < 0 or y < 0 or y >= len(grid) or x >= len(grid[0]):
                        #print(f'incrementing count {r},{c} {y}, {x}')
                        count += 1
                    elif grid[y][x] == 0:
                        #print(f'incrementing count {r},{c} {y}, {x}')
                        count += 1
        return count