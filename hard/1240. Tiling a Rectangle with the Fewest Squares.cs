public class Solution {
    int ans = int.MaxValue;
    
    public int TilingRectangle(int n, int m) {
        dfs(0, 0, new bool[n,m], 0);
        return ans;
    }
    
    // (r, c) is the starting point for selecting a square
    // rect records the status of current rectangle
    // cnt is the number of squares we have covered
    private void dfs(int r, int c, bool[,] rect, int cnt) {
        var n = rect.GetLength(0);
        var m = rect.GetLength(1);
        
        // optimization 1: The current cnt >= the current answer
        if (cnt >= ans)
            return;
        
        // Successfully cover the whole rectangle
        if (r == n) {
            ans = cnt; 
            return;
        }
        
        // Successfully cover the area [0, ..., n][0, ..., c] => Move to next row
        if (c == m) {
            dfs(r+1, 0, rect, cnt); 
            return;
        }
        
        // If (r, c) is already covered => move to next point (r, c+1)
        if (rect[r,c]) {
            dfs(r, c+1, rect, cnt);
            return;
        }
        
        // Try all the possible size of squares starting from (r, c)
        for (int k = Math.Min(n-r, m-c); k >= 1 && isAvailable(rect, r, c, k); k--) {
            cover(rect, r, c, k);
            dfs(r, c+k, rect, cnt+1);
            uncover(rect, r, c, k);
        }
    }
    // Check if the area [r, ..., r+k][c, ..., c+k] is alreadc covered
    private bool isAvailable(bool[,] rect, int r, int c, int k) {
        for (int i = 0; i < k; i++){
            for(int j = 0; j < k; j++){
                if(rect[r+i,c+j]) 
                    return false;
            }
        }
        return true;
    }
    // Cover the area [r, ..., r+k][c, ..., c+k] with a k * k square
    private void cover(bool[,] rect, int r, int c, int k) {
        for(int i = 0; i < k; i++){
            for(int j = 0; j < k; j++){
                rect[r+i,c+j] = true;
            }
        }
    }
    // Uncover the area [r, ..., r+k][c, ..., c+k]
    private void uncover(bool[,] rect, int r, int c, int k) {
        for(int i = 0; i < k; i++){
            for(int j = 0; j < k; j++){
                rect[r+i,c+j] = false;
            }
        }
    }
}