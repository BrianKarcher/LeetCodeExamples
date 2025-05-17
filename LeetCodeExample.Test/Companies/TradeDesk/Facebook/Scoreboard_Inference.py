# Scoreboard Inference (Chapter 1)

# Note: Chapter 2 is a harder version of this puzzle. The only difference is a larger set of possible problem point values.
# You are spectating a programming contest with 
# N
# N competitors, each trying to independently solve the same set of programming problems. Each problem has a point value, which is either 1 or 2.
# On the scoreboard, you observe that the 
# ith competitor has attained a score of Si
# , which is a positive integer equal to the sum of the point values of all the problems they have solved.
# The scoreboard does not display the number of problems in the contest, nor their point values. Using the information available, you would like to determine the minimum possible number of problems in the contest.
# Constraints

# 1 <= N <= 500,000
# 1 <= Si <= 1,000,000,000

# Greedy Algorithm
# O(n)

from typing import List
# Write any import statements here

def getMinProblemCount(N: int, S: List[int]) -> int:
  # Write your code here
  has_odd = False
  has_even = False
  s_max = 0
  for i in range(N):
    s_max = max(s_max, S[i])
    if S[i] % 2 == 0:
      has_even = True
    else:
      has_odd = True
  
  ans = 0
  if has_odd != has_even:
    # When in parity, return the max // 2
    ans = s_max // 2
  else:
    # When not in parity, we need an extra problem with a "1" value to offset
    ans = (s_max // 2) + 1
    
  return ans