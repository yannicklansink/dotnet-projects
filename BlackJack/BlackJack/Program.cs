namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rank rank = (Rank)(0 % 13);
            Console.WriteLine(rank);
        }
    }
}