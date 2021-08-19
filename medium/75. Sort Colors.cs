public class Solution {
    public void SortColors(int[] nums) {
        var lo = 0;
        var hi = nums.Length-1;
        
        for(int i = 0; i < nums.Length; i++)
            if(nums[i] == 0)
                Swap(nums, lo++, i);
        
        for(int i = nums.Length-1; i >= lo; i--)
            if(nums[i] == 2)
                Swap(nums, i, hi--);
    }

    private void Swap(int[] nums, int a, int b){
        if(a == b)
            return;
        
        var t = nums[a];
        nums[a] = nums[b];
        nums[b] = t;
    }
}