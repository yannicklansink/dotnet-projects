using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag11.PutItAllToghether
{
    public enum Drink
    {
        //koffie (1.90), au lait (+0.20)
        //thee (1,50)
        //Cola 2,50 (groot +1.00)
        //Sinas 2,50 (groot +1.00)
        //Cassis 3,00 (groot +1.00)
        //bier 3,50, tap (dubbel +1,00, triple +1.50)
        //bier 4,00, fles (dubbel +1,00, triple +1.50)
        //wijn rood, glas 5,00 (fles x5)
        //wijn rose, glas 4,00 (fles x5)
        //wijn rood, glas 4,50 (fles x5)

        // Casting from value to prijs:
        //      int prijsSinas = (int)Drink.Sinas;

        Koffie = 190,
        KoffieAuLait = 210,
        Thee = 150,

        Cola = 250,
        GroteCola = 350,
        Sinas = 250,
        GroteSinas = 350,
        Cassis = 300,
        GroteCassis = 400,

        BierTap = 350,
        DubbelBierTap = 450,
        TripleBierTap = 500,
        BierFles = 400,
        DubbelBierFles = 500,
        TripleBierFles = 550,

        WijnRoodGlas = 500,
        WijnRoodFles = 2500,
        WijnRoseGlas = 400,
        WijnRoseFles = 2000,
        WijnRoodGlasKlein = 450,
        WijnRoodFlesKlein = 2250,
    }
}
