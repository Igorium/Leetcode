public class Solution {
    public int CompareVersion(string version1, string version2) {
        int i = 0, j = 0;
        int currentVersion1, currentVersion2;
        while(i < version1.Length || j < version2.Length) {
            currentVersion1 = 0;
            while(i < version1.Length && version1[i] != '.'){
                currentVersion1 = currentVersion1 * 10 + (version1[i] - '0');
                ++i;
            }
            
            currentVersion2 = 0;
            while(j < version2.Length && version2[j] != '.'){
                currentVersion2 = currentVersion2 * 10 + (version2[j] - '0');
                ++j;
            }
            
            if(currentVersion1 > currentVersion2)
                return 1;
            if(currentVersion2 > currentVersion1)
                return -1;
            ++i;
            ++j;
        }
        
        return 0;        

    }
}