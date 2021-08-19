public class Solution {

    // ["az","ba"],
    public IList<IList<string>> GroupStrings(string[] strings) {
        var map = new Dictionary<int, Dictionary<string, List<string>>>(); // [2][az[az]]

        foreach(var str in strings){ // ba
            var len = str.Length; //2
            if(!map.ContainsKey(len)){ // f
                map[len] = new Dictionary<string, List<string>>();
                map[len][str] = new List<string>{str};
                continue;
            }
            if(len == 1){ // f
                map[len].First().Value.Add(str);
                continue;
            }

            var newGroup = true;
            foreach(var group in map[len]){ // az[az ba]
                if(IsShifted(group.Key, str)){  // t
                    group.Value.Add(str); // 
                    newGroup = false;
                    break;
                }
            }

            if(newGroup) // f
                map[len][str] = new List<string>{str};
        }

        var res = new List<IList<string>>();
        foreach(var d in map.Values){
            foreach(var l in d.Values)
                res.Add(l);
        }

        return res;
    }

    bool IsShifted(string a, string b){ // az ba
        if(a[0] > b[0])
            return IsShifted(b, a);
        
        var shift = b[0] - a[0]; //1
        
        var sb = new char[a.Length];
        for(int i = 0; i < a.Length; i++){
            var shifted = (a[i] - 'a' + shift) % 26 + 'a'; //   
            if(b[i] != (char)shifted)
                return false;
        }
        return true;
    }
}