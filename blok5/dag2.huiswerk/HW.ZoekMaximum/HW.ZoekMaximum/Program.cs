namespace HW.ZoekMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = new List<int> { 1, 22, 3, 4, 2, 18, 9, 12, 15, 5};

            if (numbersList.Count == 0)
            {
                Console.WriteLine("Empty list, returning -1");
                return;
            }

            int middleOfList = numbersList.Count / 2;

            MaxNumber findHighestNumber1 = new MaxNumber(numbersList, 0, middleOfList);
            MaxNumber findHighestNumber2 = new MaxNumber(numbersList, middleOfList, numbersList.Count);

            Thread thread1 = new Thread(findHighestNumber1.FindMax);
            Thread thread2 = new Thread(findHighestNumber2.FindMax);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            int maxIndex = findHighestNumber1.MaxIndex;
            if (findHighestNumber2.MaxValue > findHighestNumber1.MaxValue)
            {
                maxIndex = findHighestNumber2.MaxIndex;
                Console.WriteLine("Maximum value index is found in second thread: " + maxIndex);
            } else 
            {
                Console.WriteLine("Maximum value index is found in first thread: " + maxIndex);
                
            }

        }
    }
}