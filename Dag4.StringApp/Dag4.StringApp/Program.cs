using Dag4.StringHelper;

namespace Dag4.StringApp;
class Program
{
    static void Main(string[] args)
    {
        // opdracht 1:
        StringManipulator sm = new StringManipulator();
        string wordToChange = "water";
        string changedWord = sm.ChangeCharInString(wordToChange, 'r', 'a');
        Console.WriteLine(changedWord);

        // opdracht 2:
        string palindroomWord = "lepel";
        Boolean isPalindroom = sm.IsPalindroom(palindroomWord);
        Console.WriteLine(isPalindroom);

        //opdracht 3:
        string complexPalindroomWord = "Er is daar nog onraad, Sire";
        Boolean isComplexPalindroom = sm.IsPalindroomDifficult(complexPalindroomWord);
        Console.WriteLine(isComplexPalindroom);



    }
}

