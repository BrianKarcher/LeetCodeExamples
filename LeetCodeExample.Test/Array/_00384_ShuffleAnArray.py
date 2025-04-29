# Given an integer array nums, design an algorithm to randomly shuffle the array. All permutations of the array should be equally likely as a result of the shuffling.

# Implement the Solution class:

# Solution(int[] nums) Initializes the object with the integer array nums.
# int[] reset() Resets the array to its original configuration and returns it.
# int[] shuffle() Returns a random shuffling of the array.

class Solution:

    def __init__(self, nums: list[int]):
        self.nums = nums
        self.original = nums[:]

    def reset(self) -> list[int]:
        return self.original

    def shuffle(self) -> list[int]:
        shuffled = self.nums[:]
        for i in range(len(shuffled) - 1, 0, -1):
            j = random.randint(0, i)
            shuffled[i], shuffled[j] = shuffled[j], shuffled[i]
        return shuffled
    
    
class Solution:

    def __init__(self, nums: List[int]):
        self.nums = nums

    def reset(self) -> List[int]:
        return self.nums

    def shuffle(self) -> List[int]:
        nums = list(self.nums)
        random.shuffle(nums)
        return nums

class Solution:

    def __init__(self, nums: List[int]):
        self.nums = nums

    def reset(self) -> List[int]:
        return self.nums

    def shuffle(self) -> List[int]:
        rtn = []
        nums = list(self.nums)
        for i in range(len(nums)):
            rnd = random.randrange(0, len(nums))
            rtn.append(nums[rnd])
            del nums[rnd]
        return rtn