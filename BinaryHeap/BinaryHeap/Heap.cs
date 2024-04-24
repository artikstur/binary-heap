using BinaryHeap.Interfaces;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace BinaryHeap;

public class Heap : IHeap
{
    private HeapNode[] _nodes;
    private int _size;
    private int _currentSize;

    public Heap(int size)
    {
        this._size = size;
        this._currentSize = 0;
        _nodes = new HeapNode[_size];
    }
    public void PrintHeap()
    {
        Console.WriteLine("Массив значений: ");

        for (int n = 0; n < _currentSize; n++)
        {
            if (_nodes[n] != null)
            {
                Console.WriteLine(_nodes[n].Value + " ");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
        Console.WriteLine();

        int countOfGaps = 32;
        int itemsPerRow = 1;
        int columnNumber = 0;
        string lines = "___________________________________________________________________";
        Console.WriteLine(lines);
        for (int i = 0; i < _currentSize; i++)
        {
            if (columnNumber == 0)
            {
                for (int k = 0; k < countOfGaps; k++)
                {
                    Console.Write(' ');
                }
            }
            Console.Write(_nodes[i].Value);

            if (++columnNumber == itemsPerRow)
            {

                countOfGaps /= 2;
                itemsPerRow *= 2;
                columnNumber = 0;
                Console.WriteLine();
            }
            else
            {
                for (int k = 0; k < countOfGaps * 2 - 2; k++)
                {
                    Console.Write(' ');
                }
            }
        }
        Console.WriteLine("\n" + lines);
    }


    public bool InsertNode(int value)
    {
        if (_currentSize == _size)
        {
            return false;
        }

        HeapNode newNode = new HeapNode(value);
        _nodes[_currentSize] = newNode;
        RaiseNode(_currentSize++);

        return true;
    }

    public void RemoveNode(int removeIndex)
    {
        if (removeIndex > _size)
        {
            return;
        }
        _nodes[removeIndex] = _nodes[--_currentSize];
        _nodes[_currentSize] = null;
        LowerNode(removeIndex);
    }

    public bool ChangeNode(int index, int newValue)
    {
        if (index < 0 || _currentSize <= index)
        {
            return false;
        }

        int oldValue = _nodes[index].Value;
        _nodes[index].Value = newValue;

        if (oldValue < newValue) 
        {
            RaiseNode(index); 
        }
        else 
        {
            LowerNode(index); 
        }
        return true;
    }

    private void RaiseNode(int currentIndex)
    {
        int parentIndex = (currentIndex - 1) / 2;
        HeapNode bottom = _nodes[currentIndex];
        while (currentIndex > 0 && _nodes[parentIndex].Value < bottom.Value)
        {
            _nodes[currentIndex] = _nodes[parentIndex];
            currentIndex = parentIndex;
            parentIndex = (parentIndex - 1) / 2;
        }

        _nodes[currentIndex] = bottom;
    }

    private void LowerNode(int currentIndex)
    {
        HeapNode top = _nodes[currentIndex];
        while (currentIndex < _currentSize / 2) // элемент уже в самом низу пирамиды
        {
            int leftChild = 2 * currentIndex + 1;
            int rightChild = leftChild + 1;

            int largerChild;
            if (rightChild < _currentSize && _nodes[leftChild].Value < _nodes[rightChild].Value)
            {
                largerChild = rightChild;
            }
            else
            {
                largerChild = leftChild;
            }

            if (top.Value >= _nodes[largerChild].Value)
            {
                break;
            }

            _nodes[currentIndex] = _nodes[largerChild]; // заменяем вершину, большей дочерней вершиной
            currentIndex = largerChild; // текущий индекс переходит вниз
        }
        _nodes[currentIndex] = top;
    }
}