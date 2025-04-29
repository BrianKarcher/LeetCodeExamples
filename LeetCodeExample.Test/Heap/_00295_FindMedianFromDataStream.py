# The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value, and the median is the mean of the two middle values.

# For example, for arr = [2,3,4], the median is 3.
# For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
# Implement the MedianFinder class:

# MedianFinder() initializes the MedianFinder object.
# void addNum(int num) adds the integer num from the data stream to the data structure.
# double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.

class MedianFinder:

    def __init__(self):
        # min heap
        self.hi = []
        # max heap
        self.lo = []

    def addNum(self, num: int) -> None:
        heapq.heappush(self.lo, -num)
        pop = -heapq.heappop(self.lo)
        # Balance
        heapq.heappush(self.hi, pop)
        # Keep the heaps balanced
        if len(self.lo) < len(self.hi):
            # Keep lo equal to or larger than hi
            popped = heapq.heappop(self.hi)
            heapq.heappush(self.lo, -popped)

    def findMedian(self) -> float:
        if len(self.lo) > len(self.hi):
            return -self.lo[0]
        else:
            return (-self.lo[0] + self.hi[0]) / 2