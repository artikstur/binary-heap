using BinaryHeap;

public class Program
{
    public static void Main()
    {
        Heap heap = new Heap(7);
        heap.InsertNode(4);
        heap.InsertNode(5);
        heap.InsertNode(6);
        heap.InsertNode(7);
        heap.InsertNode(8);
        heap.InsertNode(9);
        heap.InsertNode(10);
        heap.ChangeNode(2, 3);
        heap.PrintHeap();
        heap.RemoveNode(2);
        heap.PrintHeap();
    }
}