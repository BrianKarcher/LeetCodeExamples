# Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

# Implement the LRUCache class:

# LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
# int get(int key) Return the value of the key if the key exists, otherwise return -1.
# void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
# The functions get and put must each run in O(1) average time complexity.

# Note to self: Remmeber to correct both links when removing an item from a DOUBLE linked list.

class Node:
    def __init__(self, next = None, prev = None, key = 0, val = 0):
        self.next: Node | None = next
        self.prev: Node | None = prev
        self.key = key
        self.val = val

    def print(self):
        print(f'node prev={self.prev.key if self.prev else -1}, key={self.key}, val={self.val}, next={self.next.key if self.next else -1}')

class LRUCache:

    def __init__(self, capacity: int):
        self.cap = capacity
        self.head = Node(key=-float('inf'))
        self.tail = Node(key=float('inf'))
        self.head.next = self.tail
        self.tail.prev = self.head
        self.map: dict[int, Node] = {} # key: int, val: node

    def __remove_from_ll__(self, node):
        # print('removing')
        # node.print()
        # used when moving a node in get, as well as put when over capacity
        node.prev.next = node.next
        node.next.prev = node.prev

    def __place_at_top__(self, node):
        self.head.next.prev = node
        node.prev = self.head
        node.next = self.head.next
        self.head.next = node

    def get(self, key: int) -> int:
        # print(f'get {key}')
        # self.__print_ll()
        if key not in self.map:
            return -1
        node = self.map[key]
        # Move node to top
        self.__remove_from_ll__(node)
        self.__place_at_top__(node)
        return node.val

    def put(self, key: int, value: int) -> None:
        # print(f'put {key}, {value}')
        # print(f'before')
        # self.__print_ll()
        if key in self.map:
            node = self.map[key]
            node.val = value
            # Move to top
            self.__remove_from_ll__(node)
            self.__place_at_top__(node)
        else:
            node = Node(key = key, val = value)
            self.__place_at_top__(node)
            self.map[key] = node
            if len(self.map) > self.cap:
                # Evict least recently used key
                del_node = self.tail.prev
                del self.map[del_node.key]
                self.__remove_from_ll__(del_node)
        # print(f'after')
        # self.__print_ll()
    
    def __print_ll(self):
        node = self.head
        while node != None:
            # print(f'{node.key} {node.val}')
            node.print()
            node = node.next


############

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