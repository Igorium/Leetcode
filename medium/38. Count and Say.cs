public class Solution {
    public string CountAndSay(int n) { // 4
        var num = "1";

        for(; n > 1; n--){ //true 1
            var count = 1;
            var prev = num[0]; // 1
            var sb = new StringBuilder();
            for(int i = 1; i < num.Length; i++){ // true
                var cur = num[i]; // 1
                if(cur != prev){
                    sb.Append(count.ToString()); // 111
                    sb.Append(prev); // 1112

                    count = 1; 
                    prev = cur; // 1
                } else {
                    count++;  // 2
                }
            }

            sb.Append(count.ToString()); // 11122
            sb.Append(prev); // 111221
            num = sb.ToString(); // 1211
        }

        return num;
    }
}