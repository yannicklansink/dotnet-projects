using System.Globalization;

namespace yannick_lansink_lessen_traineeship;
class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("nl-BE");
        Console.WriteLine(Math.Round(10.6542, 3));


        int[] nummers = new int[] { 2, 5, 6, 7 };
        foreach (int nummer in nummers)
        {
            Console.WriteLine(nummer);
        }

        // 1 blauwe piste:
        // array met de priemgetallen: 2, 3, 5, 7, 11, 13, 17
        // - afdrukken
        // - som van alle getallen afdrukken
        int sumOfArray = PrintSumOfArray();

        // 2 blauwe piste:
        // methode die het grootste getal uit een array teruggeeft. 

        // 3 rode piste:
        // maak een "array" met alle tafeluitkomsten




    }

    static int PrintSumOfArray(int[] array)
    {
        int totalValue = 0;
        foreach (int nummer in array)
        {
            totalValue = +nummer;
        }
        return totalValue;
    }

}

