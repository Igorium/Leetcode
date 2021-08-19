public class Solution {
    /*
         1

    */
    public Node TreeToDoublyList(Node root) { // 4
        if(root == null)
            return null;

        var st = new Stack<Node>(); // 1

        void TraverseLeft(Node n){
            while(n != null){
                st.Push(n);
                n = n.left;
            }
        }
        
        TraverseLeft(root);
        var head = st.Peek(); // 1
        Node node = null; // 1

        while(st.Any()){ 
            var n = st.Pop(); // 5
            if(node == null){
                node = n; // 1
            } else {
                node.right = n; // 1 - 2 - 3 - 4 -5
                n.left = node; 
                node = n; // 5
            }

            if(n.right != null) // t
                TraverseLeft(n.right);
        }

        node.right = head; // 1-1
        head.left = node; // 1-1

        return head;
    }
}