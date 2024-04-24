namespace BinaryHeap.Interfaces;

public interface IHeap
{
    void PrintHeap();
    bool InsertNode(int value);
    void RemoveNode(int index);
    bool ChangeNode(int index, int newValue);
}