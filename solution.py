Here is a Python console application that implements an LRU Cache using OrderedDict from collections module.

```python
from collections import OrderedDict

class LRUCache:
    def __init__(self, capacity):
        self.cache = OrderedDict()
        self.capacity = capacity

    def get(self, key):
        if key not in self.cache:
            return -1
        else:
            self.cache.move_to_end(key)
            return self.cache[key]

    def put(self, key, value):
        if key in self.cache:
            self.cache.move_to_end(key)
        self.cache[key] = value
        if len(self.cache) > self.capacity:
            self.cache.popitem(last=False)

def main():
    lru_cache = LRUCache(2)
    lru_cache.put(1, 1)
    lru_cache.put(2, 2)
    print(lru_cache.get(1))       # returns 1
    lru_cache.put(3, 3)           # evicts key 2
    print(lru_cache.get(2))       # returns -1 (not found)
    lru_cache.put(4, 4)           # evicts key 1
    print(lru_cache.get(1))       # returns -1 (not found)
    print(lru_cache.get(3))       # returns 3
    print(lru_cache.get(4))       # returns 4

if __name__ == "__main__":
    main()
```

In this code, we are using an OrderedDict to keep track of the order of use of the keys. When a key is accessed, it is moved to the end of the OrderedDict to indicate that it is the most recently used key. When the cache reaches its capacity, the least recently used key (the first key in the OrderedDict) is removed.