using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int N) {
        var max = 0;
        var cur = 0;
        var startCount = false;

        for(int i = 30; i >=0; i--){
            var exponent = 1 << i;
            if(N >= exponent){
                max = Math.Max(max, cur);
                N -= exponent;
                cur = 0;
                startCount = true;
            } else if(startCount){
                cur++;
            }
        }

        return max;
    }
}