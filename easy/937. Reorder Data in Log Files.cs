public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        return logs
            .Select(l => new Record(l))
            .OrderBy(r => r)
            .Select(r => r.Str)
            .ToArray();
    }

    class Record : IComparable<Record>{
        private bool isDigit;
        private string[] split;
        public string Str;

        public Record(string str){
            Str = str;
            split = str.Split(' ', 2);
            isDigit = split[1][0] <= '9';
        }

        public int CompareTo(Record other){
            if(isDigit)
                return other.isDigit ? 0 : 1;

            if(other.isDigit)
                return -1;

            var res = split[1].CompareTo(other.split[1]);
            return res == 0
                ? split[0].CompareTo(other.split[0])
                : res;
        }
    }
}