public class LRUCache {
    private int cap;
    private Dictionary<int, LinkedListNode<ValueTuple<int,int>>> map = new Dictionary<int, LinkedListNode<ValueTuple<int,int>>>();
    private LinkedList<ValueTuple<int,int>> history = new LinkedList<ValueTuple<int,int>>();
    
    public LRUCache(int capacity) {
        cap = capacity;
    }
    
    public int Get(int key) {
        if(map.TryGetValue(key, out var node)){
            history.Remove(node);
            history.AddLast(node);
            return node.Value.Item2;
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        var containsKey = map.ContainsKey(key);
        
        if(!containsKey && map.Count == cap){
            var evicted = history.First;
            history.Remove(evicted);
            map.Remove(evicted.Value.Item1);
        }
        
        if(containsKey){
            var node = map[key];
            node.Value = (key, value);
            history.Remove(node);
            history.AddLast(node);
        } else{
            history.AddLast((key, value));
            map[key] = history.Last;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */