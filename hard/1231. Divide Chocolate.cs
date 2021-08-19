public class Solution {
    public int MaximizeSweetness(int[] sweetness, int K) {
        var n = sweetness.Length;
        var lo = 0;
        var hi = 0;
        for(int i =0; i < n; i++){
            lo = Math.Min(lo, sweetness[i]);
            hi += sweetness[i];
        }

        while(lo < hi){
            var mid = lo + (hi-lo)/2 + 1;
            var cuts = 0;
            var sum = 0;
            for(int i = 0; i < n; i++){
                sum += sweetness[i];
                if(sum >= mid){
                    sum = 0;
                    if(++cuts == K+1)
                        break;
                }
            }
            
            if(cuts < K+1)
                hi = mid-1;
            else
                lo = mid;
        }
        
        return lo;
    }
}