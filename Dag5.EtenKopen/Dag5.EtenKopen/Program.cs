namespace Dag5.EtenKopen;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, To your bon!");
        
        Regel broodje = new Regel(4.73m, "broodje");
        Regel broodje2 = new Regel(7.73m, "broodje");

        Regel melk = new Regel(1.15m, "melk");

        Bon bon = new Bon();
        bon.ScanAll(broodje, broodje2, melk);
        bon.ToString();
        
        
    }
}

