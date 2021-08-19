public class Solution {
    public int Compress(char[] chars) {
        var n = chars.Length;
        var w = 0;
        for(int r = 0; r < n; r++){
            var start = r;
            while(r < n-1 && chars[r+1] == chars[r])
                r++;
            
            chars[w++] = chars[r];
            
            if(r > start)
                foreach(var c in (r - start + 1).ToString())
                    chars[w++] = c;
        }
        return w;
    }
}