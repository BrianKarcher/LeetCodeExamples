# Given an m x n integer matrix heightMap representing the height of each unit cell in a 2D elevation map, return the volume of water it can trap after raining.

class Solution:
    def trapRainWater(self, heightMap: List[List[int]]) -> int:
        rows = len(heightMap)
        cols = len(heightMap[0])
        if rows < 3 or cols < 3:
            return 0
        
        heap = []
        # record the boundaries in all four matrixes
        visited = set()
        for c in range(cols):
            heapq.heappush(heap, (heightMap[0][c], 0, c))
            visited.add((0, c))
            heapq.heappush(heap, (heightMap[rows - 1][c], rows - 1, c))
            visited.add((rows - 1, c))

        for r in range(rows):
            heapq.heappush(heap, (heightMap[r][0], r, 0))
            visited.add((r, 0))
            heapq.heappush(heap, (heightMap[r][cols - 1], r, cols - 1))
            visited.add((r, cols - 1))

        ans = 0
        dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)]

        while len(heap) != 0:
            val, irow, icol = heapq.heappop(heap)
            #print(f'{len(heap)}')
            for dir in dirs:
                #print(f'{irow}, {icol}')
                row = irow + dir[0]
                col = icol + dir[1]
                #print(f'{row}, {col}')
                if (row <= 0 or row >= rows - 1 or col <= 0 or col >= cols - 1 or (row, col) in visited):
                    continue
                if val > heightMap[row][col]:
                    ans += val - heightMap[row][col]
                heapq.heappush(heap, (max(val, heightMap[row][col]), row, col))
                visited.add((row, col))

        return ans


class Solution:
    def trapRainWater(self, heightMap: List[List[int]]) -> int:
        rows = len(heightMap)
        cols = len(heightMap[0])
        toRight = [[0 for x in range(cols)] for y in range(rows)]
        toLeft = [[0 for x in range(cols)] for y in range(rows)]
        toDown = [[0 for x in range(cols)] for y in range(rows)]
        toUp = [[0 for x in range(cols)] for y in range(rows)]

        # record the boundaries in all four matrixes
        for c in range(cols):
            toUp[0][c] = toDown[0][c] = toLeft[0][c] = toRight[0][c] = heightMap[0][c]
            toUp[rows - 1][c] = toDown[rows - 1][c] = toLeft[rows - 1][c] = toRight[rows - 1][c] = heightMap[rows - 1][c]

        for r in range(rows):
            toUp[r][0] = toDown[r][0] = toLeft[r][0] = toRight[r][0] = heightMap[r][0]
            toUp[r][cols - 1] = toDown[r][cols - 1] = toLeft[r][cols - 1] = toRight[r][cols - 1] = heightMap[r][cols - 1]

        # swipe right
        for c in range(1, cols):
            for r in range(0, rows):
                toRight[r][c] = max(toRight[r][c - 1], heightMap[r][c])

        # swipe left
        for c in range(cols - 2, -1, -1):
            for r in range(0, rows):
                toLeft[r][c] = max(toLeft[r][c + 1], heightMap[r][c])

        # swipe down
        for r in range(1, rows):
            for c in range(0, cols):
                toDown[r][c] = max(toDown[r - 1][c], heightMap[r][c])

        # swipe up 
        for r in range(rows - 2, -1, -1):
            for c in range(0, cols):
                toUp[r][c] = max(toUp[r + 1][c], heightMap[r][c])

        # counts
        cnt = 0
        for c in range(1, cols - 1):
            for r in range(1, rows - 1):
                cnt += min(toRight[r][c], toLeft[r][c], toDown[r][c], toUp[r][c]) - heightMap[r][c]
        return cnt