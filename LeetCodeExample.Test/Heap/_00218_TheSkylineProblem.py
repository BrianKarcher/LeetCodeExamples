# A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. Given the locations and heights of all the buildings, return the skyline formed by these buildings collectively.

# The geometric information of each building is given in the array buildings where buildings[i] = [lefti, righti, heighti]:

# lefti is the x coordinate of the left edge of the ith building.
# righti is the x coordinate of the right edge of the ith building.
# heighti is the height of the ith building.
# You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.

# The skyline should be represented as a list of "key points" sorted by their x-coordinate in the form [[x1,y1],[x2,y2],...]. Each key point is the left endpoint of some horizontal segment in the skyline except the last point in the list, which always has a y-coordinate 0 and is used to mark the skyline's termination where the rightmost building ends. Any ground between the leftmost and rightmost buildings should be part of the skyline's contour.

# Note: There must be no consecutive horizontal lines of equal height in the output skyline. For instance, [...,[2 3],[4 5],[7 5],[11 5],[12 7],...] is not acceptable; the three lines of height 5 should be merged into one in the final output as such: [...,[2 3],[4 5],[12 7],...]

class Solution:
    def getSkyline(self, buildings: List[List[int]]) -> List[List[int]]:
        rtn = []
        currentHeight = 0
        # currentX = 0
        pq = []
        for building in buildings:
            # The tallest building can be popped if the current building's x > top building's y
            while len(pq) > 0 and pq[0][2] < building[0]:
                tallest = heapq.heappop(pq)
                # remove occluded buildings (an example is the blue building in example 1)
                while len(pq) > 0 and pq[0][2] < tallest[2]:
                    heapq.heappop(pq)
                #height = -tallest[0]
                #if height != currentHeight:
                # currentHeight resets to the next tallest building, if there is one
                if len(pq) > 0:
                    currentHeight = -pq[0][0]
                else:
                    currentHeight = 0
                # currentHeight = height
                # currentX = tallest[2]
                rtn.append([tallest[2], currentHeight])

            heapq.heappush(pq, (-building[2], building[0], building[1]))

        # if new building increases the height, add the x coord
        if building[2] > currentHeight:
            currentHeight = building[2]
            # currentX = building[0]
            print(f'appending {building[0]}')
            rtn.append([building[0], currentHeight])

        print('Flushing')
        while len(pq) > 0 and pq[0][2] < building[0]:
            tallest = heapq.heappop(pq)
            # remove occluded buildings (an example is the blue building in example 1)
            while len(pq) > 0 and pq[0][2] < tallest[2]:
                heapq.heappop(pq)
            #height = -tallest[0]
            #if height != currentHeight:
            # currentHeight resets to the next tallest building, if there is one
            if len(pq) > 0:
                currentHeight = -pq[0][0]
            else:
                currentHeight = 0
            # currentHeight = height
            # currentX = tallest[2]
            print(f'appending {tallest[2]}')
            rtn.append([tallest[2], currentHeight])

        return rtn