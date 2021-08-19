public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;
        if(n < 3)
            return 0;
        
        var lo = 0;
        var hi = n-1;
        var loMax = height[lo];
        var hiMax = height[hi];
        var res = 0;
        
        while(lo < hi-1){
            if(loMax <= hiMax){
                var curr = height[++lo];
                if(curr < loMax)
                    res += loMax - curr;
                else
                    loMax = curr; // !!!
            } else{
                var curr = height[--hi];
                if(curr < hiMax)
                    res += hiMax - curr;
                else
                    hiMax = curr;  // !!!
            }
        }
        
        return res;
    }
}