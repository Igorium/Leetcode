public class Solution {
    public bool CanConvert(string str1, string str2) {
        var n = str1.Length;
        var dsu = new DSU();
        var loops = 0;
       
        for(var i = 0; i < n; i++){
            var a = str1[i];
            var b = str2[i];
            if(a == b)
                continue;
            
             if(dsu.HasAnotherChild(a, b))
                return false;
            
            if(!dsu.Union(a, b))
                loops++;
        }
        
        var jokers = 26 - (new HashSet<char>(str2).Count);
        return jokers >= loops;
    }
    
    class DSU{
        public Dictionary<char, Node> map = new Dictionary<char, Node>();
        
        public bool HasAnotherChild(char a, char b){
            return map.ContainsKey(a) && map[a].Child != null && map[a].Child.Val != b;
        }
        
        public bool Union(char a, char b){
            Node nodeA = FindOrCreate(a);
            Node nodeB = FindOrCreate(b);
            
            if(nodeB.Parent == nodeA)
                return true;

            Node parentA = nodeA;
            Node parentB = nodeB;
            
            while(parentA.Parent != parentA)
                parentA = parentA.Parent;
            
            while(parentB.Parent != parentB)
                parentB = parentB.Parent;
            
            if(parentA == parentB)
                return false;
            
            nodeB.Parent = nodeA;
            nodeA.Child = nodeB;
            
            return true;
        }
        
        private Node FindOrCreate(char c){
            if(map.ContainsKey(c))
                return map[c];
            else{
                var n = new Node(c);
                map[c] = n;
                return n;
            }
        }
    }
    
    class Node{
        public char Val;
        public Node Parent;
        public Node Child;
        
        public Node(char val){
            Val = val;
            Parent = this;
        }
    }
}