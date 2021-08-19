public class Solution {
    public string NumberToWords(int num) {
        if(num == 0)
            return "Zero";

        var ones = new string[] {"One","Two","Three","Four","Five","Six","Seven","Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        var tens = new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};

        IEnumerable<string> ReadTens(){
            var n1 = num % 10;
            var n2 = num % 100;

            if(n2 == 0)
                yield break;
            else if(n2 < 20)
                yield return ones[n2-1];
            else{
                if(n1 != 0)
                    yield return ones[n1-1];
                yield return tens[n2/10-2];
            }
        }

        var exp = new string[] {"Thousand", "Million", "Billion"};
        var count = 0;

        var res = new Stack<string>();

        while(num > 0){
            if(num % 1000 == 0){
                count++;
                num /= 1000;
                continue;
            }

            if(count > 0)
                res.Push(exp[count-1]);
            count++;

            foreach(var str in ReadTens())
                res.Push(str);
            
            num /= 100;

            var n = num % 10;
            if(n > 0){
                res.Push("Hundred");
                res.Push(ones[n-1]);
            }

            num /= 10;
        }

        return string.Join(" ", res);
    }
}