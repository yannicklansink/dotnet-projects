using System.Globalization;

namespace yannick_lansink_lessen_traineeship;
class Program
{

    const int MIN_VALUE = -2147483648;
    
    

    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("nl-BE");
        //Console.WriteLine(Math.Round(10.6542, 3));
        int[] nummers = new int[] { 2, 3, 5, 7, 11, 13, 17 };
        


        // 1 blauwe piste:
        // array met de priemgetallen: 2, 3, 5, 7, 11, 13, 17
        // - afdrukken
        // - som van alle getallen afdrukken
        int sumOfArray = PrintSumOfArray(nummers);
        Console.WriteLine(sumOfArray);

        // 2 blauwe piste:
        // methode die het grootste getal uit een array teruggeeft.
        int highestValue = getHighestNumberOfArray(nummers);
        Console.WriteLine(highestValue);

        // 3 rode piste:
        // maak een "array" met alle tafeluitkomsten
        int[,] tableMultiplicationArrayOutcome = new int[7, 10];
        tableMultiplicationArrayOutcome = FillTableMultiplicationArray(nummers);





    }

    static int PrintSumOfArray(int[] array)
    {
        int totalValue = 0;
        foreach (int nummer in array)
        {
            totalValue += nummer;
        }
        return totalValue;
    }

    static int getHighestNumberOfArray(int[] array)
    {
        int highestValue = MIN_VALUE;
        for (int i = 0; i < array.Length; i++)
        {
            if (highestValue < array[i])
            {
                highestValue = array[i];
            }
        }
        return highestValue;
    }

    
    static int[,] FillTableMultiplicationArray(int[] array)
    {
        int[,] tableMultiplicationArrayOutcome = new int[7, 10];
        for (int arrayindex = 0; arrayindex < array.Length; arrayindex++)
        {
            for (int multiplication = 1; multiplication <= 10; multiplication++)
            {
                tableMultiplicationArrayOutcome[arrayindex, multiplication] = 
            }
        }
        return tableMultiplicationArrayOutcome;
    }

}

