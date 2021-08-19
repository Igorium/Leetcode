public class Solution {
    public int ClimbStairs(int n) {
        
        //var steps = new int[n];
        var prev1 = 2;
        var prev2 = 1;
        
        
        for(int i = 2; i < n; i++){
            var curr = prev1 + prev2;
            prev2 = prev1;
            prev1 = curr;
        }
        
        return n > 1 ? prev1 : prev2;
    }
}