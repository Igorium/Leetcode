public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
        var addZero = !firstCall;
        firstCall = false;
        
        if(n == 0)
            return new List<string>{""};
        
        if(n == 1)
            return new List<string>{"0","1","8"};
        
        var prev = FindStrobogrammatic(n - 2);
        
        var list = new List<string>();
        
        foreach(var str in prev){
            if(addZero)
                list.Add($"0{str}0");
            list.Add($"1{str}1");
            list.Add($"6{str}9");
            list.Add($"8{str}8");
            list.Add($"9{str}6");
        }
            
        return list;
    }
    
    private bool firstCall = true;
}