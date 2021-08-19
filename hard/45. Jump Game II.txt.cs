public class Solution {
    public int Jump(int[] nums) {
        var n = nums.Length;
        if(n <= 1)
            return 0;
        var curJump = nums[0];
        var nextJump = curJump;
        var res = 1;

        for(int i = 1; i < n; i++){
            if(curJump < i){
                curJump = nextJump;
                res++;
            }
            nextJump = Math.Max(nextJump, nums[i]+i);
        }

        return res;
    }
}