public class LFUCache {
    Dictionary<int, LinkedListNode<CacheNode>> nodeMap;
    Dictionary<int, LinkedList<CacheNode>> countMap;
    int capacity;
    int length;
    int minCount;

    public LFUCache(int capacity) {
        this.capacity = capacity;
        nodeMap = new Dictionary<int, LinkedListNode<CacheNode>>();
        countMap = new Dictionary<int, LinkedList<CacheNode>>();
    }
    
    public int Get(int key) {
        if(nodeMap.TryGetValue(key, out var node)){
            Update(node);
            return node.Value.Val;
        }

        return -1;
    }
    
    public void Put(int key, int value) {
        if(capacity == 0)
            return;

        // override key
        if(nodeMap.TryGetValue(key, out var node)){
            node.Value.Val = value;
            Update(node);
        } else { // new key
            length++;
            
            // invalidate
            if(length > capacity){
                nodeMap.Remove(countMap[minCount].First.Value.Key);
                countMap[minCount].RemoveFirst();
                length--;
            }

            // new cache node
            nodeMap[key] = AddCacheNode(new CacheNode(key, value));
            minCount = 1;
        }
    }

    private void Update(LinkedListNode<CacheNode> node){
        var cacheNode = node.Value;
        
        // moving last node of min count
        if(node.List.Count == 1 && cacheNode.Count == minCount)
            minCount++;
        node.List.Remove(node);

        cacheNode.Count++;
        nodeMap[cacheNode.Key] = AddCacheNode(cacheNode);
    }

    // add node to count map
    private LinkedListNode<CacheNode> AddCacheNode(CacheNode cacheNode){
        if(!countMap.ContainsKey(cacheNode.Count))
            countMap[cacheNode.Count] = new LinkedList<CacheNode>();
        
        countMap[cacheNode.Count].AddLast(cacheNode);
        return countMap[cacheNode.Count].Last;
    }

    class CacheNode{
        public int Key;
        public int Val;
        public int Count;

        public CacheNode(int key, int val){
            Key = key;
            Val = val;
            Count = 1;
        }
    }
}