public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if(nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);
        
        var l1 = nums1.Length;
        var l2 = nums2.Length;
        var len = (l1+l2+1)/2;
        
        var lo = 0;
        var hi = l1;
        
        while(lo <= hi){
            
            var mid1 = lo + (hi-lo)/2;
            var mid2 = len - mid1;
            
            var vLeft1 = mid1 == 0 ? int.MinValue : nums1[mid1-1];
            var vLeft2 = mid2 == 0 ? int.MinValue : nums2[mid2-1];
            
            var vRight1 = mid1 == l1 ? int.MaxValue : nums1[mid1];
            var vRight2 = mid2 == l2 ? int.MaxValue : nums2[mid2];
            
            if(vLeft1 <= vRight2 && vLeft2 <= vRight1){
                return (l1+l2) % 2 == 0
                    ? (Math.Max(vLeft1, vLeft2) + Math.Min(vRight1, vRight2)) / 2.0
                    : Math.Max(vLeft1, vLeft2);
            }
                
            if(vLeft1 > vRight2)
                hi = mid1-1;
            else
                lo = mid1+1;
            
        }
        
        return -1;
    }
}