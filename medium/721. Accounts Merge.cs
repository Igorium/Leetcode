public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var dsu = new DSU();
        var emailToName = new Dictionary<string, string>();

        foreach(var acc in accounts){
            var name = acc[0];
            for(int i = 1; i < acc.Count; i++){
                emailToName[acc[i]] = name;
                dsu.Union(acc[1], acc[i]);
            }
        }

        var emailGroups = new Dictionary<string, HashSet<string>>();
        foreach(var email in emailToName.Keys){
            var key = dsu.Find(email);
            if(!emailGroups.ContainsKey(key))
                emailGroups[key] = new HashSet<string>();
            
            emailGroups[key].Add(email);
        }

        var res = new List<IList<string>>();

        foreach(var kv in emailGroups){
            var name = emailToName[kv.Key];
            var acc = kv.Value.OrderBy(v => v, StringComparer.Ordinal).ToList();
            acc.Insert(0, name);
            res.Add(acc);
        }

        return res;
    }

    public class DSU{
        public Dictionary<string, string> Nodes = new Dictionary<string, string>();
        
        public void Union(string a, string b){
            Nodes[Find(a)] = Find(b);
        }
        
        public string Find(string v){
            if(!Nodes.ContainsKey(v))
                Nodes[v] = v;

            if(Nodes[v] != v)
                Nodes[v] = Find(Nodes[v]);

            return Nodes[v];
        }
    }
}