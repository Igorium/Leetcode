public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        var res = new int[n];
        res[0] = nums[0];
        
        for(int i = 1; i < n; i++){
            res[i] = res[i-1] * nums[i]; 
        }

        var product = 1;
        for(int i = n - 2; i >= 0; i--){
            res[i+1] = res[i]*product;
            product *= nums[i+1];
        }

        res[0] = product;
        return res;
    }
}