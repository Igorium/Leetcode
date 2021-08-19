public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var n = intervals.Length;
        if(n < 2)
            return n;

        Array.Sort(intervals, new CompareStart());
        var rooms = new SortedSet<(int, int)>(new CompareEnd());

        for(int i=0; i <n ; i++){
            var meet = intervals[i];
            if(rooms.Any()){
                var room = rooms.First();
                var isFree = room.Item1 <= meet[0];
                //Console.WriteLine(room.Item1 + " " + meet[0] + " " + isFree);
                if(isFree)
                    rooms.Remove(room);
            }
            rooms.Add((meet[1], i));
        }

        return rooms.Count;
    }

    class CompareStart : IComparer<int[]>{
        public int Compare(int[] a, int[] b){
            return a[0]-b[0];
        }
    }

    class CompareEnd : IComparer<(int, int)>{
        public int Compare((int, int) a, (int, int) b){
            var dif = a.Item1 - b.Item1;
            return dif != 0 ? dif : a.Item2-b.Item2;
        }
    }
}