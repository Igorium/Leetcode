public class Solution {
    public int MaxProfit(int[] inventory, int orders) {
        var n = inventory.Length;
        Array.Sort(inventory);
        long res = 0;
        long max = inventory[n-1];

        for(int i = n-2; i >= -1; i--){
            long cur = i != -1 ? inventory[i] : 0;

            if(cur == max)
                continue;

            long available = n-1-i;

            if(available * (max-cur) <= orders){
                orders -= (int)(available * (max-cur));
                res += ((max*max+max)/2 - (cur*cur+cur)/2)*available;
                max = cur;
            } else {
                while(max > cur && orders > 0){
                    var count = Math.Min(available, orders);
                    orders -= (int)count;

                    res += max * count;
                    max--;
                }
            }
        }

        return (int)(res % 1000000007);
    }
}