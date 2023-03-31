using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Threading;

namespace Dag14.Oefening2AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\input-advent-of-code.txt";
            int highestScore = 0;

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    int currentScore = 0;
                    while (!streamReader.EndOfStream)
                    {
                        string stringLine = streamReader.ReadLine();
                        if (string.IsNullOrWhiteSpace(stringLine))
                        {
                            // end of count. witte regel hier
                            if (currentScore > highestScore)
                            {
                                highestScore = currentScore;
                            }
                            currentScore = 0;
                            continue;
                            //comment
                            //comment
                        }

                        int line = int.Parse(stringLine);
                        currentScore += line;
                    }
                }
                Console.WriteLine($"The highest score is: {highestScore}");
            }


        }
    }
}