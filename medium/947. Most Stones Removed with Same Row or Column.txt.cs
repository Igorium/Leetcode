public class Solution {
    public int RemoveStones(int[][] stones) {
        var dsu = new DSU();
        var colsOffcet = 10000;
        
        foreach(var stone in stones){
            dsu.Union(stone[0], stone[1] + colsOffcet);
        }
        
        var sets = new HashSet<int>();
        
        foreach(var stone in stones){
            sets.Add(dsu.Find(stone[0]).Val);
        }
        
        return stones.Length - sets.Count;
    }
    
    public class DSU{
        private Dictionary<int, Node> map = new Dictionary<int, Node>();
        
        public Node Create(int v){
            if (!map.TryGetValue(v, out var node))
                node = map[v] = new Node(v);
            return node;
        }
        
        public void Union(int a, int b){
            var parentA = Find(Create(a));
            var parentB = Find(Create(b));
            
            if (parentA != parentB)
                parentB.Parent = parentA;
        }
        
        public Node Find(int v){
            return Find(map[v]);
        }
        
        public Node Find(Node n){
            return n.Parent == n ? n : Find(n.Parent);
        }
    }
    
    public class Node{        
        public Node Parent;
        public int Val;       
        
        public Node(int val){
            Parent = this;
            Val = val;
        }
    }
}