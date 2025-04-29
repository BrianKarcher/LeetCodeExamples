# Design an iterator that supports the peek operation on an existing iterator in addition to the hasNext and the next operations.

# Implement the PeekingIterator class:

# PeekingIterator(Iterator<int> nums) Initializes the object with the given integer iterator iterator.
# int next() Returns the next element in the array and moves the pointer to the next element.
# boolean hasNext() Returns true if there are still elements in the array.
# int peek() Returns the next element in the array without moving the pointer.
# Note: Each language may have a different implementation of the constructor and Iterator, but they all support the int next() and boolean hasNext() functions.

# Below is the interface for Iterator, which is already defined for you.
#
# class Iterator:
#     def __init__(self, nums):
#         """
#         Initializes an iterator object to the beginning of a list.
#         :type nums: List[int]
#         """
#
#     def hasNext(self):
#         """
#         Returns true if the iteration has more elements.
#         :rtype: bool
#         """
#
#     def next(self):
#         """
#         Returns the next element in the iteration.
#         :rtype: int
#         """

class PeekingIterator:
    def __init__(self, iterator):
        self.iterator = iterator
        self.cache = None
        # We always stay one element ahead of the iterator
        if self.iterator.hasNext:
            self.cache =  self.iterator.next()
        """
        Initialize your data structure here.
        :type iterator: Iterator
        """
        

    def peek(self):
        return self.cache
        """
        Returns the next element in the iteration without advancing the iterator.
        :rtype: int
        """
        

    def next(self):
        temp = self.cache
        if self.iterator.hasNext():
            self.cache = self.iterator.next()
        else:
            self.cache = None
        return temp
        """
        :rtype: int
        """
        

    def hasNext(self):
        return self.cache != None
        """
        :rtype: bool
        """
        

# Your PeekingIterator object will be instantiated and called as such:
# iter = PeekingIterator(Iterator(nums))
# while iter.hasNext():
#     val = iter.peek()   # Get the next element but not advance the iterator.
#     iter.next()         # Should return the same value as [val].