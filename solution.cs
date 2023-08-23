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