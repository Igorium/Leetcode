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
        var trie = Trie;

        foreach(var c in str){
            if(trie.Children[Idx(c)] == null)
                trie.Children[Idx(c)] = new TrieNode();

            trie = trie.Children[Idx(c)];
        }

        trie.Sentence = str;
        trie.Frq += frq;
    }

    public IList<string> Input(char c) {
        var res = new List<string>();
        if(c == '#'){
            var str = sb.ToString();
            AddSentence(str, 1);
            Reset();
            return res;
        }

        sb.Append(c);

        if(Current == null || Current.Children[Idx(c)] == null){
            Current = null;
            return res;
        }

        Current = Current.Children[Idx(c)];

        var heap = new Heap(3);
        var q = new Queue<TrieNode>();
        q.Enqueue(Current);
        while(q.Any()){
            var node = q.Dequeue();
            if(node.Sentence != null)
                heap.Add(node.Sentence, node.Frq);
            foreach(var child in node.Children.Where(n => n != null))
                q.Enqueue(child);
        }

        return heap.Take();
    }

    class TrieNode{
        public TrieNode[] Children = new TrieNode[27];
        public string Sentence;
        public int Frq;
    }

    class Heap{
        SortedDictionary<int, SortedSet<string>> map = new SortedDictionary<int, SortedSet<string>>();
        int capacity;

        public Heap(int cap){
            capacity = cap;
        }

        public void Add(string str, int frq){
            if(map.Count == capacity){
                var smallest = map.First();
                if(smallest.Key > frq)
                    return;
                
                if(smallest.Key != frq)
                    map.Remove(smallest.Key);
            }

            if(map.ContainsKey(frq))
                map[frq].Add(str);
            else
                map[frq] = new SortedSet<string>{str};
        }

        public List<string> Take(){
            var top = new List<string>();

            foreach(var bucket in map.Reverse()){
                foreach(var s in bucket.Value){
                    top.Add(s);
                    if(top.Count == capacity)
                        return top;
                }
            }

            return top;
        }
    }
}
