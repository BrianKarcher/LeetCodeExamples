# Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.

class Solution:
    def generateMatrix(self, n: int) -> List[List[int]]:
        mat = [[0 for x in range(n)] for y in range(n)]
        dir = ((1, 0), (0, 1), (-1, 0), (0, -1))
        bu = 0
        bl = 0
        br = n - 1
        bd = n - 1
        curdir = 0
        curpos = (0, 0)
        for c in range(n * n):
            mat[curpos[1]][curpos[0]] = c + 1
            if curdir == 0 and curpos[0] == br:
                #print("turning down")
                curdir += 1
                bu += 1
            elif curdir == 1 and curpos[1] == bd:
                #print("turning left")
                curdir += 1
                br -= 1
            elif curdir == 2 and curpos[0] == bl:
                #print("turning up")
                curdir += 1
                bd -= 1
            elif curdir == 3 and curpos[1] == bu:
                #print("turning right")
                curdir = 0
                bl += 1
            #print(f"dir {dir[curdir]}")
            curpos = (curpos[0] + dir[curdir][0], curpos[1] + dir[curdir][1])
            #print(f"pos {curpos}")
        return mat