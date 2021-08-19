public class Solution {
    public string AddBinary(string a, string b) {
        var idxa = a.Length-1;
        var idxb = b.Length-1;
        var sb = new List<char>();
        var carry = 0;
        while(idxa >=0 || idxb >=0){
            var sum = carry;
            if(idxa >= 0)
                sum += a[idxa--]-'0';
            if(idxb >= 0)
                sum += b[idxb--]-'0';
            sb.Add((char)((sum % 2)+'0'));
            carry = sum / 2;
        }

        if(carry == 1)
            sb.Add((char)(carry+'0'));

        sb.Reverse();
        return new String(sb.ToArray());
    }
}
