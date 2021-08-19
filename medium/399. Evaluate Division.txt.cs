public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        
        var graph = new Dictionary<string, Dictionary<string, double>>();
        
        for (var i = 0; i < equations.Count; i++){
            var dividend = equations[i][0];
            var divisor = equations[i][1];
            var quotent = values[i];
            
            if (!graph.TryGetValue(dividend, out var d1)){
                d1 = new Dictionary<string, double>();
                graph.Add(dividend, d1);
            }
            if (!graph.TryGetValue(divisor, out var d2)){
                d2 = new Dictionary<string, double>();
                graph.Add(divisor, d2);
            }
            
            d1.Add(divisor, quotent);
            d2.Add(dividend, 1/quotent);
        }
        
        var res = new double[queries.Count];
                                
        
        for(var i = 0; i < queries.Count; i++){
            var start = queries[i][0];
            var end = queries[i][1];
            
            if (!graph.ContainsKey(start) || !graph.ContainsKey(end)){
                res[i] = -1;
                continue;
            }
            if(start == end){
                res[i] = 1;
                continue;
            }            
            
            res[i] = -1;
            var visited = new HashSet<string>();
            
            res[i] = DFS(graph, start, end, visited, 1);
            
            /* DFS
            var q = new Queue<ValueTuple<string, double>>();
            q.Enqueue((start, 1.0));
            
            while(q.Count > 0){
                (string node, double sum) = q.Dequeue();
                
                visited.Add(node);
                var nodes = graph[node];
                
                if (nodes.TryGetValue(end, out var val)){
                    res[i] = sum*val;
                    break;
                }
                
                foreach(var kv in nodes){                    
                    if(visited.Contains(kv.Key))
                        continue;                   
                    
                    q.Enqueue((kv.Key, sum*kv.Value));
                }
            }
            */
        }

        return res;
    }
    
    private double DFS(Dictionary<string, Dictionary<string, double>> graph, string curr, string target, HashSet<string> visited, double sum){
        var nodes = graph[curr];
        
        if (nodes.TryGetValue(target, out var val)){
            return sum * val;    
        }     
        
        visited.Add(curr);
        var ret = -1.0;
        
        foreach(var kv in nodes.Where(n => !visited.Contains(n.Key))){
            ret = DFS(graph, kv.Key, target, visited, sum*kv.Value);
            
            if(ret > -1)
                break;
        }
        
        //visited.Remove(curr);
        return ret;
    }
}