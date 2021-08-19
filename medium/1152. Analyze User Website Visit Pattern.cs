public class Solution {
	public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website) {
            int len = username.Length;
            string[] orderedSites = website.Distinct().OrderBy(x => x).ToArray();
            int n = orderedSites.Length;
            Dictionary<string, int> siteOrder = new Dictionary<string, int>();
            for (int i = 0; i < n; i++) {
                siteOrder[orderedSites[i]] = i;
            }
            Dictionary<string, List<Tuple<int, int>>> dict = new Dictionary<string, List<Tuple<int, int>>>();
            for (int i = 0; i < len; i++) {
                if (!dict.ContainsKey(username[i])) {
                    dict[username[i]] = new List<Tuple<int, int>>();
                }
                dict[username[i]].Add(new Tuple<int, int>(timestamp[i], siteOrder[website[i]]));
            }
            int[] tab = new int[n * n * n];
            foreach (string key in dict.Keys) {
                int[] temp = dict[key].OrderBy(x => x.Item1).Select(x => x.Item2).ToArray();
                HashSet<int> visited = new HashSet<int>();
                for (int i = 0; i < temp.Length; i++) {
                    for(int j = i + 1; j < temp.Length; j++) {
                        for(int k = j + 1; k < temp.Length; k++) {
                            int t = ((temp[i] * n) + temp[j]) * n + temp[k];
                            if (!visited.Contains(t)) {
                                tab[t]++;
                                visited.Add(t);
                            }
                        }
                    }
                }
            }
            int max = 0;
            int res = 0;
            for (int i = 0; i < tab.Length; i++) {
                if (tab[i] > max) {
                    res = i;
                    max = tab[i];
                }
            }
            return new List<string> { orderedSites[res / (n * n)], orderedSites[(res % (n * n)) / n], orderedSites[res % n] };
        }
}