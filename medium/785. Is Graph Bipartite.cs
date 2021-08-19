public class Solution {
    public bool IsBipartite(int[][] graph) {
        var len = graph.Length;
        var colors = new int[len];

        for(int i = 0; i < len; i++){
            if(colors[i] != 0)
                continue;
            
            var q = new Queue<int>();
            q.Enqueue(i);
            colors[i] = 1;
            while(q.Any()){
                var node = q.Dequeue();
                var color = colors[node];

                foreach(var nei in graph[node]){
                    if(colors[nei] == 0){
                        q.Enqueue(nei);
                        colors[nei] = color == 1 ? 2 : 1;
                    } else if(colors[nei] == color){
                        return false;
                    }
                }
            }
        }

        return true;
    }
}