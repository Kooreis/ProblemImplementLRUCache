Here is a simple implementation of an LRU Cache using LinkedHashMap in Java:

```java
import java.util.LinkedHashMap;
import java.util.Map;

public class LRUCache<K, V> {
    private final int capacity;
    private final Map<K, V> cache;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.cache = new LinkedHashMap<>(capacity, 0.75f, true) {
            protected boolean removeEldestEntry(Map.Entry eldest) {
                return size() > LRUCache.this.capacity;
            }
        };
    }

    public synchronized V get(K key) {
        return cache.get(key);
    }

    public synchronized void put(K key, V value) {
        cache.put(key, value);
    }

    public synchronized void remove(K key) {
        cache.remove(key);
    }

    public synchronized int size() {
        return cache.size();
    }

    public static void main(String[] args) {
        LRUCache<Integer, String> lruCache = new LRUCache<>(2);
        lruCache.put(1, "one");
        lruCache.put(2, "two");
        lruCache.get(1);
        lruCache.put(3, "three");
        System.out.println(lruCache.get(1));
        System.out.println(lruCache.get(2));
        System.out.println(lruCache.get(3));
    }
}
```

In the main method, we create an LRU cache with a capacity of 2. We then put two entries into the cache and access the first entry. When we try to put a third entry into the cache, the second entry (which is the least recently used) is removed. The output of the program is:

```
one
null
three
```

This shows that the second entry was correctly removed from the cache when the third entry was added.