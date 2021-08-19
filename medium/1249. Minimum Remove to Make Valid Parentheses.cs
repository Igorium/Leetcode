public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var n = s.Length;
        var st = new Stack<int>();
        var sb = new StringBuilder(s);

        for(int i = 0; i < n; i++){
            var c = sb[i];
            if(c == '('){
                st.Push(i);
            } else if(c == ')'){
                if(!st.Any())
                    sb[i] = '*';
                else
                    st.Pop();
            }
        }

        while(st.Any()){
            sb[st.Pop()] = '*';
        }

        sb.Replace("*", "");
        return sb.ToString();
    }
}