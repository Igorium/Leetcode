public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int calcLen(ListNode l){
            var len = 0;
            while(l != null){
                len++;
                l = l.next;
            }

            return len;
        }

        var len1 = calcLen(l1);
        var len2 = calcLen(l2);
        var res = new ListNode();

        int add(ListNode head, int dif, ListNode l1, ListNode l2){
            if(l1 == null)
                return 0;

            var sum = l1.val;
            head.next = new ListNode();

            if(dif <= 0){
                sum += l2.val;
                l2 = l2.next;
            }

            sum += add(head.next, --dif, l1.next, l2);
            head.next.val = sum%10;
            return sum/10;
        }
        
        var dif = Math.Abs(len1-len2);
        res.val = len1 > len2 ? add(res, dif, l1, l2) : add(res, dif, l2,l1);
        return res.val == 0 ? res.next : res; 
    }
}