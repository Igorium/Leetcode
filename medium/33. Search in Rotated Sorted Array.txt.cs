
/*
Let's say nums looks like this: [12, 13, 14, 15, 16, 17, 18, 19, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]

Because it's not fully sorted, we can't do normal binary search. But here comes the trick:

    If target is let's say 14, then we adjust nums to this, where "inf" means infinity:
    [12, 13, 14, 15, 16, 17, 18, 19, inf, inf, inf, inf, inf, inf, inf, inf, inf, inf, inf, inf]

    If target is let's say 7, then we adjust nums to this:
    [-inf, -inf, -inf, -inf, -inf, -inf, -inf, -inf, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]

    If nums[mid] and target are "on the same side" of nums[0], we just take nums[mid]. Otherwise we use -infinity or +infinity as needed.
*/

public class Solution {
    public int Search(int[] nums, int target) {
        var l = 0;
        var h = nums.Length-1;
        var sub = target < nums[0] ? int.MinValue : int.MaxValue;

        while(l <= h){            
            var mid = l + (h-l)/2;
            var midVal = nums[mid] < nums[0] == target < nums[0] 
                ? nums[mid] 
                : sub;

            if (midVal == target)
                return mid;          
            
            if (target > midVal)
                l = mid+1;
            else
                h = mid-1; 
        }
        
        return -1;
    }
}

public class Solution {
    public int Search(int[] nums, int target) {
        var l = 0;
        var h = nums.Length-1;
        while(l <= h){            
            var mid = l + (h-l)/2;
            var midVal = nums[mid];
            if (midVal == target)
                return mid;            
            
             if (target > midVal)
             {
                if (midVal <= nums[h] && target > nums[h]){
                    h = mid-1;                       
                } else {
                    l = mid+1;
                }
             }
            
            if (target < midVal)
             {
                if (midVal >= nums[l] && target < nums[l]){
                    l = mid+1;                   
                } else {
                    h = mid-1; 
                }
             }

        }
        
        return -1;
    }
}