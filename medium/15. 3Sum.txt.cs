public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        for(int i = 0; i < nums.Length && nums[i] <= 0; i++){
            if (i == 0 || nums[i-1] != nums[i]){
                TwoSum(nums, i, res);
            }
        }
        
        return res;
    }
    
    public void TwoSum(int[] nums, int i, List<IList<int>> res) {
        var lo = i+1;
        var hi = nums.Length-1;
        
        while(lo < hi){          
            var sum = nums[i] + nums[lo] + nums[hi];
            if(sum > 0){
                hi--;
            } else if(sum < 0){
                lo++;
            } else{
                res.Add(new List<int>{nums[i], nums[lo++], nums[hi--]});
                while (lo < hi && nums[lo-1] == nums[lo]){
                    lo++;
                }
            }
        }
    }
}