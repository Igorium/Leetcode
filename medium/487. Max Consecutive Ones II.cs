public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var n = nums.Length;
        var len = 0;
        var flipped = 0;
        var res = 0;
        for(int i=0; i<n; i++){
            flipped = nums[i] == 1 ? flipped+1 : len+1;
            len = nums[i] == 1 ? len+1 : 0;
            res = Math.Max(res, flipped);
        }
        return res;
    }
}