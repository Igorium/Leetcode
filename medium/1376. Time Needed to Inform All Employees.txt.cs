public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        for(int i = 0; i < n; i++)
            if(informTime[i] > 0)
               calcManagerialLine(i, manager, informTime);
        
        return informTime.Max();
    }
    
    void calcManagerialLine(int id, int[] manager, int[] informTime){
        if(manager[id] != -1){
            calcManagerialLine(manager[id], manager, informTime);
            informTime[id] += informTime[manager[id]];
            manager[id] = -1;
        }
    }
}