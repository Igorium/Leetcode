public class Solution
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            var index = 0;
            return InsertValue(null, ref index, preorder);
        }

        public TreeNode InsertValue(int? max, ref int i, int[] arr)
        {
            if (i >= arr.Length || (max != null && arr[i] > max))
                return null;

            var node = new TreeNode(arr[i]);
            i += 1;

            node.left = InsertValue(arr[i-1], ref i, arr);
            node.right = InsertValue(max, ref i, arr);

            return node;
        }
    }