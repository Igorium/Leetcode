/**
 * // This is BinaryMatrix's API interface.
 * // You should not implement it, or speculate about its implementation
 * class BinaryMatrix {
 *     public int Get(int row, int col) {}
 *     public IList<int> Dimensions() {}
 * }
 */

class Solution {
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) {
        var mat = binaryMatrix;
        var rows = mat.Dimensions()[0];
        var cols = mat.Dimensions()[1];
        
        var row = 0;
        var col = cols-1;
        
        while(row < rows){
            while(col >= 0 && mat.Get(row, col) == 1){
                if (col-- == 0)
                    break;
            }
            row++;
        }
        
        return col == cols-1 ? -1 : col+1;
    }
}