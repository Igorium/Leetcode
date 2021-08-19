public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if(nums1.Length > nums2.Length)
            return Intersect(nums2, nums1);

        Dictionary<int, int> toMap(int[] nums){
            var map = new Dictionary<int, int>();
            foreach(var n in nums){
                if(map.ContainsKey(n))
                    map[n]++;
                else 
                    map[n] = 1;
            }
            return map;
        }

        var map1 = toMap(nums1);
        var map2 = toMap(nums2);
        var res = new List<int>();
        foreach(var kv in map1){
            if(map2.TryGetValue(kv.Key, out var count))
                res.AddRange(Enumerable.Repeat(kv.Key, Math.Min(kv.Value, count)));
        }

        return res.ToArray();
    }
}