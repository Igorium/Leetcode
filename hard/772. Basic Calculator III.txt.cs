public class Solution {
    public int Calculate(string s) {
        var n = s.Length;
        var nums = new Stack<int>();
        var ops = new Stack<char>();

        var precedence = new Dictionary<char, int>{
            {'+', 0},
            {'-', 0},
            {'*', 1},
            {'/', 1},
            {'(', -1}
        };

        void calc(){
            switch(ops.Pop()){
                case '*': nums.Push(nums.Pop()*nums.Pop()); break;
                case '/': nums.Push((int)(1.0/nums.Pop()*nums.Pop())); break;
                case '+': nums.Push(nums.Pop()+nums.Pop()); break;
                case '-': nums.Push(-1*nums.Pop()+nums.Pop()); break;
            }
        }
        
        for(int i = 0; i < n; i++){
            var c = s[i];
            if(c >= '0' && c <= '9'){
                var num = c - '0';
                while(i+1 < n && s[i+1] >= '0' && s[i+1] <= '9'){
                    num *= 10;
                    num += s[i+1] - '0';
                    i++;
                }
                //Console.WriteLine(num);
                nums.Push(num);
            } else if(c == '('){
                ops.Push(c);
            } else if(c == ')'){
                while(ops.Peek() != '(')
                    calc();
                ops.Pop();
            } else if (c != ' '){
                while(ops.Any() && precedence[ops.Peek()] >= precedence[c])
                    calc();
                ops.Push(c);
            }
        }

        while(ops.Any())
            calc();

        return nums.Pop();
    }
}