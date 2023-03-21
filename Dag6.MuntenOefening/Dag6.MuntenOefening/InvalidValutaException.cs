namespace Dag6.MuntenOefening;

public class InvalidValutaException : Exception
{
    public InvalidValutaException() {  }

    public InvalidValutaException(string name) : base("Ongeldige munt soort")
    {

    }
    
}