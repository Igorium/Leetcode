public class Solution {
    public int ConfusingNumberII(int N) {
        var map = new long[]{0,1,6,8,9};
        
        var count = 0;
        
        void Calc(long curr){
            if(curr > 0){
                var rotated = 0L;
                var orig = curr;
                while(orig > 0){
                    var last = orig%10;
                    orig /= 10;
                    
                    rotated *= 10;
                    rotated += last == 9 ? 6 : last == 6 ? 9 : last;
                }
                
                if(rotated != curr)
                    count++;
            }
            
            foreach(var kv in map){
                var num = curr*10+kv;
                if(num <= N && num > 0)
                    Calc(num);
            }
        }
        
        Calc(0);
        return count;
    }
}