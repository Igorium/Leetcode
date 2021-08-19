using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution {
class Solution {
    static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT */
        
        /*
        1, 3, b
        2, 3, c
        
        3,null, a - 

        
        5,2, d
        
        1,3
        2,3
        
        count: 3, 1 ,2 5
        
        
        
        count: (2, a), (1,b), (3, a+b)
        
        map: (2, 3), (1, 3), (3, 3)
        
        
        
        {
            paretid, 
            id,
            count
        }
        
        (3,3, ) (3,1) (3,2)*/
    }
    
    public (int,int)[] TopBrands(int k, (int, int?, int)[] brandInfos){
        var dsu = new DSU();
        
        foreach(var info in brandInfos){
            dsu.Union(info);
        }
        
        var counts = new Dictionary<int, int>();
        
        foreach(var kv in dsu.Counts){
            if (kv.Key = dsu.Find(kv.Key))
                counts[kv.Key] = kv.Value;
        }
        
        var minHeap = new Heap<(int, int)>((a, b)=> a.Count - b.Count);
        
        /*foreaach(var kv in Counts){
            if(minHeap.Count >= k && minHeap.Top.Count < kv.Value)
                minHeap.RemoveTop();
                
            if(minHeap.Count < k)
                minHeap.Push(kv)
        }*/
        
        
        return minHeap.ToArray();
    }
}

// Xa, 
// 1,2,3,4,5,6

// 1 
// 2,3,4 


class DSU{
    
    public Dictionary<int, int> map = new Dictionary<int, int>();
    public Dictionary<int, count> counts = new Dictionary<int, int>();
    
    public void Union(int id, int? parentId, int count){
        
        if(parentId == null){
            map[id] = id;
            counts[id] = count;
        } else {
            // todo when parent weas not found
            var p1 = Find(parentId);
            var p2 = Find(id);
            map[p1] = p2;
            count[p1] += count;
        }
    }
    
    public int Find(int id){
        if(!map.ContainsKey(id)){
            map[id] = id;
            counts[id] = 0;
        }
        
        if(map[id] == id)
            return id;
            
        return Find(map[id]);
    }
    
    
    
}

}



