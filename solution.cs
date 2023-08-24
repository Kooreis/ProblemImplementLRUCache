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