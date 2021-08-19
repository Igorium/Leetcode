public class Solution {
    public string AlphabetBoardPath(string target) {
        var sb = new List<char>();
        var x = 0;
        var y = 0;
        foreach(var c in target){
            var xt = (c - 'a') % 5;
            var yt = (c - 'a') / 5;
            while(y > yt){
                sb.Add('U');
                y--;
            }

            while(x > xt){
                sb.Add('L');
                x--;
            }
            while(x < xt){
                sb.Add('R');
                x++;
            }
            while(y < yt){
                sb.Add('D');
                y++;
            }
            sb.Add('!');
        }
        
        return new String(sb.ToArray());
    }
}