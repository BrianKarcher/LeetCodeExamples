# You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.
# Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

from typing import List
class Solution:
    def canPlaceFlowers(self, flowerbed: List[int], n: int) -> bool:
        if n == 0:
            return True
        i = 0
        while i < len(flowerbed):
            if flowerbed[i] == 1:
                i += 1
                continue
            left = 0 if i == 0 else flowerbed[i - 1]
            right = 0 if i == len(flowerbed) - 1 else flowerbed[i + 1]
            if not left and not right:
                flowerbed[i] = 1
                n -= 1
                if n == 0:
                    return True
                i += 2 # Cannot place flowers next to each other, can increment i by 2
            else:
                i += 1
        return False