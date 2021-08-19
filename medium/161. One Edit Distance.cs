public class Solution {
    /*
    a
    ac

    aa
    aaa

    aaaaaa
    aaabaaa

    aaabaaa
    aaaaaaa
    */
    public bool IsOneEditDistance(string s, string t) {
        var lenS = s.Length; // 3
        var lenT = t.Length; // 2

        if(lenS != lenT && Math.Abs(lenS - lenT) != 1)
            return false;

        var edited = false;
        var idxS = 0; // 1
        var idxT = 0; // 1
        while(idxS < lenS && idxT < lenT){ // t
            if(s[idxS] == t[idxT]){ // t
                idxS++;
                idxT++;
            } else {
                if(edited) // f
                    return false;

                edited = true;
                if(lenS <= lenT) // f
                    idxT++;
                if(lenT <= lenS) // t
                    idxS++;
            }
        }

        return edited && idxS == lenS && idxT == lenT || !edited && Math.Abs(lenS - lenT) == 1;
    }
}