# 739

# Given an array of integers temperatures represents the daily temperatures,
# return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.

# Optimal
class Solution:
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        n = len(temperatures)
        hottest = 0
        answer = [0] * n
        
        for curr_day in range(n - 1, -1, -1):
            current_temp = temperatures[curr_day]
            if current_temp >= hottest:
                hottest = current_temp
                continue
            
            days = 1
            while temperatures[curr_day + days] <= current_temp:
                # Use information from answer to search for the next warmer day
                days += answer[curr_day + days]
            answer[curr_day] = days

        return answer

# My answer
from typing import List
class Solution:
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        # Monotonic decreasing stack
        ans = [0] * len(temperatures)
        # Stack will be a tuple of (value, index)
        stack = []
        # The stack is always decreasing. So whenver we see a higher number,
        # Pop items off the stack as needed and update their answer.
        for i in range(len(temperatures)):
            temp = temperatures[i]
            # Check stack, pop all as needed
            while stack and stack[-1][0] < temp:
                pop = stack.pop()
                ans[pop[1]] = i - pop[1]
            stack.append((temp, i))

        return ans