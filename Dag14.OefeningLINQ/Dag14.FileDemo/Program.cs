namespace Dag14.FileDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // @ betekend: Je backslashes zijn geen escape characters, maar gewoon backslashes
            string filePath = @"..\..\..\notes.txt";
            //string filePathExample = "..\\..\\..\\notes.txt";

            // hier kijkt die niet naar backslash
            string filePath2 = Path.Combine("..", "..", "..", "notes.txt");

            // je kan ook notes.txt -> properties -> copy to output directory -> always copy.
            // Dit om de file naar de output folder te kopieren. 


            string[]  lines= File.ReadAllLines(filePath2);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}