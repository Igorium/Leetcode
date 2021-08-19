public class Solution {
    public IList<string> RemoveComments(string[] source) {
        var res = new List<string>();
        var inBlock = false;
        StringBuilder sb = null;
        
        foreach(var l in source){
            if(!inBlock)
                sb = new StringBuilder();
            var n = l.Length;
            var starIndex = -1;
            
            for(int i=0; i < n; i++){
                if(!inBlock){
                    if(l[i] == '/' && i < n-1){
                        if(l[i+1]=='/')
                            break;
                        else if(l[i+1]=='*'){
                            inBlock = true;
                            starIndex = i+1;
                        } else {
                            sb.Append(l[i]);
                        }
                    } else {
                        sb.Append(l[i]);
                    }
                } else if(i > 0 && l[i] == '/' && l[i-1] == '*' && i-1 != starIndex) { // /*/ - not valid end of block
                    inBlock = false;
                }
            }
            
            if(!inBlock && sb.Length > 0)
                res.Add(sb.ToString());
        }
        
        return res;
    }
}