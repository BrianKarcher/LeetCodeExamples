from typing import List
import sys
class Solution:
    def findShortestSubArray(self, nums: List[int]) -> int:
        left, right, count = {}, {}, {}
        maxDegree = 0
        for i, x in enumerate(nums):
            if x not in left:
                left[x] = i
            right[x] = i
            count[x] = count.get(x, 0) + 1
            maxDegree = max(maxDegree, count[x])
        
        #print(f"maxDegree {maxDegree}")
        minLength = sys.maxsize
        for x in count:
            if count[x] == maxDegree:
                minLength = min(minLength, right[x] - left[x] + 1)

        return minLength
    

class Solution2:
    def findShortestSubArray(self, nums: List[int]) -> int:
        counts = [0] * 50_000
        first = [-1] * 50_000
        last = [-1] * 50_000
        maxDegree = 0
        for i in range(0, len(nums)):
            num = nums[i]
            counts[num] += 1
            maxDegree = max(maxDegree, counts[num])
            if first[num] == -1:
                first[num] = i
                last[num] = i
            else:
                last[num] = i
        
        print(f"maxDegree {maxDegree}")
        minLength = sys.maxsize
        for i in range(0, 50_000):
            if counts[i] == maxDegree:
                minLength = min(minLength, last[i] - first[i] + 1)

        return minLength

sol = Solution()
print(sol.findShortestSubArray([1,2,2,3,1]))