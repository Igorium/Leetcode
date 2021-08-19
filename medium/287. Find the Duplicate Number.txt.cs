public class Solution {
    public int FindDuplicate(int[] nums) {
        var n = nums.Length;
        for(int i = 0 ; i < n; i++){
            var idx = Math.Abs(nums[i])-1;
            if(nums[idx] < 0)
                return idx+1;
            nums[idx] *= -1;
        }

        return -1;
    }
}