public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        var res = new List<string>();
        dfs(s, res, false, 0, 0);
        return res;
    }

    public static void dfs(String s, List<String> res, bool isReversed, int last_i, int last_j) {
        var check = isReversed ? new char[]{')', '('} : new char[]{'(', ')'};
        var count = 0;
        var i = last_i;
        for (; i < s.Length && count>= 0; i++) {
            if (s[i] == check[0]) count++;
            if (s[i] == check[1]) count--;
        }

        if (count >= 0)  {
            // no extra ')' is detected. We now have to detect extra '(' by reversing the string.
            var reversed = new String(s.Reverse().ToArray());
            if (!isReversed) 
                dfs(reversed, res, true, 0, 0);
            else 
                res.Add(reversed);
        }

        else {  // extra ')' is detected and we have to do something
            i -= 1; // 'i-1' is the index of abnormal ')' which makes count<0
            for (int j = last_j; j <= i; j++) {
                if (s[j] == check[1] && (j == last_j || s[j-1] != check[1])) {
                    dfs(s.Remove(j,1), res, isReversed, i, j);
                }
            }
        }
    }
}