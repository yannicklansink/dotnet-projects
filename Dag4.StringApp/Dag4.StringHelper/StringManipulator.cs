using System.Text;

namespace Dag4.StringHelper;
public class StringManipulator
{

    // Opdracht 1: Vervangen van letters
    // oldChar = letter dat wordt vervangen
    // newChar = waar de letter in wordt vervangen
    // wordToChange = het woord dat wordt aangepast
    public string ChangeCharInString(string wordToChange, char oldChar, char newChar)
    {
        string newWord = "";
        foreach (char i in wordToChange)
        {
            if (i == oldChar)
            {
                newWord = newWord + newChar;
                continue;
            }
            newWord = newWord + i;
        }
        return newWord;
    }

    // Opdracht 2: Palindroomdetectie 
    public Boolean IsPalindroom(string wordToCheck)
    {
        string reverseWordToCheck = ReverseString(wordToCheck);
        
        if (wordToCheck.Equals(reverseWordToCheck))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public string ReverseString(string wordToCheck)
    {
        string reverseWordToCheck = "";
        for (int i = wordToCheck.Length - 1; i > -1; i--)
        {
            reverseWordToCheck += wordToCheck[i];
        }
        return reverseWordToCheck;
    }

    // opdracht 3: Palindroomdetectie ingewikkeld
    // "Er is daar nog onraad, Sire" => true
    public Boolean IsPalindroomDifficult(string wordToCheck)
    {
        string updatedWordToCheck = ClearSpecialCharactersFromString(wordToCheck);
        return IsPalindroom(updatedWordToCheck);
    }

    public string ClearSpecialCharactersFromString(string wordToChange)
    {

        StringBuilder sb = new StringBuilder(wordToChange);
             
        String specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
        
        for (int i = 0; i < wordToChange.Length; i++)
        {
            if (specialChar.Contains(wordToChange[i]))
            {
                Console.WriteLine("delete the char: " + sb[i]);
                sb.Remove(i, 1);
            }
        }
        wordToChange = sb.ToString();
        wordToChange = wordToChange.ToLower();
        wordToChange = String.Concat(wordToChange.Where(c => !Char.IsWhiteSpace(c)));

        return wordToChange;
    }


}

