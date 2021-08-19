public class Solution {
    public int OrangesRotting(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var q = new Queue<(int, int)>();
        var freshCount = 0;
        
        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(grid[r][c] == 1)
                    freshCount++;
                else if(grid[r][c] == 2)
                    q.Enqueue((r,c));
            }
        }

        var dir = new []{(1,0), (0,1), (-1,0), (0,-1)};

        var minutes = 0;
        while(q.Any() && freshCount > 0){
            var count = q.Count;
            for(int i = 0; i < count; i++){
                var (row, col) = q.Dequeue();
                foreach(var (rd, cd) in dir){
                    var r = row+rd;
                    var c = col+cd;
                    if(r >= 0 && r < rows && c >= 0 && c < cols && grid[r][c] == 1){
                        q.Enqueue((r,c));
                        grid[r][c] = 2;
                        freshCount--;
                    }
                }
            }
            minutes++;
        }

        return freshCount > 0 ? -1 : minutes;
    }
}