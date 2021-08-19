public class Solution {
    public int NumMatchingSubseq(string S, string[] words) {
        var res = 0;
        var n = words.Length;
        var buckets = new List<Wrapper>[26];
        
        foreach(var word in words){
            var w = new Wrapper(word);
            var idx = w.Head - 'a';
            if(buckets[idx] == null)
                buckets[idx] = new List<Wrapper>(5000);

            buckets[idx].Add(w);
        }
        
        for(int i = 0; i < S.Length; i++){
            var idx = S[i]-'a';
            var bucket = buckets[idx];
            if(bucket == null || !bucket.Any())
                continue;
            
            var newBucket = new List<Wrapper>();
            foreach(var w in bucket){
                w.ptr += 1;
                if(w.Head == -1){
                    res++;
                    continue;
                }
                if(w.Head == S[i])
                    newBucket.Add(w);
                else{
                    if(buckets[w.Head - 'a'] == null)
                        buckets[w.Head - 'a'] = new List<Wrapper>(5000);
                    buckets[w.Head - 'a'].Add(w);
                }
            }
            buckets[idx] = newBucket;
        }
        
        return res;
    }
    
    class Wrapper{
        string s;
        public int ptr;
        
        public Wrapper(string s){
            this.s = s;
        }
        
        public int Head => ptr < s.Length ? s[ptr] : -1;
    }
}