public class Solution {
    public IList<string> LetterCombinations(string digits) {
        var arr = new []{
            new []{'a','b','c'},
            new []{'d','e','f'},
            new []{'g','h','i'},
            new []{'j','k','l'},
            new []{'m','n','o'},
            new []{'p','q','r','s'},
            new []{'t','u','v'},
            new []{'w','x','y','z'}
        };

        var res = new List<string>();
        
        for(int i = digits.Length-1; i >= 0; i--){
            var idx = digits[i] - '0' - 2;
            
            if(res.Count == 0){
                res = arr[idx].Select(c => c.ToString()).ToList();
                continue;
            }

            var newRes = new List<string>();

            foreach(var c in arr[idx]){
                for(int j = 0; j < res.Count; j++)
                    newRes.Add(c + res[j]);
            }

            res = newRes;
        }

        return res;
    }
}