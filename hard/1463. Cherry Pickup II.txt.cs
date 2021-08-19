public class Solution {
    public int CherryPickup(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var dp = new int[rows, cols, cols];
        
        for(var r = rows-1; r >= 0; r--){
            for(var c1 = 0; c1 < cols; c1++){
                for(var c2 = 0; c2 < cols; c2++){
                    var val = c1 == c2 ? grid[r][c1] : grid[r][c1] + grid[r][c2];
                    var max = 0;
                    
                    if(r != rows-1)
                        for(var i=c1-1; i<=c1+1; i++)
                            for(var j=c2-1; j<=c2+1; j++)
                                if(i >= 0 && j>=0 && i <cols && j< cols)
                                    max = Math.Max(max, dp[r+1,i,j]);
                    
                    dp[r,c1,c2] = val+max;
                }
            }
        }
        
        return dp[0,0,cols-1];
    }
}