public class Solution {
    public int MaxSubArray(int[] nums) {
        var localSum = 0;
        var maxSum = int.MinValue;
        foreach(var n in nums){
            localSum += n;
            maxSum = Math.Max(localSum, maxSum);
            localSum = Math.Max(0, localSum);
        }
        return maxSum;
    }
}