public class Solution {
    public string NextClosestTime(string time) {
        var nums = new int[]{
            time[0] - '0',
            time[1] - '0',
            time[3] - '0',
            time[4] - '0'
        };
        
        var tmins = (nums[0]*10+nums[1])*60+nums[2]*10+nums[3];
        
        var res = new int[4];
        var diff = int.MaxValue;
        
        foreach(var n1 in nums.Where(n => n < 3))
            foreach(var n2 in nums.Where(n => n1*10+n < 24))
                foreach(var n3 in nums.Where(n => n < 6))
                    foreach(var n4 in nums.Where(n => n3*10+n < 60)){
                        if (n1*10+n2 < 24 && n3*10+n4 < 60){
                            var mins = (n1*10+n2)*60+n3*10+n4;
                            if(mins <= tmins)
                                mins = mins + 60 * 24;
                            if(mins - tmins < diff){
                                res[0]=n1;
                                res[1]=n2;
                                res[2]=n3;
                                res[3]=n4;
                                diff = mins - tmins;
                            }
                        }
                    }
        
        return $"{res[0]}{res[1]}:{res[2]}{res[3]}";
    }
    
     static IEnumerable<ValueTuple<int,int,int,int>> DoPermute(int[] nums, int start, int end)
        {
            if (start == end)
            {
                yield return (nums[0], nums[1], nums[2], nums[3]);
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(ref nums[start], ref nums[i]);
                    foreach (var r in DoPermute(nums, start + 1, end))
                        yield return r;
                    Swap(ref nums[start], ref nums[i]);
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
}