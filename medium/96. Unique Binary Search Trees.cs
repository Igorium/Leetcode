public class Solution {
    public int NumTrees(int n) {
        if(n == 0)
            return 0;
        
        N = n;
        
        return NumTrees(1, n);
    }
    
    private Dictionary<int, int> memo = new Dictionary<int, int>();
    private int N = 0;
    
    public int NumTrees(int start, int end) {
        var count = 0;
        
        if (start > end){
            return 1;
        }
        
        var key = start*N+end;
        if(memo.TryGetValue(key, out var res))
            return res;
        
        for(int i = start; i <= end; i++){
            var lTrees = NumTrees(start, i-1);
            var rTrees = NumTrees(i+1, end);
            
            count += lTrees * rTrees;
        }
        
        memo[key] = count;
        
        return count;
    }
}