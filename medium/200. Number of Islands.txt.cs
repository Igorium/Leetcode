public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid== null || grid.Length ==0)
            return 0;
        
        var rn = grid.Length;
        var cn = grid[0].Length;       
        
        var res = 0;
        
        for(var r = 0; r < rn; r++){
            for(var c = 0; c < cn; c++){
                if (grid[r][c] == '1'){
                    grid[r][c] = '0';
                    res++;
                    
                    var q = new Queue<ValueTuple<int,int>>();
                    q.Enqueue((r,c));
                    
                    while(q.Count > 0){
                        (var rr, var cc) = q.Dequeue();
                        
                        if (rr+1 < rn && grid[rr+1][cc] == '1'){
                            grid[rr+1][cc] = '0';
                            q.Enqueue((rr+1, cc));
                        }
                        
                        if (rr-1 >= 0 && grid[rr-1][cc] == '1'){
                            grid[rr-1][cc] = '0';
                            q.Enqueue((rr-1, cc));
                        }
                        
                        
                        if (cc+1 < cn && grid[rr][cc+1] == '1'){
                            grid[rr][cc+1] = '0';
                            q.Enqueue((rr, cc+1));
                        }
                        
                        if (cc-1 >= 0 && grid[rr][cc-1] == '1'){
                            grid[rr][cc-1] = '0';
                            q.Enqueue((rr, cc-1));
                        }
                    }
                }
            }
        }
        
        return res;
    }
}