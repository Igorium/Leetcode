public class Solution {
    public bool CanTransform(string start, string end) {
        var n = start.Length;
        if (n != end.Length)
            return false;
        
        if(start.Count(c => c == 'R') != end.Count(c => c == 'R'))
            return false;
        if(start.Count(c => c == 'L') != end.Count(c => c == 'L'))
            return false;
        
        var s = 0;
        var e = 0;
        
        while(s < n){
            while(s < n && start[s] == 'X')
                s++;
            while(e < n && end[e] == 'X')
                e++;
            
            if(s == n || e == n)
                return e == s;
            
            if(start[s] != end[e] )
                return false;
            
            s++;
            e++;
        }
        
        return true;
    }
}