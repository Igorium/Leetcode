public class Solution {
    public int MaxDistToClosest(int[] seats) {

        var max = -1;
        var firstOccupied = -1;
        var lastOccupied = -1;
        
        var i = 0;
        while(i < seats.Length){
            
            if(seats[i] == 1){
                if (firstOccupied == -1)
                    firstOccupied = i;
                
                lastOccupied = i;
            }
            
            var counter = 0;
            while(i < seats.Length && seats[i] == 0){
                counter++;
                i++;
            }
            
            if(counter > 0 && counter > max)
                max = counter;
            
            if(counter == 0)
                i++;
        }
        
        return Math.Max((int)Math.Floor((max+1)/2.0), Math.Max(firstOccupied, seats.Length-1-lastOccupied));
        
    }
}