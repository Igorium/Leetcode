public class Solution {
    public int Reverse(int x) {
        long result = 0;
        var sign = x < 0 ? -1 : 1;
        x *= sign;
        
        while(x > 0){
            result *= 10;                        
            result += x % 10;
            x /= 10;    
            if (result > int.MaxValue)
                return 0;
        }
        
        return (int)result*sign;
    }
}