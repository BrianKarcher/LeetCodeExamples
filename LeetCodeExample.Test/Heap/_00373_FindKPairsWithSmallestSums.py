# You are given two integer arrays nums1 and nums2 sorted in non-decreasing order and an integer k.

# Define a pair (u, v) which consists of one element from the first array and one element from the second array.

# Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sum

from typing import List
#from collections import heapq
class Solution:
    def kSmallestPairs(self, nums1: List[int], nums2: List[int], k: int) -> List[List[int]]:
        pq = []
        #pq.append((nums1[0] + nums2[0], 0, 0))
        heapq.heappush(pq, (nums1[0] + nums2[0], 0, 0))
        #print(f'Adding {0}, {0}, {nums1[0] + nums2[0]}')
        rtn = list()
        seen = set()
        while pq and len(rtn) < k:
            item = heapq.heappop(pq)
            #print(f'Popped {item}')
            rtn.append([nums1[item[1]], nums2[item[2]]])
            if item[1] < len(nums1) - 1:
                if (not (item[1] + 1, item[2]) in seen):
                    seen.add((item[1] + 1, item[2]))
                    #print(f'Adding {item[1] + 1}, {item[2]}, {nums1[item[1] + 1] + nums2[item[2]]}')
                    #pq.append((nums1[item[1] + 1] + nums2[item[2]], item[1] + 1, item[2]))
                    heapq.heappush(pq, (nums1[item[1] + 1] + nums2[item[2]], item[1] + 1, item[2]))
            if item[2] < len(nums2) - 1:
                if (not (item[1], item[2] + 1) in seen):
                    seen.add((item[1], item[2] + 1))
                    #print(f'Adding {item[1]}, {item[2] + 1}, {nums1[item[1]] + nums2[item[2] + 1]}')
                    #pq.append((nums1[item[1]] + nums2[item[2] + 1], item[1], item[2] + 1))
                    heapq.heappush(pq, (nums1[item[1]] + nums2[item[2] + 1], item[1], item[2] + 1))
            #print(pq)
        return rtn

# 2 pointer doesn't work

from typing import List
class Solution:
    def kSmallestPairs(self, nums1: List[int], nums2: List[int], k: int) -> List[List[int]]:
        ans = list()
        i1, i2 = 0, 0
        ans.append([nums1[0], nums2[0]])
        for i in range(k - 1):
            # figure out which pointer to increment to give us the smallest increasing sum
            if i1 == len(nums1):
                i2 += 1
            elif i2 == len(nums2):
                i1 += 1
            elif nums2[i2] + nums1[i1 + 1] > nums1[i1] + nums2[i2 + 1]:
                print(f'inc 2, {nums2[i2]} + {nums1[i1 + 1]} > {nums1[i1]} + {nums2[i2 + 1]}')
                i2 += 1
            else:
                print(f'inc 1, nums2[i2]={nums2[i2]}, nums1[i1+1]={nums1[i1+1]}, nums1[i1]={nums1[i1]}, nums2[i2+1]={nums2[i2+1]}')
                i1 += 1
            ans.append([nums1[i1], nums2[i2]])
        return ans