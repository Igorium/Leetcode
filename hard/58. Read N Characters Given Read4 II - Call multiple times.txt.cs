/**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf4);
 */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
    
    private int buffPtr;
    private int buffCnt;
    private char[] buf4 = new char[4];
    private bool eof;
    
    public int Read(char[] buf, int n) {
        if (n <= 0 || eof)
            return 0;
        
        var ptr = 0;
        
        while(ptr < n){            
            if(buffCnt == 0){
                buffPtr = 0;
                buffCnt = Read4(buf4);
            }
            
            if(buffCnt == 0){
                eof = true;
                break;
            }
            
            while(buffCnt > 0 && ptr < n){
                buf[ptr++] = buf4[buffPtr++];
                buffCnt--;
            }
        }       
        
        return ptr;
    }

}