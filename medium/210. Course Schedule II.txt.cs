public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var g = new List<int>[numCourses];
        var indegree = new int[numCourses];
        
        foreach(var p in prerequisites){
            var key = p[1];
            if(g[key] == null)
                g[key] = new List<int>();
            
            g[key].Add(p[0]);
            indegree[p[0]]++;
        }

        var q = new Queue<int>();
        var res = new int[numCourses];
        for(var i = 0; i < indegree.Length; i++)
            if(indegree[i] == 0){
                q.Enqueue(i);
                res.Add(i);
            }
        
        while(q.Any()){
            var course = q.Dequeue();
            var children = g[course];
            if(children == null)
                continue;

            foreach(var child in children){
                indegree[child]--;
                if(indegree[child] == 0){
                    q.Enqueue(child);
                    res.Add(child);
                }
            }
        }
        
        return res;
    }
}

public class Solution {
    private HashSet<int> visited = new HashSet<int>();
    private Stack<int> order = new Stack<int>();
    private HashSet<int>[] g;
    
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        g = new HashSet<int>[numCourses];
        
        foreach(var p in prerequisites){
            var key = p[1];
            if(g[key] == null)
                g[key] = new HashSet<int>();
            
            g[key].Add(p[0]);
        }
        
        for(int i = 0; i < numCourses; i++){
            if (!BFS(i, new HashSet<int>()))
                return new int[0];
        }
        
        return order.ToArray();
    }
    
    private bool BFS(int node, HashSet<int> visiting){
        if(visited.Contains(node))
            return true;
        if(visiting.Contains(node))
            return false;
        
        visiting.Add(node);

        if(g[node] != null)
            foreach(var child in g[node]){
                if (!BFS(child, visiting))
                    return false;
            }
        
        visited.Add(node);
        order.Push(node);
        return true;
    }
}