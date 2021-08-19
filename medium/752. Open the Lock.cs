public class Solution {
    public int OpenLock(string[] deadends, string target) {
        var dead = new HashSet<string>(deadends);
        var visiteds = new HashSet<string>();
        var visitede = new HashSet<string>();
        if(dead.Contains("0000") || dead.Contains(target))
            return -1;
        if(target == "0000")
            return 0;
        
        var qs = new Queue<string>();
        var qe = new Queue<string>();
        qs.Enqueue("0000");
        visiteds.Add("0000");
        qe.Enqueue(target);
        visitede.Add(target);
        var level = 1;
        
        while(qs.Any() && qe.Any()){
            if(BFS(qs, visiteds, visitede, dead))
                return level;
            level++;
            if(BFS(qe, visitede, visiteds, dead))
                return level;
            level++;
        }
        
        return -1;
    }
    
    bool BFS(Queue<string> q, HashSet<string> visited, HashSet<string> visitedOther, HashSet<string> deadSet){
        for(var count = q.Count; count > 0; count--){
                var node = q.Dequeue();
                foreach(var nei in GetNeighbours(node)){
                    //Console.WriteLine(nei);
                    
                    if (visitedOther.Contains(nei))
                        return true;
                    
                    if(!visited.Contains(nei) && !deadSet.Contains(nei)){
                        visited.Add(nei);
                        q.Enqueue(nei);
                    }
                }
            }
        
        return false;
    }
    
    IEnumerable<string> GetNeighbours(string str){
        
        for(int i = 0; i < str.Length; i++){
            var node = str.ToCharArray();
            var c = (int)(node[i] - '0');
            node[i] = (char)((c == 9 ? 0 : c+1) + '0');
            yield return new String(node);
            
            node[i] = (char)((c == 0 ? 9 : c-1) + '0');
            yield return new String(node);
        }
    }
}