public class Solution {
    /*
    
    ab
    adc
    
    */
    public string AlienOrder(string[] words) {
        var g = new Dictionary<char, HashSet<char>>(); // c[d] d[f]
        var indegree = new Dictionary<char, int>(); // c0 d1 f1

        foreach(var word in words)
            foreach(var c in word)
                indegree[c] = 0;

        for(int i = 1; i < words.Length; i++){ // f
            var w1 = words[i-1]; // abd
            var w2 = words[i]; // abf
            var pos = 0; // 2
            while(pos < w1.Length && pos < w2.Length){ 
                var a = w1[pos]; // d
                var b = w2[pos]; // f

                if(a != b){ // t
                    if(!g.ContainsKey(a) || !g[a].Contains(b)){
                        if(!g.ContainsKey(a))
                            g[a] = new HashSet<char>();
                        g[a].Add(b);
                        indegree[b]++;
                    }
                    break;
                }
                pos++;
            }
            // w1 should  not be longer!
            if(pos == w2.Length && w2.Length != w1.Length) // adc ab
                return "";
        }

        var q = new Queue<char>(); // d
        foreach(var kv in indegree){
            if(kv.Value == 0)
                q.Enqueue(kv.Key);
        }

        var sb = new StringBuilder(); // cd
        // c[d] d[f]
        // c0 d0 f0

        while(q.Any()){
            var c = q.Dequeue();
            sb.Append(c);

            if(!g.ContainsKey(c))
                continue;
            
            foreach(var nei in g[c]){
                indegree[nei]--;
                if(indegree[nei] == 0)
                    q.Enqueue(nei);
            }
        }
        
        Console.WriteLine(sb.ToString());

        return sb.Length == indegree.Count ? sb.ToString() : "";
    }
}