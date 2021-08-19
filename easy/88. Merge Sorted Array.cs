public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var n1 = m-1;
        var n2 = n-1;
        var i = nums1.Length-1;
        
        while(n1 >= 0 && n2 >= 0){
            if(nums1[n1] > nums2[n2]){
                nums1[i]=nums1[n1];
                n1--;                
            } else{
                nums1[i] = nums2[n2];
                n2--;
            }            
            i--;
        }
        
        while(n2 >= 0){
            nums1[i] = nums2[n2];
            n2--;
            i--;
        }
    }
}