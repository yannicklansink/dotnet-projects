namespace Dag9.IntList;
class Program
{
    static void Main(string[] args)
    {
        IntList list = new IntList(2);
        list.Add(5);
        list.Add(2);
        list.Add(7);
        list.Add(3);
        
        list.Add(11);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        
    }
}

