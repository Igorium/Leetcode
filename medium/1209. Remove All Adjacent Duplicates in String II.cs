public class Solution {
    public string RemoveDuplicates(string s, int k) {
        if(k == 1)
            return "";

        var st = new LinkedList<Symbol>();

        foreach(var c in s){
            var peek = st?.Last?.Value;

            if(peek == null || peek.Char != c){
                st.AddLast(new Symbol{ Char = c, Count = 1});
            } else if(++peek.Count == k){
                st.RemoveLast();
            }
        }

        var sb = new StringBuilder();
        foreach(var symbol in st){
            while(symbol.Count-- > 0)
                sb.Append(symbol.Char);
        }

        return sb.ToString();
    }

    private class Symbol{
        public char Char;
        public int Count;
    }
}