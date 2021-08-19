public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        var map = new Dictionary<int, int>{{0, -1}};
        var sum = 0;
        for(int i = 0; i< nums.Length; i++){
            sum += nums[i];

            if(k != 0){
                var mod = (sum % k);

                if(map.ContainsKey(mod)){
                    if(i - map[mod] >= 2)
                        return true;
                }
                else{
                    map.Add(mod, i);
                }
            } else {
                if(i > 0 && nums[i] == 0 && nums[i-1] == nums[i])
                    return true;
            }
        }

        return false;
    }
}