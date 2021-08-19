public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        if(nums1.Length > nums2.Length)
            return Intersection(nums2, nums1);
        
        var set = new HashSet<int>(nums2);
        var res = new HashSet<int>();
        foreach(var n in nums1)
            if(set.Contains(n))
                res.Add(n);

        return res.ToArray();
    }
}