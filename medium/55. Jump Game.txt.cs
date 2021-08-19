public class Solution {
    public bool CanJump(int[] nums) {
        
        if(nums == null || nums.Length <= 1){
            return true;
        }
        
        
        var lastGood = nums.Length - 1;
        
        for(var pos = nums.Length - 2; pos >= 0; pos--){            
            if(pos+nums[pos] >= lastGood)
                lastGood = pos;
        }
        
        return lastGood == 0;
        
        /*var memo = new int[nums.Length];
        memo[nums.Length-1] = 1;
        
        for(var pos = nums.Length - 2; pos >= 0; pos--){
            var jump = (int)Math.Min(nums[pos]+pos, nums.Length-1);
            
            for(var i = pos + 1; i <= jump; i++){
                if(memo[i] == 1){
                    memo[pos] = 1;
                    break;
                }
            }
        }
        
        return memo[0] == 1;*/
        
        //return BackTrack(nums, 0, new int[nums.Length]);
    }
    
    /*private bool BackTrack(int[] nums, int pos, int[] memo){
        if(pos == nums.Length-1 || memo[pos] == 1)
            return true;
        
        if(memo[pos] == -1)
            return false;
        
        var jump = (int)Math.Min(nums[pos]+pos, nums.Length-1);
        for(var i = jump; i > pos; i--){
            if(BackTrack(nums, i, memo)){
                memo[pos] = 1;
                return true;
            }
        }
        
        memo[pos] = -1;
        return false;
    }*/
}