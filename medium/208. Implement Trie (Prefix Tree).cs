public class Trie {
    
    private Dictionary<char, Trie> Children = new Dictionary<char, Trie>();
    private bool EndOfWord = false;

    /** Initialize your data structure here. */
    public Trie() {
        
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        if(!string.IsNullOrEmpty(word))
            Insert(word.ToCharArray(), 0);
    }
    
    private void Insert(char[] word, int ptr){
        if(ptr == word.Length){
            EndOfWord = true;
            return;
        }        

        Trie child = null;
        
        if(!Children.TryGetValue(word[ptr], out child)){
            child = Children[word[ptr]] = new Trie();
        }
        
        child.Insert(word, ptr+1);
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        if(!string.IsNullOrEmpty(word))
            return Search(word.ToCharArray(), 0, true);
        
        return false;
    }
    
    private bool Search(char[] word, int ptr, bool checkEnd) {
        if(word.Length == ptr){
            return checkEnd ? EndOfWord : true;
        }
        
        if(Children.TryGetValue(word[ptr], out var child)){
            return child.Search(word, ptr+1, checkEnd);
        }
        
        return false;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        if(!string.IsNullOrEmpty(prefix))
            return Search(prefix.ToCharArray(), 0, false);        
        
        return false;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */