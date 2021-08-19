public class Solution {
    public string Multiply(string num1, string num2) {
        var n = num1.Length;
        var m = num2.Length;
        
        
        var res = new int[n+m];
        
        for(var i=n-1; i>=0; i--){
            for(var j = m-1; j>=0; j--){
                var mult = (num1[i]-'0') * (num2[j]-'0');
                var p1 = i+j;
                var p2 = p1+1;
                
                var sum = res[p2] + mult;
                
                res[p2] = sum % 10;
                res[p1] += sum / 10;                
            }
        }
        
        var pos = 0;
        
        while(res[pos] == 0){
            if (pos == res.Length-1)
                return "0";
            
            pos++;
        }
        
        
        
        return new String(res[pos..].Select(c => (char)(c+'0')).ToArray());

    }

}