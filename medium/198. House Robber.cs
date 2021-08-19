public class Solution {
    public int Rob(int[] nums) {
        var len = nums.Length;

        for(int i = 2; i < len; i++)
            nums[i] += Math.Max(i > 2 ? nums[i-3] : 0, nums[i-2]); // choose from 2 prev maximums

        return len < 2 ? nums[0] : Math.Max(nums[len-1], nums[len-2]);
    }
}

public class Solution {
    public int Rob(int[] nums) {
        var len = nums.Length;

        for(int i = 2; i < len; i++){
            var max = Math.Max(nums[i-2], nums[i-1]);
            for(int j = 0; j <= i-2; j++){
                max = Math.Max(max, nums[j]);
            } 
            nums[i] += max;
        }

        return len < 2 ? nums[0] : Math.Max(nums[len-1], nums[len-2]);
    }
}