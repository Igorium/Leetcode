public class Solution {
    public IList<string> WordsAbbreviation(IList<string> dict) {
        var map = new Dictionary<string, List<int>>();
        var n = dict.Count;
        var res = new string[n];
        
        for(int i=0; i<n; i++){
            var w = dict[i];
            if(w.Length < 4){
                res[i] = w;
                continue;
            }
            
            var key = Shorter(1, w);
            
            if(!map.ContainsKey(key))
                map[key] = new List<int>();
            
            map[key].Add(i);
        }
        
        foreach(var kv in map){
            if(kv.Value.Count == 1){
                var idx = kv.Value[0];
                res[idx] = kv.Key;
                continue;
            }
            
            var trie = new Trie();
            
            foreach(var idx in kv.Value){
                var w = dict[idx];
                var curr = trie;
                
                for(var i = 1; i < w.Length; i++){
                    var c = w[i]-'a';
                    curr.Count++;
                    curr = curr.Children[c] ?? (curr.Children[c] = new Trie());
                }
            }
            
            foreach(var idx in kv.Value){
                var w = dict[idx];
                var curr = trie;
                var i = 1;
                for(i = 1; i < w.Length && curr.Count > 1; i++)
                    curr = curr.Children[w[i]-'a'];
                res[idx] = Shorter(i, w);
            }
        }
        
        return res;
    }
    
    private string Shorter(int count, string str){
        if(count > str.Length-3)
            return str;
        return str.Substring(0, count) + (str.Length-count-1).ToString() + str[str.Length-1]; 
    }
    
    public class Trie{
        public Trie[] Children = new Trie[26];
        public int Count;
    }
}