public class WordDictionary {
    Node trie = new Node();
    HashSet<string> set = new HashSet<string>();

    public WordDictionary() {
    }
    
    public void AddWord(string word) {
        var node = trie;
        foreach(var c in word){
            var idx = c - 'a';
            if(node.Children[idx] == null)
                node.Children[idx] = new Node();
            node = node.Children[idx];
        }
        node.IsWord = true;
        set.Add(word);
    }
    
    public bool Search(string word) {
        return set.Contains(word) || TryFind(trie, word, 0);
    }

    public bool TryFind(Node node, string w, int idx){
        if(node == null)
            return false;
        
        if(idx == w.Length)
            return node.IsWord;

        if(w[idx] != '.')
            return TryFind(node.Children[w[idx]-'a'], w, idx+1);

        foreach(var child in node.Children.Where(c => c != null)){
            if(TryFind(child, w, idx + 1))
                return true;
        }

        return false;
    }
}

public class Node{
    public Node[] Children = new Node[26];
    public bool IsWord;
}
