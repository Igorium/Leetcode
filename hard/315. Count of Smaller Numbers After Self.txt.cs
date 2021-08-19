public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        var n = nums.Length;
        var s = new List<int>(n);
        var res = new int[n];
        
        for(var i = n-1; i >= 0; i--){
            var num = nums[i];
            var last = s.Count-1;
        
            if(last == -1 || s[0] >= num){
                s.Insert(0, num);
                res[i] = 0;
                continue;
            }
        
            if(s[last] < num){
                res[i] = s.Count;
                s.Add(num);
                continue;
            }
            
            var lo = 0;
            var hi = last;
            while(lo < hi){
                var mid = lo + (hi-lo)/2;
                if(s[mid] >= num)
                    hi = mid;
                else
                    lo = mid + 1;
            }
            
            res[i] = lo;
            s.Insert(lo, num);
        }
        
        return res;
    }
}

// Binary index tree

public class Solution {
    public List<Integer> countSmaller(int[] nums) {
        List<Integer> res = new LinkedList<Integer>();
        if (nums == null || nums.length == 0) {
            return res;
        }
        // find min value and minus min by each elements, plus 1 to avoid 0 element
        int min = Integer.MAX_VALUE;
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < nums.length; i++) {
            min = (nums[i] < min) ? nums[i]:min;
        }
        int[] nums2 = new int[nums.length];
        for (int i = 0; i < nums.length; i++) {
            nums2[i] = nums[i] - min + 1;
            max = Math.max(nums2[i],max);
        }
        int[] tree = new int[max+1];
        for (int i = nums2.length-1; i >= 0; i--) {
            res.add(0,get(nums2[i]-1,tree));
            update(nums2[i],tree);
        }
        return res;
    }
    private int get(int i, int[] tree) {
        int num = 0;
        while (i > 0) {
            num +=tree[i];
            i -= i&(-i);
        }
        return num;
    }
    private void update(int i, int[] tree) {
        while (i < tree.length) {
            tree[i] ++;
            i += i & (-i);
        }
    }
}