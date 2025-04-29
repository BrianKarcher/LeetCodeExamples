# Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

# Implement the LRUCache class:

# LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
# int get(int key) Return the value of the key if the key exists, otherwise return -1.
# void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
# The functions get and put must each run in O(1) average time complexity.

# Note to self: Remmeber to correct both links when removing an item from a DOUBLE linked list.

class Node: # A double linked list
    def __init__(self, key: int, val: int, prev = None, next = None):
        self.key = key
        self.val = val
        self.prev = prev
        self.next = next

    def __str__(self):
        return f'v:{self.val} p:{self.prev.val if self.prev else "None"} n:{self.next.val if self.next else "None"}'

class LRUCache:

    def __init__(self, capacity: int):
        self.capacity = capacity
        self.llHead = Node(0, 0) # A dummy head (oldest items)
        self.llTail = Node(0, 0) # A dummy tail (newest items)
        self.llHead.next = self.llTail
        self.llTail.prev = self.llHead
        self.dict = {} # {key: LinkedList Node}

    def get(self, key: int) -> int:
        # print(f'getting {key}')
        if key in self.dict:
            node = self.dict[key]
            # Remove from current position in LL
            node.prev.next = node.next
            node.next.prev = node.prev
            self.__placeAtTop__(key)
            return self.dict[key].val
        return -1

    def __placeAtTop__(self, key: int):
        node = self.dict[key]
        # Place after head
        node.next = self.llHead.next
        node.prev = self.llHead
        self.llHead.next = node
        # print(f'{node.val}')
        node.next.prev = node

    def put(self, key: int, value: int) -> None:
        # print(f'Putting {key}, {value}')
        # print('LL before put')
        # self.printLL()
        afterHead = self.llHead.next
        if key in self.dict:
            node = self.dict[key]
            # Update existing value
            node.val = value
            # Remove from current position in LL
            node.prev.next = node.next
            node.next.prev = node.prev
            self.__placeAtTop__(key)
            return

        # Insert, if possible
        # Check capacity
        # print(f'{len(self.dict)}, capacity {self.capacity}')
        if len(self.dict) == self.capacity:
            # Remove the least recently used item (next to tail)
            # print(f'Tail before remove: {self.llTail}')
            del self.dict[self.llTail.prev.key]
            self.llTail.prev.prev.next = self.llTail
            self.llTail.prev = self.llTail.prev.prev
        # Add new item after head
        newNode = Node(key, value)
        # print(f'Adding {newNode} to dict')
        self.dict[key] = newNode
        self.__placeAtTop__(key)
        # print(f'LL after put...')
        # self.printLL()

    def printLL(self):
        current = self.llHead
        ans = ""
        while current:
            ans += f"({current})"
            current = current.next
        print(ans)


# Your LRUCache object will be instantiated and called as such:
# obj = LRUCache(capacity)
# param_1 = obj.get(key)
# obj.put(key,value)