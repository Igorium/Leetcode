public class Solution {
    private int cols;
    private int rows;
    private int[][] dir = {new []{0,1}, new []{1,0}, new []{0,-1}, new []{-1,0}};
    private int[,] memo;
    
    public int LongestIncreasingPath(int[][] matrix) {
        rows = matrix.Length;
        if(rows == 0)
            return 0;
        cols = matrix[0].Length;
        memo = new int[rows, cols];
        
        var max = 0;
        for(int i = 0; i < rows; i++)
            for(int j = 0; j < cols; j++)
                max = Math.Max(max, DFS(matrix, i, j));
        
        return max;
    }
    
    private int DFS(int[][] m, int row, int col){
        if(memo[row, col] > 0)
            return memo[row, col];
        
        var len = 0;
        foreach(var d in dir){
            var r = row+d[0];
            var c = col+d[1];
            
            if(r >= 0 && r < rows && c >= 0 && c < cols && m[row][col] < m[r][c])
               len = Math.Max(len, DFS(m, r, c));
        }
        
        memo[row, col] = ++len;
        return len;
    }
}