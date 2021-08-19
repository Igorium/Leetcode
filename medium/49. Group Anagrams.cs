public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        	var buckets = new Dictionary<string, List<string>>();
			foreach (var str in strs)
			{
				var charArray = str.ToCharArray();
				Array.Sort(charArray);
				var sortedStr = new string(charArray);

				if (!buckets.TryGetValue(sortedStr, out var val))
				{
					buckets[sortedStr] = new List<string>{str};
				}
				else
				{
					val.Add(str);
				}
			}

			IList<IList<string>> matrix = new List<IList<string>>();

			foreach (var bucket in buckets.Values)
			{
				matrix.Add(bucket);
			}

			return matrix;
    }
}