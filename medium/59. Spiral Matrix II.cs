public class Solution {
    public int[][] GenerateMatrix(int n) {
        var val = 1;
        var res = new int[n][];

        for(int i = 0; i < n; i++)
            res[i] = new int[n];

        var top = 0;
        var bottom = n-1;
        var left = 0;
        var right = n-1;
        
        while(val <= n*n){
            for(int c = left; c <= right; c++)
                res[top][c] = val++;
            top++;

            for(int r = top; r <= bottom; r++)
                res[r][right] = val++;
            right--;

            for(int c = right; c >= left; c--)
                res[bottom][c] = val++;
            bottom--;

            for(int r = bottom; r >= top; r--)
                res[r][left] = val++;
            left++;
        }
        
        return res;
    }
}