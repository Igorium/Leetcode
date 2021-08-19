public class Solution {
    public int[] AsteroidCollision(int[] a) {
        var n = a.Length;
        if(n < 2)
            return a;

        var res = new List<int>();
        var st = new Stack<int>();
        for(int i=0; i < n;){
            var v = a[i];
            if(v < 0){
                if(!st.Any() || st.Peek() < -1*v){
                    if(st.Any())
                        st.Pop(); // positive destroyed
                    else
                    {
                        res.Add(v); // no collision
                        i++;
                    }
                } else {
                    if(st.Peek() == -1*v) // both destroyed
                        st.Pop();
                    i++;
                }
            } else{
                st.Push(v);
                i++;
            }
        }

        foreach(var v in st.Reverse())
            res.Add(v);

        return res.ToArray();
    }
}