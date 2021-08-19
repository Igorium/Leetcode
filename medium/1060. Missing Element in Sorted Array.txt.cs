public class Solution {
    public int MissingElement(int[] nums, int k) {
        int missing(int idx) {
            return nums[idx] - nums[0] - idx;
        }
        
        var n = nums.Length;
        var diff = missing(n-1);
        
        if(diff < k){
            return nums[n-1]+k-diff; 
        }
        
        var lo = 0;
        var hi = n-1;
        while(hi != lo){
            var mid = lo + (hi-lo)/2;
            diff = missing(mid);
            if(diff < k){
                lo = mid + 1;
            } else {
                hi = mid;
            }
        }
        
        return nums[hi - 1] + k - missing(hi-1);
    }
}