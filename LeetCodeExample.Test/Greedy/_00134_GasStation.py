# There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].
# You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. You begin the journey with an empty tank at one of the gas stations.
# Given two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1. If there exists a solution, it is guaranteed to be unique.

from typing import List
class Solution:
    def canCompleteCircuit(self, gas: List[int], cost: List[int]) -> int:
        if sum(gas) < sum(cost):
            return -1
        l = 0
        ans = 0
        for r in range(len(gas)):
            ans += gas[r] - cost[r]
            if ans < 0:
                ans = 0
                l = r + 1
        return l

##############

from typing import List
class Solution:
    def canCompleteCircuit(self, gas: List[int], cost: List[int]) -> int:
        sums = [0] * len(gas)
        sums[0] = gas[0] - cost[-1]
        for i in range(1, len(gas)):
            sums[i] = sums[i - 1] + gas[i] - cost[i - 1]
        print(f'{sums}')
        # Impossible to complete circuit
        if sums[-1] < 0:
            return -1
        # Find fist prefix sum where the number never gets lower than that value, and > 0
        l = 0
        while sums[l] < 0:
            l += 1
        for r in range(l + 1, len(gas)):
            # If we ever dip into the negative, we have run out of gas - inc l pointer to r
            if sums[r] < sums[l]:
                l = r + 1
        return l