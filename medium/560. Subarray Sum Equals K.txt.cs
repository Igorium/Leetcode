public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var runingSum = new Dictionary<int,int>();

        var sum = 0;
        var result = 0;
        
        for(var i = 0; i < nums.Length; i++){
            sum += nums[i];            
            if (sum == k)
                result++;
            
            if (runingSum.TryGetValue(sum-k, out var count)){
                result += count;
            }  
            
            if (runingSum.ContainsKey(sum)){
                runingSum[sum]++;
            } else{
                runingSum[sum] = 1;
            }         
        }
 

        return result;
    }
}