public class Solution {
    public int FindMaxLength(int[] nums) {
        

			var equalSums = new Dictionary<int, int>();
			equalSums[0] = -1;
			int maxDistance = 0;
			int prev = 0;
			for(int i=0; i<nums.Length; i++){
				var v = nums[i] == 0 ? -1 : 1;
				var currentSum = prev + v;
				prev = currentSum;
            
				if (equalSums.TryGetValue(currentSum, out var firstIndexOccurance))
				{
					var distance = i-firstIndexOccurance;
					if (distance > maxDistance)
						maxDistance = distance;
				}
				else
				{
					equalSums[currentSum] = i;   
				}
			}
        
			return maxDistance;
    }
}