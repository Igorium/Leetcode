public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        var max = new LinkedList<int>();
        var min = new LinkedList<int>();
        var lo = 0;
        var hi = 0;        
        var res = 1;
        
        while(hi < nums.Length){
            var v = nums[hi];

            while(max.Any() && max.Last.Value < v)
                max.RemoveLast();
            max.AddLast(v);
            
            while(min.Any() && min.Last.Value > v)
                min.RemoveLast();
            min.AddLast(v);
            
            while(max.First.Value - min.First.Value > limit){
                if(nums[lo] == max.First.Value)
                    max.RemoveFirst();
                if(nums[lo] == min.First.Value)
                    min.RemoveFirst();
                
                lo++;
            }
            
            res = Math.Max(res, hi-lo+1);
            hi++;
        }
        
        return res;
    }
}