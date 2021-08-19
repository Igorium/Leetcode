public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        
        var leftIdx = Search(nums, target, 0, nums.Length, true);
        
        if(leftIdx >= nums.Length || nums[leftIdx] != target)
            return new[] {-1,-1};
        

        return new[] {leftIdx, Search(nums, target, leftIdx, nums.Length, false)-1};
    }
        
    private int Search(int[] nums, int target, int lo, int hi, bool left){
        while (lo < hi) {
            int mid = (lo + hi) / 2;
            if (nums[mid] > target || (left && target == nums[mid])) {
                hi = mid;
            }
            else {
                lo = mid+1;
            }
        }

        return hi;
    }
}