public class MinStack {

    

    private Stack<int> dataStack;

    private Stack<int> minStack;



    /** initialize your data structure here. */

    public MinStack() {

        dataStack = new Stack<int>();

        minStack = new Stack<int>();

    }

    

    public void Push(int x) {

        dataStack.Push(x);

        if (x <= getMin())

            minStack.Push(x);

    }

    

    public void Pop() {

        var x = dataStack.Pop();

        if (x == getMin())

            minStack.Pop();

    }

    

    public int Top() {

        return dataStack.Peek();

    }

    

    public int GetMin() {

        return minStack.Peek();

    }

    

    private int getMin()

    {

        return minStack.Count == 0 ? int.MaxValue : minStack.Peek();

    }

}

