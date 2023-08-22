Here is a simple implementation of an LRU Cache using C#:

```C#
using System;
using System.Collections.Generic;

public class LRUCache<TKey, TValue>
{
    private readonly int capacity;
    private Dictionary<TKey, LinkedListNode<CacheItem>> cache;
    private LinkedList<CacheItem> lruList;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.cache = new Dictionary<TKey, LinkedListNode<CacheItem>>(capacity);
        this.lruList = new LinkedList<CacheItem>();
    }

    public TValue Get(TKey key)
    {
        if (cache.TryGetValue(key, out LinkedListNode<CacheItem> node))
        {
            TValue value = node.Value.Value;
            lruList.Remove(node);
            lruList.AddLast(node);
            return value;
        }
        return default(TValue);
    }

    public void Add(TKey key, TValue value)
    {
        if (cache.Count >= capacity)
        {
            RemoveFirst();
        }

        CacheItem cacheItem = new CacheItem { Key = key, Value = value };
        LinkedListNode<CacheItem> node = new LinkedListNode<CacheItem>(cacheItem);
        lruList.AddLast(node);
        cache.Add(key, node);
    }

    private void RemoveFirst()
    {
        LinkedListNode<CacheItem> node = lruList.First;
        lruList.RemoveFirst();
        cache.Remove(node.Value.Key);
    }

    private class CacheItem
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LRUCache<string, string> cache = new LRUCache<string, string>(3);
        cache.Add("1", "one");
        cache.Add("2", "two");
        cache.Add("3", "three");
        cache.Add("4", "four");
        if (cache.Get("2") == null)
            Console.WriteLine("2 not found");
        if (cache.Get("1") == null)
            Console.WriteLine("1 not found");
        cache.Add("5", "five");
        if (cache.Get("3") == null)
            Console.WriteLine("3 not found");
    }
}
```

This program creates an LRU cache with a capacity of 3. It adds four items, causing the first item to be evicted because the cache is over capacity. It then tries to retrieve the second and first items. The second item is found, but the first item is not because it was evicted. It then adds a fifth item, causing the third item to be evicted, and tries to retrieve the third item, which is not found.