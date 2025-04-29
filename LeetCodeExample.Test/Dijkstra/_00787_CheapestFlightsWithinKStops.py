# There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.
# You are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1.

# This question is interesting because there are two weights. Price and # of hops. The optimal path may be to enter a city with a higher price but lower hops
# If that hop count is what is needed to reach the destination.

import heapq
from typing import List
class Solution:
    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:
        adjList = {dst : [] for dst in range(n)}
        for (fromLoc, toLoc, price) in flights:
            adjList[fromLoc].append((toLoc, price))
        # print(adjList)
        # k += 1 # Add the destination stop
        cities = {item : (float('inf'), float('inf')) for item in range(n)} # price, hops
        cities[src] = (0, 0)
        heap = []
        heapq.heappush(heap, (0, src, 0))
        #count = 0
        while heap: # and heap[0][0] < cities[dst][0]:
            #if count < 100:
            #    print(heap)
            (price, loc, hops) = heapq.heappop(heap)
            # print(f'loc: {loc}, price: {price}')
            if loc == dst:
                return price
            if price > cities[loc][0] and hops > cities[loc][1]:
                continue
            if loc not in adjList:
                continue
            if hops > k:
                    # print(f'{to_loc} Too many hops {hops}')
                    continue
            for (to_loc, flight_price) in adjList[loc]:
                new_price = price + flight_price
                #if count < 100:
                #    print(f'loc: {to_loc}, price: {new_price}')
                
                if new_price >= cities[to_loc][0] and hops > cities[to_loc][1]:
                    continue
                cities[to_loc] = (new_price, hops)
                # Don't add to heap if too many hops
                # print(f'hops: {hops}, k: {k}')
                
                # print(f'Pushing {to_loc}, {new_price}')
                heapq.heappush(heap, (new_price, to_loc, hops + 1))
            #count += 1
        return -1
    

# TLE

from typing import List
class Solution:
    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:
        adjList = {}
        for (source, dest, price) in flights:
            if source not in adjList:
                adjList[source] = []
            adjList[source].append((dest, price)) # dest, price
        
        
        # Dijkstra's Algorithm
        # Current best score of each location
        cities = {}
        for i in range(n):
            cities[i] = (float('inf'), float('inf'))
        
        cities[src] = (0, 0) # price, hops

        def dfs(city, price, hop):
            # print(f'{city} {price} {hop}')
            if hop > k + 1:
                return
            # print(1)
            # return if we have already visited this city with a better price and hop
            if price > cities[city][0] and hop > cities[city][1]:
                return
            # print(2)
            if price < cities[city][0]:
                cities[city] = (price, hop)
            # print(f'city: {city}')
            if city not in adjList:
                return
            # print(3)
            for (dest, newPrice) in adjList[city]:
                dfs(dest, price + newPrice, hop + 1)
        
        dfs(src, 0, 0)
        # print('done')
        # print(cities)
        return -1 if cities[dst][0] == float('inf') else cities[dst][0]