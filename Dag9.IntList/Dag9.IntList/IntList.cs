using System.Collections;

namespace Dag9.IntList;

public class IntList : IEnumerable
{
    private int[] _items;
    private int _count;

    public IntList(int listSize = 4)
    {
        _items = new int[listSize];
        _count = 0;
    }

    public int GetListSize()
    {
        return _items.Length;
    }

    public void Add(int item)
    { //       4              3
        if (_items.Length > _count)
        {
            _items[_count] = item;
            _count++;
        }
        else
        {
            ResizeList();
            _items[_count] = item;
            _count++;
        }
    }

    private void ResizeList()
    {
        int[] newItemsList = new int[_items.Length * 2];
        for (int i = 0; i < _items.Length; i++)
        {
            newItemsList[i] = _items[i];
        }
        Console.WriteLine("old length of _items: " + _items.Length);
        _items = newItemsList;
        Console.WriteLine("new length of _items: " + _items.Length);
    }
    
    public int this[int i]
    {
        get
        {
            CheckBoundsOfArray(i);
            return _items[i];
        }
        set
        {
            CheckBoundsOfArray(i);
            _items[i] = value;
        }
    }

    public void CheckBoundsOfArray(int i)
    {
        // if i is not filled in the array throw exception
        //  3   3
        if (i >= _count)
        {
            throw new IndexOutOfRangeException($"Er staat geen waarde op plek: {i} in de array");
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }
}