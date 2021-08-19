public class Solution {
    int[] nums;
    Random r = new Random();

    public Solution(int[] nums) {
        this.nums =  nums;
    }
    
    public int Pick(int target) {
        var idx = 0;
        var count = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == target){
                if(r.Next(0, ++count))
                    idx = i;
            }
        }
        return idx;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */


/*
public class Solution {
    Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
    Random r = new Random();

    public Solution(int[] nums) {
        for(int i = 0; i < nums.Length; i++){
            if(!map.ContainsKey(nums[i]))
                map[nums[i]] = new List<int>();

            map[nums[i]].Add(i);
        }
    }
    
    public int Pick(int target) {
        var list = map[target];
        var idx = r.Next(0, list.Count);
        return list[idx];
    }
}
*/
