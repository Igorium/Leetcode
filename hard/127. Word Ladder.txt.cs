public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var graph = new Dictionary<string, HashSet<string>>();
        var wl = wordList;
        var len = wl[0].Length;
        
        bool isNext(string a, string b){
            var count = 0;
            for(var c = 0; c < len && count < 2; c++){
                if(a[c] != b[c])
                    count++;
            }
            return count==1;
        }

        var hasEnd = false;
        
        for(var i = -1; i< wl.Count; i++){
            var word = i == -1 ? beginWord : wl[i];
            var node = graph[word] = new HashSet<string>();

            hasEnd = hasEnd || word == endWord;
            
            for(var j = 0; j < wl.Count; j++){
                if(isNext(word,wl[j]))
                    node.Add(wl[j]);
            }
        }

        if(!hasEnd || beginWord == endWord)
            return 0;
        
        var min = int.MaxValue;
        var step = 1;
        var q = new Queue<string>();
        var visited = new HashSet<string>{beginWord};
        q.Enqueue(beginWord);
        
        while(q.Count > 0 ){
            for(var i = q.Count; i > 0; i--){
                var w = q.Dequeue();

                if(w == endWord){
                    min = Math.Min(min, step);
                    continue;
                }

                foreach(var child in graph[w]){
                    if(!visited.Contains(child)){
                        q.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }
            step++;
        }
        
        return min == int.MaxValue ? 0 : min;
    }
}