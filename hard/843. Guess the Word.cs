/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
class Solution {
    public void FindSecretWord(string[] wordlist, Master master) {
        
        var attempts = 10;
        var wl = wordlist;
        var left = wl.Length;
        
        while(attempts > 0 && left > 1){
            var frq = new int[6,26];
            
            foreach(var w in wl){
                if(w == null)
                    continue;
                
                for(int i = 0; i < 6; i++){
                    frq[i, w[i]-'a'] += 1;
                }
            }
            
            string guess = null;
            var best = -1;
            
            foreach(var w in wl){
                if(w == null)
                    continue;
                
                var score = 0;
                for(int i = 0; i < 6; i++){
                    score += frq[i, w[i]-'a'];
                }
                if(score > best){
                    guess = w;
                    best = score;
                }
            }
            
            var match = master.Guess(guess);
            
            for(var j = 0; j < wl.Length; j++){
                var w = wl[j];
                
                if(w == null)
                    continue;
                
                var m = 0;
                for(int i = 0; i < 6; i++){
                    if (w[i] == guess[i])
                        m++;
                }
                
                if(m != match)
                    wl[j] = null;
                else
                    left++;
            }
            
            attempts--;
        }
    }
}