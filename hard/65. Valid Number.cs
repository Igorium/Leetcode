public class Solution {
    public bool IsNumber(string s) {
        if(s == null || s.Length == 0)
            return false;

        var sign = new State{ Symbols = new HashSet<char>{'-', '+'}};
        var digit = new State{ Symbols = new HashSet<char>{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}};
        var dot = new State{ Symbols = new HashSet<char>{'.'}};

        sign.Next = new List<State>{dot, digit};
        dot.Next = new List<State>{digit};
        digit.Next = new List<State>{dot, digit};

        var state = new State{Next = new List<State>{sign, digit, dot}};
        var isExpVisited = false;

        foreach(var c in s){
            if(c == 'E' || c == 'e'){
                if(isExpVisited || sign.Visited > 1 || dot.Visited > 1 || digit.Visited < 1)
                    return false;
                
                // reset state machine
                isExpVisited = true;
                sign.Visited = digit.Visited = 0;
                sign.Next = new List<State>{digit};
                digit.Next = new List<State>{digit};
                state = new State{Next = new List<State>{sign, digit}};
            } else{
                state = state.Next.FirstOrDefault(st => st.Symbols.Contains(c));
                if(state == null)
                    return false;
                state.Visited++;
            }
        }     

        return !(sign.Visited > 1 || dot.Visited > 1 || digit.Visited < 1);
    }
    
    class State{
        public HashSet<char> Symbols;
        public List<State> Next;
        public int Visited;
    }
}