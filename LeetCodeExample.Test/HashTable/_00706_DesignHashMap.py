# Design a HashMap without using any built-in hash table libraries.

# Implement the MyHashMap class:

# MyHashMap() initializes the object with an empty map.
# void put(int key, int value) inserts a (key, value) pair into the HashMap. If the key already exists in the map, update the corresponding value.
# int get(int key) returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
# void remove(key) removes the key and its corresponding value if the map contains the mapping for the key.

class Bucket:
    def __init__(self):
        self.arr = []
    
    def get(self, key: int) -> int:
        for (k, v) in self.arr:
            if k == key:
                return v
        return -1
    
    def update(self, key: int, value: int):
        found = False
        for i in range(len(self.arr)):
            if self.arr[i][0] == key:
                found = True
                self.arr[i] = (key, value)
                break
        if not found:
            self.arr.append((key, value))
    
    def remove(self, key: int):
        for i, kv in enumerate(self.arr):
            if key == kv[0]:
                del self.arr[i]

class MyHashMap:
    def __init__(self):
        self.mod = 2069
        # Using 5009 as the mod operator for hashing.
        # I'm not going to do collision detection but a proper system would.
        self.arr = [Bucket() for _ in range(self.mod)]

    def put(self, key: int, value: int) -> None:
        index = key % self.mod
        self.arr[index].update(key, value)

    def get(self, key: int) -> int:
        index = key % self.mod
        return self.arr[index].get(key)

    def remove(self, key: int) -> None:
        index = key % self.mod
        self.arr[index].remove(key)


# Your MyHashMap object will be instantiated and called as such:
# obj = MyHashMap()
# obj.put(key,value)
# param_2 = obj.get(key)
# obj.remove(key)