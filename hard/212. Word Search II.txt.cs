public class Solution {
    
    private Trie Words;
    private char[][] Board;
    private HashSet<string> Result;
    private int LenR;
    private int LenC;
    private int MaxLen = -1;
    
    public IList<string> FindWords(char[][] board, string[] words) {
        Result = new HashSet<string>();
        
        if(board == null || board[0] == null || words == null || words.Length == 0)
            return Result.ToList();
        
        Board= board;
        LenC = board[0].Length;
        LenR = board.Length;
        
        Words = new Trie();
        foreach(var w in words){
            Words.Insert(w);
            if(w.Length > MaxLen)
                MaxLen = w.Length;
        }
        
        for(var i = 0; i < LenR; i++)
            for(var j =0; j < LenC; j++){
                FindWords(i, j, "");
                if(Result.Count == words.Length)
                    return Result.ToList();
            }
        
        return Result.ToList();
    }
    
    private void FindWords(int row, int col, string prefix){        
        var letter = Board[row][col];
        if(letter == '#')
            return;      
        
        prefix += letter.ToString();
        if(prefix.Length > MaxLen || !Words.StartsWith(prefix))
            return;
        
        if(Words.Search(prefix))
            Result.Add(prefix);
        
        Board[row][col] = '#'; 
        
        foreach((int r, int c) in GetAdjacent(row, col)){
            FindWords(r,c, prefix);
        }
        
        Board[row][col] = letter;
    }
    
    private ValueTuple<int, int>[] Sides = new ValueTuple<int, int>[]{
        (-1,0),
        (1,0),
        (0,-1),
        (0,1)
    };
    
    private IEnumerable<ValueTuple<int, int>> GetAdjacent(int row, int col){
        foreach((int r, int c) in Sides){
            var nRow = row+r;
            var nCol = col+c;
            
            if (nRow >= 0 && nRow < LenR && nCol >=0 && nCol < LenC)
                yield return (nRow, nCol);
        }
    }
    
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
}