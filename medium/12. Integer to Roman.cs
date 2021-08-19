public class Solution {

    // 1994
    // MCMXCIV
    public string IntToRoman(int num) { // 
        var values = new []{1000,900,500,400,100,90,50,40,10,9,5,4,1};
        var romans = new []{"M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};
        
        var sb = new StringBuilder(); 

        for(int i = 0; i < values.Length; i++){
            while(num >= values[i]){
                sb.Append(romans[i]);
                num -= values[i];
            }
        }

        return sb.ToString();
    }    
    
    public string IntToRoman(int num) { // 
        var sb = new StringBuilder(); // MCMXC
        var romans = new []{'M','D','C','L','X','V','I'};
        
        var limit = 10000; // 100
        var idx = -2; // 2 c
        while(limit > 1){
            var divisor = limit/10; // 10

            if(num >= limit-divisor){ // 90
                sb.Append(romans[idx+2]);
                sb.Append(romans[idx]);
                num -= limit-divisor; // 4
            }

            if(num >= limit/2){  // 500
                sb.Append(romans[idx+1]);
                num -= limit/2;
            }

            if(num >= limit/2 - divisor){
                sb.Append(romans[idx+2]);
                sb.Append(romans[idx+1]);
                num -= limit/2 - divisor;
            }

            if(num >= divisor){
                var count = num / divisor;
                for(int i = 0; i < count; i++)
                    sb.Append(romans[idx+2]);
                num -= divisor*count;
            }

            limit = divisor;
            idx += 2;
            
        }

        return sb.ToString();
    }
}