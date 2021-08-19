public class Solution {
    public int Divide(int dividend, int divisor) {
        if(dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        uint a = dividend >= 0 ? (uint)dividend : (uint)(-(int)(dividend+1))+1;
        uint b = divisor >= 0 ? (uint)divisor : (uint)(-(int)(divisor+1))+1;
        var res = 0;

        for(int exp = 31; exp >= 0 && a >= b; exp--){
            if(a >> exp >= b){
                a -= b << exp;
                res += 1 << exp;
            }
        }

        return dividend > 0 == divisor > 0 ? res : -res;
    }
}