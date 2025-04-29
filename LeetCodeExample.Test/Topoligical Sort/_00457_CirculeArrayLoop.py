from typing import List
class Solution:
    def circularArrayLoop(self, nums: List[int]) -> bool:
        # confirmed non-cycle
        BLACK = 0
        # checking
        GRAY = 1
        # not checked
        WHITE = 2

        # Remove excess loops via modulus
        for i in range(len(nums)):
            if nums[i] < 0:
                # Python handles negative numbers in % not how we expect, so convert to positive
                nums[i] = ((nums[i] * -1) % len(nums)) * -1
            else:
                nums[i] = nums[i] % len(nums)

        def dfs(i, count):
            if self.isCycle:
                return
            if colors[i] == BLACK:
                return
            # opposite direction check
            if self.isPositive and nums[i] < 0:
                return
            if not self.isPositive and nums[i] > 0:
                return
            next = i + nums[i]
            # math is failing me....
            # convert next to the next positive index
            if next > len(nums) - 1:
                next = next - len(nums)
            elif next < 0:
                next = len(nums) + next
            
            # cycle on self is ok but don't infinite loop
            if next == i:
                # if count > 2:
                #     self.isCycle = True
                return
            
            # cycle check
            if colors[i] == GRAY:
                self.isCycle = True
                return

            colors[i] = GRAY

            # go deep first
            dfs(next, count + 1)
            colors[i] = BLACK

        colors = [WHITE] * len(nums)
        self.isCycle = False
        # self.isPositive = True

        for i in range(len(nums)):
            self.isPositive = nums[i] > 0
            dfs(i, 1)
        
        # colors = [WHITE] * len(nums)
        # self.isPossible = True
        # self.isPositive = False

        # for i in range(len(nums)):
        #     dfs(i)
        #     if not self.isPossible:
        #         return False

        return self.isCycle
    
solution = Solution()
rtn = solution.circularArrayLoop([-1,-1,-3])
print(rtn)