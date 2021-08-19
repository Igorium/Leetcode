public class Solution {
    public int[] SortArray(int[] nums) {
        //MergeSort(nums, new int[nums.Length], 0, nums.Length-1);
        QuickSort(nums, 0, nums.Length-1);
        return nums;
    }
    
    public void MergeSort(int[] nums, int[] helper, int lo, int hi) {
        if(lo < hi){
            var mid = lo + (hi-lo)/2;
            MergeSort(nums, helper, lo, mid);
            MergeSort(nums, helper, mid+1, hi);
            Merge(nums, helper, lo, hi, mid);
        }
    }
    
    public void Merge(int[] nums, int[] helper, int lo, int hi, int mid) {
        for(int i = lo; i<= hi; i++)
            helper[i] = nums[i];
        
        var loh = lo;
        var hih = mid+1;
        while(loh <= mid && hih <= hi){
            if(helper[loh] <= helper[hih])
                nums[lo++] = helper[loh++];
            else
                nums[lo++] = helper[hih++];
        }
        
        while(loh <= mid)
            nums[lo++] = helper[loh++];
    }
    
    /////////////////////////////////////////////////////
    
    public void QuickSort(int[] nums, int lo, int hi) {
        if(lo < hi){
            var mid = Partition(nums, lo, hi);
            QuickSort(nums, lo, mid - 1);
            QuickSort(nums, mid + 1, hi);
        }
    }
    
    public int Partition(int[] nums, int lo, int hi) {
        var pivot = nums[hi];
        
        for(int i = lo; i < hi; i++){
            if(nums[i] < pivot)
                Swap(nums, lo++, i);
        }
        
        Swap(nums, lo, hi);
        return lo;
    }
    
    public void Swap(int[] nums, int a, int b){
        var t = nums[a];
        nums[a] = nums[b];
        nums[b] = t;
    }
}