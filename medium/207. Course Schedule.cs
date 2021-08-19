public class Solution {
    public bool CanFinish(int n, int[][] prerequisites) {
        var inDegree = new int[n];
        var g = new Dictionary<int, HashSet<int>>();

        foreach(var edge in prerequisites){
            var next = edge[0];
            var prev = edge[1];

            inDegree[next]++;

            if(!g.ContainsKey(prev))
                g[prev] = new HashSet<int>();

            g[prev].Add(next);
        }

        var q = new Queue<int>();
        for(int i = 0; i < n; i++){
            if(inDegree[i] == 0)
                q.Enqueue(i);
        }

        while(q.Any()){
            var course = q.Dequeue();

            if(g.ContainsKey(course)){
                foreach(var next in g[course]){
                    inDegree[next]--;
                    if(inDegree[next] == 0)
                        q.Enqueue(next);
                }
            }
        }

        return !inDegree.Any(course => course > 0);
    }
}