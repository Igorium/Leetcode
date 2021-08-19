public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        if(S == "")
            return S;
        
        var replacements = new int[S.Length];
        
        for(int i = 0; i < indexes.Length; i++){
            var pos = indexes[i];
            var source = sources[i];
            
            var k = 0;
            while(k < source.Length && S[pos+k] == source[k])
                k++;
            
            if(k == source.Length){
                replacements[pos] = i+1;
                for(var j = 1; j < source.Length; j++)
                    replacements[pos+j] = -1;
            }
        }
        
        var sb = new StringBuilder();
        var ptr = 0;
        for(var i = 0; i < replacements.Length; i++){
            var idx = replacements[i];
            
            if(idx != -1){
                if (idx > 0){
                    foreach(var c in targets[idx-1])
                        sb.Append(c);
                } else {
                    sb.Append(S[ptr]);
                }
            }

            ptr++;
        }
        
        return sb.ToString();
    }
}