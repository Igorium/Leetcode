public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {       

        var res = new List<string>();
        var ptr = 0;
        
        if(nums.Length == 0){
            res.Add(CreateRange(lower, upper));
            return res;
        }
        
        while(lower <= upper && ptr < nums.Length){
            
            if(lower == nums[ptr]){
                lower++;
                ptr++;
            } else {
                res.Add(CreateRange(lower, nums[ptr]-1));
                lower = nums[ptr]; 
            }     
           
        }
        
        if (lower <= upper && ptr == nums.Length){
            res.Add(CreateRange(nums[nums.Length-1]+1, upper));
        }
        
        return res;
    }
    
    private string CreateRange(int lo, int hi){
        return hi == lo ? hi.ToString() : $"{lo}->{hi}";
    }
}