public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var subsets = new List<IList<int>>();
        subsets.Add(new List<int>());

        // cascading - copy previous subsets 2^N 
        // []
        // []       [1]
        // [] [2]   [1, 2]
        for(int i = 0; i < nums.Length; i++){
            for(int j = subsets.Count-1; j >= 0; j--){
                var set = new List<int>(subsets[j]);
                set.Add(nums[i]);
                subsets.Add(set);
            }
        }

        return subsets;
    }


    // OR backtrack

    public IList<IList<int>> Subsets(int[] nums) {
        var res = new List<IList<int>>();
        for(int setSize = 0; setSize <= nums.Length; setSize++)
            BackTrack(nums, 0, setSize, new List<int>(), res);
        return res;
    }

    void BackTrack(int[] nums, int start, int setSize, List<int> currentSet, IList<IList<int>> res){
        if(currentSet.Count == setSize){
            res.Add(new List<int>(currentSet));
            return;
        }

        for(int i = start; i < nums.Length; i++){
            currentSet.Add(nums[i]);
            BackTrack(nums, i+1, setSize, currentSet, res);
            currentSet.RemoveAt(currentSet.Count-1);
        }
    }
}