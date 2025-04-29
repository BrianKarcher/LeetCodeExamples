class Solution:
    def getMaximumXor(self, nums: List[int], maximumBit: int) -> List[int]:
        fxor = 0
        ones = 0
        for i in range(maximumBit):
            ones = ones << 1
            ones = ones | 1
            # print(ones)

        # print(f'ones = {ones}')
        
        for i in range(len(nums)):
            fxor ^= nums[i]
        
        # print(f'fxor = {fxor}')
        ans = []
        for i in range(len(nums) - 1, -1, -1):
            ans.append(fxor ^ ones)
            fxor ^= nums[i]
        
        return ans