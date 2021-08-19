public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var res = new List<IList<int>>();
        var n = nums.Length;

        void swap(int a, int b){
            if(a != b){                
                var t = nums[a];
                nums[a] = nums[b];
                nums[b] = t;
            }
        }

        void permute(int start){
            if(start == n)
                res.Add(new List<int>(nums)); // copy current !!!!
            else
                for(int i = start; i < n; i++){
                    swap(start, i);
                    permute(start+1);
                    swap(start, i);                       
                }
        }

        permute(0);
        return res;
    }
    
}