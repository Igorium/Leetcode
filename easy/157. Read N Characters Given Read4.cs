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

    // abcde
    public int Read(char[] buf, int n) { // [] 5
        var buf4 = new char[4];
        var idx = 0; // 5
        var len = 4; // 4

        while(n > idx && len == 4){ // true
            len = Read4(buf4); // 1
            for(int i = 0; i < len && n > idx; i++) // 1
                buf[idx++] = buf4[i];
        }

        return idx;
    }
}