public class Solution {

    // 
    public int MaxSubArrayLen(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        var max = 0;
        var sum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            if(sum == k){
                max = Math.Max(max, i+1);
            } else if(map.ContainsKey(sum-k)){
                max = Math.Max(max, i - map[sum-k]);
            }

            if(!map.ContainsKey(sum))
                map[sum] = i;
        }

        return max;
    }
}