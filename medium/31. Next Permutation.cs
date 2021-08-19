public class Solution {
    public void NextPermutation(int[] nums) {
        var n = nums.Length;
        var idx = n - 2;
        while(idx >= 0 && nums[idx] >= nums[idx+1])
            idx--;

        if(idx >= 0){
            var idx2 = n-1;
            while(nums[idx2] <= nums[idx])
                idx2--;

            var t = nums[idx];
            nums[idx] = nums[idx2];
            nums[idx2] = t;
        }
        
        idx++;
        Array.Reverse(nums, idx, n-idx);
        
        return;
    }
}