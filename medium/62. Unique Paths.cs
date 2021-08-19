public class Solution {
    public int UniquePaths(int m, int n) {
        int Fact(int a){
            return a == 0 ? 1 : a * Fact(a-1);
        }
        
        return Fact(n+m-2)/(Fact(n-1)*Fact(m-1)); // (n chose k combinations)
    }
}