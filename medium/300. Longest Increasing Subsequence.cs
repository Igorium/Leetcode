public class Solution {
    public int LengthOfLIS(int[] nums) {
        //return DFS(nums, 0, -1, new int?[nums.Length+1, nums.Length+1]);

        
        var res = 0;
        var len = nums.Length;
        
        if(len < 2)
            return len;
        
        var dp = new int[len];
        dp[0] = 1;

        for(int i = 1; i < len; i++){
            var max = 0;
            for(int j = 0; j < i; j++){
                if(nums[i] > nums[j])
                    max = Math.Max(max, dp[j]);
            }
            dp[i] = max+1;
            res = Math.Max(max+1, res);
        }

        return res;
    }

    private int DFS(int[] nums, int cur, int prev, int?[,] memo){
        if(cur == nums.Length)
            return 0;

        if(memo[cur, prev+1] != null)
            return memo[cur, prev+1].Value;

        var count = DFS(nums, cur+1, prev, memo);
        
        var isIncreasing = prev == -1 || nums[cur] > nums[prev];
        if(isIncreasing)
            count = Math.Max(count, DFS(nums, cur+1, cur, memo)+1);

        memo[cur, prev+1] = count;
        return count;
    }
}