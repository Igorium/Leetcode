public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        var comparer = new AlienComparer(order);
        
        for(int i = 1; i < words.Length; i++){
            if(comparer.Compare(words[i-1], words[i]) > 0)
                return false;
        }

        return true;
    }

    public class AlienComparer: IComparer<string>{
        private Dictionary<char, int> order;

        public AlienComparer(string order){
            this.order = new Dictionary<char, int>();
            for(int i = 0; i < order.Length; i++)
                this.order[order[i]] = i;
        }

        public int Compare(string a, string b){
            var len = Math.Min(a.Length, b.Length);
            for(int i = 0; i < len; i++){
                var c1 = order[a[i]];
                var c2 = order[b[i]];
                if(c1 != c2)
                    return c1 - c2;
            }

            return a.Length-b.Length;
        }
    }
}