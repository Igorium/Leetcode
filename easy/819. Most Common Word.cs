public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        var maxCount = 0;
        string res = null;
        var frq = new Dictionary<string, int>();
        var bannedSet = new HashSet<string>(banned);

        foreach(var w in paragraph.Split(" !?',;.".ToCharArray())){
            if(string.IsNullOrEmpty(w))
                continue;

            var word = w.ToLower();
            if(frq.ContainsKey(word))
                frq[word]++;
            else
                frq[word] = 1;

            if(!banned.Contains(word) && frq[word] > maxCount){
                maxCount = frq[word];
                res = word;
            }
        }

        return res;
    }
}