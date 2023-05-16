using cases.reisdocumenten.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Controller
{
    public class MainController
    {

        private DbContextOptions<ReisdocumentenDbContext> _options;

        public MainController(DbContextOptions<ReisdocumentenDbContext> options)
        {
            _options = options;
        }

        public void StartApp()
        {
            Console.WriteLine("App started");
            char gebruikersKeuze = MaakKeuze();
            if (gebruikersKeuze == 'A')
            {
                // show lijst met alle lopende aanvragen
                ReisdocumentController rc = new ReisdocumentController(_options);
                rc.GetLijstMetLopendeAanvragen();
            } else if (gebruikersKeuze == 'H') 
            {
                // Handle aanvraag af
                ReisdocumentController rc = new ReisdocumentController(_options);
                
            }

        }

        public char MaakKeuze()
        {
            Console.WriteLine("Maak een keuze:");
            Console.Write("(A)lle lopende aanvragen\r\n(H)andel aanvraag af: ");
            string? input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || 
                  (input != "A" && input != "a" && input != "H" && input != "h"))
            {
                Console.WriteLine("Probeer het nog eens. ");
                Console.Write("(A)lle lopende aanvragen\r\n(H)andel aanvraag af: ");
                input = Console.ReadLine();
            }
            return char.Parse(input.ToUpper());
        }
    }
}
