# This only passes 22/31 test cases.

# This is a lot of lines of code. Maybe a DFS would be better for an interview?!?!?
# This does grid mutation. Ask during interview if that is OK.

from typing import List
# Write any import statements here
from collections import deque
def getSecondsRequired(R: int, C: int, G: List[List[str]]) -> int:
  # Write your code here
  q = deque()
  # Digest starting point and portals
  portals = {}
  for r in range(R):
    for c in range(C):
      if G[r][c] == 'S':
        q.append((r, c, 1))
        G[r][c] = 'V'
      elif 'a' <= G[r][c] <= 'z':
        if G[r][c] not in portals:
          portals[G[r][c]] = []
        portals[G[r][c]].append((r, c))
      
  dirs = [[1, 0], [-1, 0], [0, 1], [0, -1]]
  
  # BFS
  while q:
    count = len(q)
    for i in range(count):
      row, col, ans = q.popleft()
      # If the CURRENT cell is a portal...
      if 'a' <= G[row][col] <= 'z':
        # A portal
        for portal in portals[G[row][col]]:
          portalr, portalc = portal[0], portal[1]
          if portalr == row and portalc == col:
            continue
          # Portals have one extra step
          q.append((portalr, portalc, ans + 1))
        # mark the cell as visited
        G[row][col] = 'V'
        # You can continue walking past a portal's entrance
      for dir in dirs:
        newr, newc = row + dir[0], col + dir[1]
        # bounds check
        if not (0 <= newr < R and 0 <= newc < C):
          continue
        if G[newr][newc] == 'E':
          return ans
        elif G[newr][newc] == '.':
          q.append((newr, newc, ans + 1))
          # mark the cell as visited
          G[newr][newc] = 'V'
        elif 'a' <= G[newr][newc] <= 'z':
          q.append((newr, newc, ans + 1))
          # Don't mark the cell as visited yet
  
  return -1