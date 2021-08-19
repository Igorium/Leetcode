public class Solution {
    public string StringShift(string s, int[][] shift) {
        var leftShifts = 0;
        var rightShifts = 0;
        
        foreach(var sh in shift){
            if(sh[0] == 0)
                leftShifts+=sh[1];
            else
                rightShifts+=sh[1];
            
        }
        
        if(rightShifts == leftShifts){
            return s;
        }
        
        var chars = string.Concat(s,s).ToCharArray();
        var totalShifts = 0;
        
        if(rightShifts > leftShifts){
            totalShifts = (rightShifts - leftShifts)%s.Length;            
            return new String(chars, chars.Length/2-totalShifts, s.Length);
        }
        
        totalShifts = (leftShifts - rightShifts)%s.Length;
        return new String(chars, totalShifts, s.Length);
        
    }
}