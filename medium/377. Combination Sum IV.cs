public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        var n = nums.Length;

        int dfs(int sum, Dictionary<int, int> memo){
            if(sum > target)
                return 0;
            if(sum == target)
                return 1;

            int res = 0;
            if(memo.TryGetValue(sum, out res))
                return res;

            foreach(var num in nums)
                res += dfs(sum+num, memo);

            memo[sum] = res;
            return res;
        }

        return dfs(0, new Dictionary<int,int>());
    }
}