public class Solution {
    public void Rotate(int[] nums, int k) {
        var n = nums.Length;
        var count =0;
        
        for(int start =0; count < n; start++){
            var idx = start;
            var memo = nums[idx];
            
            do{
                var pos= (idx+k)%n;
                var t = nums[pos];
                nums[pos] = memo;
                memo = t;
                idx = pos;

                count++;
            } while(idx != start);
        }
    }
}