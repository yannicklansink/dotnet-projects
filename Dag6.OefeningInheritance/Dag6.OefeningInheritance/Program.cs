﻿namespace Dag6.OefeningInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Betaalkaart VIPBetaalkaart = new VIPKaarten("Marcooooo", 1000000m, 12.5m);
            VIPBetaalkaart.Saldo = 10000m;
            Console.WriteLine(VIPBetaalkaart);   
            
        }
    }
}