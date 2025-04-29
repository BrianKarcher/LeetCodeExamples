# Given a singly linked list, return a random node's value from the linked list. Each node must have the same probability of being chosen.

# Implement the Solution class:

# Solution(ListNode head) Initializes the object with the head of the singly-linked list head.
# int getRandom() Chooses a node randomly from the list and returns its value. All the nodes of the list should be equally likely to be chosen.

# Definition for singly-linked list.
from typing import Optional
from random import randrange
class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next

class Solution:
    def __init__(self, head: Optional[ListNode]):
        self.head: Optional[ListNode] = head
        current = head
        count = 0
        while current != None:
            count += 1
            current = current.next
        self.count = count

    def getRandom(self) -> int:
        if self.head == None:
            return 0
        count = randrange(self.count)
        current: Optional[ListNode] = self.head
        for i in range(count):
            if current == None:
                continue
            current = current.next
        return current.val if current else 0