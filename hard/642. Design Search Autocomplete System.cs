public class AutocompleteSystem {

    TrieNode Trie;
    TrieNode Current;
    private StringBuilder sb;

    public AutocompleteSystem(string[] sentences, int[] times) {
        Trie = new TrieNode();

        for(int i = 0; i < sentences.Length; i++){
            AddSentence(sentences[i], times[i]);
        }

        Reset();
    }

    private void Reset(){
        Current = Trie;
        sb = new StringBuilder();
    }

    private int Idx(char c){
        return c == ' ' ? 26 : c-'a';
    }

    private void AddSentence(string str, int frq){
        var t = Trie;
        t.Frq[str] = frq;

        foreach(var c in str){
            if(t.Children[Idx(c)] == null)
                t.Children[Idx(c)] = new TrieNode();

            t = t.Children[Idx(c)];
            t.AddSentence(str, frq);
        }

    }

    public IList<string> Input(char c) {
        var res = new List<string>();
        if(c == '#'){
            var str = sb.ToString();
            var frq = Trie.Frq.ContainsKey(str) ? Trie.Frq[str]+1 : 1;
            AddSentence(str, frq);
            Reset();
            return res;
        }

        sb.Append(c);

        if(Current == null || Current.Children[Idx(c)] == null){
            Current = null;
            return res;
        }

        Current = Current.Children[Idx(c)];

        foreach(var bucket in Current.Hot){
            foreach(var s in bucket.Value){
                res.Add(s);
                if(res.Count == 3)
                    return res;
            }
        }

        return res;
    }

    class TrieNode{
        public TrieNode[] Children = new TrieNode[27];
        public Dictionary<string, int> Frq = new Dictionary<string, int>();
        public SortedDictionary<int, SortedSet<string>> Hot = new SortedDictionary<int, SortedSet<string>>(new ReverseComparer());

        public void AddSentence(string str, int frq){
            // remove from prev bucket
            if(Frq.ContainsKey(str)){
                var bucket = Frq[str];
                Hot[bucket].Remove(str);
            }

            Frq[str] = frq;

            if(Hot.ContainsKey(frq))
                Hot[frq].Add(str);
            else
                Hot[frq] = new SortedSet<string>{ str };
        }
    }

    class ReverseComparer : IComparer<int>{
        public int Compare(int a, int b){
            return b-a;
        }
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */