public class Solution {
    public int Calculate(string s) {
        var n = s.Length;
        var num = 0;
        var nums = new Stack<int>();
        var ops = new Stack<char>();

        var precedence = new Dictionary<char, int>{
            {'+', 0},
            {'-', 0},
            {'*', 1},
            {'/', 1}
        };

        void calc(){
            var op = ops.Pop();
            if(op == '*')
                nums.Push(nums.Pop()*nums.Pop());
            else if(op == '/')
                nums.Push((int)(1.0/nums.Pop()*nums.Pop()));
            else if(op == '+')
                nums.Push(nums.Pop()+nums.Pop());
            else if(op == '-')
                nums.Push(-1*nums.Pop()+nums.Pop());
        }
        
        for(int i = 0; i < n; i++){
            var c = s[i];
            if(c >= '0' && c <= '9'){
                num *= 10;
                num += c - '0';
            } else if(c != ' '){
                nums.Push(num);
                //Console.WriteLine(num);
                num = 0;

                while(ops.Any() && precedence[ops.Peek()] >= precedence[c])
                    calc();

                ops.Push(c);
            }
        }
        
        nums.Push(num);
        //Console.WriteLine(num);
        while(ops.Any())
            calc();

        return nums.Pop();
    }
}