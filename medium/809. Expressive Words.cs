public class Solution {
    public int ExpressiveWords(string S, string[] words) {
       int count = 0;
        foreach(String originalWord in words){
            if(isStretchy(originalWord, S)){
                count ++;
            }
        }
        return count;
    }

    private bool isStretchy(String originalWord, String stretched){
        int i = 0, j = 0;
        while(i < originalWord.Length && j < stretched.Length){
			//Check Rule 1
            if(originalWord[i] != stretched[j]){
                return false;
            }
            
            int repeated1 = getRepeatedLength(originalWord, i);
            int repeated2 = getRepeatedLength(stretched, j);
            
            //Check Rule 2
            if((repeated1 >= repeated2 || repeated2 < 3) && repeated1 != repeated2){
                return false;
            }
            
            i += repeated1;
            j += repeated2;
        }
        
        //Check Rule 1
        return i == originalWord.Length && j == stretched.Length;
    }
    
    private int getRepeatedLength(String word, int start){
        int end = start;
        while (end < word.Length && word[end] == word[start]){
            end ++;
        }
        
        return end - start;
    }

}