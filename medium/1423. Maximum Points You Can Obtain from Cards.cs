public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        var max = 0;
        var cp = cardPoints;
        var len = cp.Length;
        var lo = len - k;
        var hi = lo;
        var sum = 0;
        
        while(hi < len + k){
            if(hi-lo >= k){
                sum -= cp[lo % len];
                lo++;
            }
                
            sum += cp[hi % len];
            max = Math.Max(sum, max);
            hi++;
        }
        
        return max;
    }
}