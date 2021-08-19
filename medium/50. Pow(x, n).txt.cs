public class Solution {
    public double MyPow(double x, int n) {
        var N = (long)n;
        if(N < 0){
            N *= -1;
            x = 1/x;
        }

        double fastPow(double x, long n){
            if(n == 0)
                return 1;
            var res = fastPow(x, n/2);
            res *= res;
            if(n % 2 == 1)
                res *= x;
            return res;
        }


        return fastPow(x, N);
    }
}