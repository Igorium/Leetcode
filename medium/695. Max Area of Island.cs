public class Solution {
    private int rows;
    private int cols;
    public int MaxAreaOfIsland(int[][] grid) {
        rows = grid.Length;
        cols = grid[0].Length;
        var res = 0;
        
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(grid[i][j] == 1){
                    res = Math.Max(res, BFS(i, j, grid));
                }
            }
        }
        
        return res;
    }
    
    private int BFS(int row, int col, int[][] grid){
        var res = 0;
        var q = new Queue<ValueTuple<int, int>>();
        q.Enqueue((row, col));
        grid[row][col] = -1;
        
        while(q.Any()){
            (var r, var c) = q.Dequeue();
            res++;
            foreach((var rd, var cd) in Directions){
                var nr = r+rd;
                var nc = c+cd;
                if(nr>=0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1){
                    q.Enqueue((nr, nc));
                    grid[nr][nc] = -1;
                }
            }
        }
        return res;
    }
    
    private ValueTuple<int,int>[] Directions = new []{(1,0),(-1,0),(0,1),(0,-1)};
}