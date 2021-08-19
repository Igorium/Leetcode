public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var count = tasks.Length;
        var frq = new int[26];

        var max = 0;
        var maxCount = 1;
        for(int i = 0; i < count; i++){
            var idx = tasks[i]-'A';
            frq[idx]++; 

            if(frq[idx] > max){
                max = frq[idx];
                maxCount = 1;
            } else if(frq[idx] == max){
                maxCount++;
            }
        }
        
        var minStepsToScheduleMax = (max-1)*(n+1);

        /*
        n+1 cols
        xxxxxx max-1 rows
        xxxxxx
        xxxxxx
        x appendix number of max frqs
        */
        
        return Math.Max(count, minStepsToScheduleMax+maxCount);
    }
}