public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var sb = new StringBuilder();
        if(strs.Length == 0)
            return "";

        var pos = 0;
        while(pos < strs[0].Length){
            var c = strs[0][pos];
            foreach(var str in strs){
                if(pos >= str.Length || str[pos] != c)
                    return sb.ToString();
            }
            sb.Append(c);
            pos++;
        }

        return sb.ToString();
    }
}