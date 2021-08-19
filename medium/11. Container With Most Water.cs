public class Solution {
    public int MaxArea(int[] height) {
        int l = 0, res = 0;
        var r = height.Length-1;
        while(l < r){
            res = Math.Max(res, Math.Min(height[l], height[r])*(r-l));
            if (height[l] > height[r])
                r--;
            else
                l++;
        }
        
        return res;
    }
}