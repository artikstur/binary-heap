using BinaryHeap.Interfaces;

namespace BinaryHeap;

public class HeapNode : IHeapNode
{
    private int _value;

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public HeapNode(int value)
    {
        _value = value;
    }

}