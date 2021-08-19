public class Solution {
    public int NumSubmat(int[][] mat) {
        int rows = mat.Length, cols = mat[0].Length;
        int res = 0;
        
        for (int up = 0; up < rows; ++up) {
                int[] h = Enumerable.Repeat(1, cols).ToArray();
                for (int down = up; down < rows; ++down) {
                    
                    for (int k = 0; k < cols; ++k) 
                        h[k] &= mat[down][k];
                    
                    var curr = countOneRow(h);
                    if(curr == 0)
                        break;
                    
                    res += countOneRow(h);
                }
            }

            return res;
        }

        private int countOneRow(int[] A) {
            int res = 0, length = 0;
            for (int i = 0; i < A.Length; ++i) {
                length = (A[i] == 0 ? 0 : length + 1);
                res += length;
            }
            return res;
        }
    }
