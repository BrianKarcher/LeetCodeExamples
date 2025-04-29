# You are given n points in the plane that are all distinct, where points[i] = [xi, yi]. A boomerang is a tuple of points (i, j, k) such that the distance between i and j equals the distance between i and k (the order of the tuple matters).

# Return the number of boomerangs.

class Solution:
    def numberOfBoomerangs(self, points: List[List[int]]) -> int:
        if len(points) <= 1:
            return 0
        count = 0

        for i in range(len(points)):
            distances = defaultdict(int)
            point = points[i]
            for j in range(len(points)):
                if i == j:
                    continue
                point2 = points[j]
                distanceSq = (point[0] - point2[0]) ** 2 + (point[1] - point2[1]) ** 2
                #print(f'({i}, {j})distanceSq: {distanceSq}')
                distances[distanceSq] += 1
            for k, v in distances.items():
                if v > 1:
                    count += v * (v - 1)
        
        return count