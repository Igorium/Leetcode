public class Solution {
    public string BreakPalindrome(string palindrome) {
        if(palindrome == null || palindrome.Length <=1)
            return "";

        var sb = palindrome.ToCharArray();

        for(int i = 0; i < sb.Length/2; i++){
            if(sb[i] != 'a'){
                sb[i] = 'a';
                return new string(sb);
            }
        }

        sb[sb.Length-1] = 'b';
        return new string(sb);
    }
}