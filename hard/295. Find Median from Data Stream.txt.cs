public class MedianFinder {

    SortedDictionary<int, int> lo;
    SortedDictionary<int, int> hi;
    int countLo;
    int countHi;

    public MedianFinder() {
        lo = new SortedDictionary<int, int>();
        hi = new SortedDictionary<int, int>(new DescComparer());
    }
    
    public void AddNum(int num) {
        Add(lo, num, ref countLo);
        var top = RemoveTop(lo, ref countLo);
        Add(hi, top, ref countHi);

        while(countHi > countLo){
            top = RemoveTop(hi, ref countHi);
            Add(lo, top, ref countLo);
        }
    }
    
    public double FindMedian() {
        var isOdd = (countLo+countHi)%2 == 1;
        return isOdd 
            ? lo.First().Key
            : ((double)lo.First().Key + hi.First().Key) / 2;
    }

    private void Add(SortedDictionary<int, int> d, int num, ref int count){
        if(d.ContainsKey(num))
            d[num] += 1;
        else
            d[num] = 1;

        count++;
    }

    private int RemoveTop(SortedDictionary<int, int> d, ref int count){
        var top = d.First();
        if(top.Value == 1)
            d.Remove(top.Key);
        else
            d[top.Key] -= 1;

        count--;
        return top.Key;
    }

    class DescComparer : IComparer<int>{
        public int Compare(int a, int b) {
            return b-a;
        }
    }
}