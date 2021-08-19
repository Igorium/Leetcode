public class Solution {
    public int CountSubstrings(string s) {
			var palindroms = 0;
			var fraim = 0;

			while (fraim <= s.Length)
			{
				for (int i = fraim; i < s.Length; i++)
				{
					var end = i;
					var start = i - fraim;

					while (start <= end && s[start] == s[end])
					{
						start++;
						end--;
					}

					if (start >= end)
						palindroms++;
				}

				fraim++;
			}

			return palindroms;
		}
}