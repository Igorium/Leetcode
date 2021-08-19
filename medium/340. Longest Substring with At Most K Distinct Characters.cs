public class Solution {
    /*
    2
    aabaccc

    */
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if(k==0)
            return 0;

        int[] frq = new int[256];
        int count = 0;
        var lo = 0;
        var res = 0;
    
        for (int hi = 0; hi < s.Length; hi++) {
            if (frq[s[hi]]++ == 0)
                count++;
            
            if (count > k) {
                while (--frq[s[lo++]] > 0);
                    count--;
            }
            
            res = Math.Max(res, hi - lo + 1);
        }
    
        return res;
    }
}