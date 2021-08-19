
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(k==1)
            return head;

        /*
        
        1-2-3-4 2
        2-1-4-3
        */

        ListNode prevSubHead = null;
        var subHead = head; // 1

        while(subHead != null){ // t
            var nextHead = subHead; // null
            for(int i = 0; i < k; i++){ // 1
                if(nextHead == null)
                    return head;
                nextHead = nextHead.next; 
            }

            // !!! list integrity
            ListNode prev = nextHead; // null
            var curr = subHead; // 3
            while(curr != null && curr != nextHead){  // t
                var t = curr.next; // null
                curr.next = prev; // 2 - 1 - | 4 - 3 - null
                prev = curr; // 3
                curr = t; // 4
            }

            if(prevSubHead == null){
                head = prev;
            } else{
                prevSubHead.next = prev;
            }

            prevSubHead = subHead;
            subHead = nextHead;  // 3
        }

        return head;
    }
}