public class Solution {
    public IList<int> PartitionLabels(string s) {
        var n = s.Length;
        var lastIdx = new int[26];
        for(int i = 0; i < n ; i++){
            lastIdx[s[i] - 'a'] = i;
        }
        var res = new List<int>();

        var start = -1;
        var end = 0;
        for(int i = 0; i < n; i++){
            end = Math.Max(end, lastIdx[s[i]-'a']);
            if(i == end){
                res.Add(end-start);
                start = end;
            }
        }

        return res;
    }
}