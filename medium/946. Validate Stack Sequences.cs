public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        var ptr = 0;
        var n = pushed.Length;
        var stack = new Stack<int>();
        
        foreach(var pu in pushed){
            stack.Push(pu);
            
            while(stack.Any() && ptr < n && stack.Peek() == popped[ptr]){
                stack.Pop();
                ptr++;
            }
        }
        
        return !stack.Any();
    }
}