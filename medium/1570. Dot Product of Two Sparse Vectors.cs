public class SparseVector {

    Dictionary<int,int> v = new Dictionary<int, int>();
    
    public SparseVector(int[] nums) {
        for(var i = 0; i < nums.Length; i++){
            if(nums[i] != 0)
                v[i] = nums[i];
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        if(vec.v.Count < v.Count)
            return vec.DotProduct(this);

        var res = 0;
        foreach(var kv in v){
            if(vec.v.TryGetValue(kv.Key, out var val))
                res += val * kv.val;
        }

        return res;
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);