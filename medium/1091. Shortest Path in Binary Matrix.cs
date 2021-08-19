public class Solution {
    private ValueTuple<int, int>[] dir = new ValueTuple<int, int>[]{
        (-1,0),
        (-1,1),
        (-1,-1),
        (0,-1),
        (1,1),
        (0,1),
        (1,0),
        (1,-1)
    };
    
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var rows = grid.Length;
        if(rows == 0)
            return -1;
        var cols = grid[0].Length;
        if(grid[0][0] == 1 || grid[rows-1][cols-1] == 1)
            return -1;
                
        var q = new Queue<ValueTuple<int,int,int>>();
        q.Enqueue((0,0,0));
        grid[0][0] = 1;
        
                
        while(q.Any()){
            (var rowS, var colS, var path) = q.Dequeue();
            if(rowS == rows - 1 && colS == cols - 1)
                return path+1;
            
            foreach((var rowD, var colD) in dir){
                var row = rowS + rowD;
                var col = colS + colD;
                if(row >= 0 && col >= 0 && row < rows && col < cols && grid[row][col] != 1){
                    q.Enqueue((row,col, path+1));
                    grid[row][col] = 1;
                }
            }
        }
        
        return -1;
    }
}