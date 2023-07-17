namespace dag1.test
{
    internal class Program
    {

        public static void f(object? o)
        {
            if (o == null)
            {
                Console.WriteLine("returning function");
                return;
            }
            
            for (int x = (int)o; x < 100; x++)
            {
                Console.WriteLine(x);
            }
        }

        static void Main(string[] args)
        {
            Object lockobject = new Object();
            lock (lockobject)
            {
                // lock 
            }

            Thread thread = new Thread(f);
            //thread.Priority = ThreadPriority.Highest;
            thread.Start(100);
            f(100);

            Console.WriteLine("Einde main");
        }
    }
}