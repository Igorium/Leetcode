public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        var lo = 0;
        var hi = 0;
        var sum = 0;
        var res = int.MaxValue;
        while(hi < nums.Length){
            while(hi < nums.Length && sum < s){
                sum += nums[hi++];
            }
            while(sum >= s && lo <= hi && lo < nums.Length){
                res = Math.Min(res, hi - lo);
                sum -= nums[lo++];
            }
        }
        return res == int.MaxValue ? 0 : res;
    }
}