# You have a set which contains all positive integers [1, 2, 3, 4, 5, ...].

# Implement the SmallestInfiniteSet class:

# SmallestInfiniteSet() Initializes the SmallestInfiniteSet object to contain all positive integers.
# int popSmallest() Removes and returns the smallest integer contained in the infinite set.
# void addBack(int num) Adds a positive integer num back into the infinite set, if it is not already in the infinite set.

# Official answer - notice how the heap only contains items added back, not the whole 1,000 entries (eek!)
import heapq
class SmallestInfiniteSet:

    def __init__(self):
        self.is_present = set()
        self.current_integer = 1
        # Keep a heap of all integers that get added back
        # Added back means it was called in addBack but is smaller than self.current_integer
        self.added_back = []

    def popSmallest(self) -> int:
        if self.added_back:
            popped = heapq.heappop(self.added_back)
            self.is_present.remove(popped)
            return popped
        result = self.current_integer
        self.current_integer += 1
        return result

    def addBack(self, num: int) -> None:
        if num >= self.current_integer or num in self.is_present:
            return
        heapq.heappush(self.added_back, num)
        self.is_present.add(num)

# Official answer #2
from sortedcontainers import SortedSet

class SmallestInfiniteSet:
    def __init__(self):
        self.added_integers = SortedSet()
        self.current_integer = 1
    def popSmallest(self) -> int:
        # If there are numbers in the sorted-set, 
        # top element is lowest among all the available numbers.
        if len(self.added_integers):
            answer = self.added_integers[0]
            self.added_integers.discard(answer)
        # Otherwise, the smallest number of large positive set 
        # denoted by 'current_integer' is the answer.
        else:
            answer = self.current_integer
            self.current_integer += 1
        return answer
    def addBack(self, num: int) -> None:
        if self.current_integer <= num or num in self.added_integers:
            return
        # We push 'num' in the sorted-set if it isn't already present.
        self.added_integers.add(num)

# My answer
import heapq
class SmallestInfiniteSet:

    def __init__(self):
        # nums in use
        # We use this so we don't store duplicates
        self.hash = set()
        # keep order
        self.heap = []
        for i in range(1, 1001):
            self.hash.add(i)
            heapq.heappush(self.heap, i)

    def popSmallest(self) -> int:
        smallest = heapq.heappop(self.heap)
        self.hash.remove(smallest)
        return smallest

    def addBack(self, num: int) -> None:
        if num in self.hash:
            return
        self.hash.add(num)
        heapq.heappush(self.heap, num)