public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var res = new int[nums.Length-k+1];
        var dq = new LinkedList<int>();

        for(int i = 0; i < nums.Length; i++){
            var n = nums[i];

            // remove max if it out of window 
            if(dq.Any() && dq.First.Value == i-k)
                dq.RemoveFirst();

            // keep decreasing order of the dequeue
            while(dq.Any() && nums[dq.Last.Value] <= n)
                dq.RemoveLast();

            dq.AddLast(i);

            if(i-k+1 >= 0)
                res[i-k+1] = nums[dq.First.Value];
        }

        return res;
    }
}