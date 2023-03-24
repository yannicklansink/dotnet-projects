namespace Dag9.IntList;
class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        list.Add(5);
        list.Add(2);
        list.Add(7);
        list.Add(3);
        list.Add(11);
        Print(list);
        
        Console.WriteLine();

        List<string> listString = new List<string>();
        listString.Add("heyooo");
        listString.Add("zalvoooo");
        Print(listString);
        
        Console.WriteLine();

        List<string> newArrayOfString = CreateArray<string>(5);
        newArrayOfString.Add("jallalaalaaaaaaa");
        Print(newArrayOfString);

    }

    public static void Print<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public static List<T> CreateArray<T>(int size)
    {
        List<T> listT = new List<T>(size);
        return listT;
    }
}

