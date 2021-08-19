public class Solution {
    public string AddStrings(string num1, string num2) {
        var l1 = num1.Length;
        var l2 = num2.Length;

        if(l1 < l2)
            return AddStrings(num2, num1);

        var res = new Stack<char>();
        var remainder = 0;
        for(int i = l1-1; i >= 0; i--){
            var n1 = num1[i]-'0';

            var idx = i + l2 - l1;
            var n2 = idx >= 0 ? num2[idx]-'0' : 0;

            var sum = n1+n2+remainder;
            remainder = sum/10;
            sum %= 10;
            
            res.Push((char)(sum + '0'));
        }
        
        if(remainder > 0)
            res.Push((char)(remainder+'0'));
        return new String(res.ToArray());
    }
}