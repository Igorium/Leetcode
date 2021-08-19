public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var rows = isConnected.Length;
        if(rows == 0) return 0;
        var cols = isConnected[0].Length;
        var visited = new HashSet<int>();
        var q = new Queue<int>();
        var res = 0;
        
        for(int r = 0; r < rows; r++){
            if(visited.Contains(r))
                continue;

            visited.Add(r);
            q.Enqueue(r);
            
            while(q.Any()){
                var city = q.Dequeue();
                for(int c = 0; c < cols; c++){
                    if(isConnected[city][c] == 1 && !visited.Contains(c)){
                        visited.Add(c);
                        q.Enqueue(c);
                    }
                }
            }
            res++;
        }

        return res;
    }
}