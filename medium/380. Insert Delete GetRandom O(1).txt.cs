public class RandomizedSet {
    private Dictionary<int,int> map = new Dictionary<int, int>();
    private List<int> list = new List<int>();
    private Random rand = new Random();
    
    /** Initialize your data structure here. */
    public RandomizedSet() {
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(map.ContainsKey(val))
            return false;
        
        list.Add(val);
        map[val] = list.Count-1;
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!map.ContainsKey(val))
            return false;
        
        var idx = map[val];
        if (list.Count-1 != idx){ // element is already at the end
            list[idx] = list[list.Count-1];
            map[list[idx]] = idx;
        }
        
        list.RemoveAt(list.Count-1);
        map.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        var idx = rand.Next(0,list.Count);
        return list[idx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */