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
        private bool _isActive;

        public MainController(DbContextOptions<ReisdocumentenDbContext> options)
        {
            _options = options;
        }

        public void StartApp()
        {
            Console.WriteLine("App started");
            _isActive = true;
            while (true)
            {
                char gebruikersKeuze = ShowHoofdMenu();
                if (gebruikersKeuze == 'A')
                {
                    // show lijst met alle lopende aanvragen
                    ReisdocumentController rc = new ReisdocumentController(_options);
                    rc.ShowLijstMetLopendeAanvragen();
                }
                else if (gebruikersKeuze == 'H')
                {
                    // Handle aanvraag af
                    ReisdocumentController rc = new ReisdocumentController(_options);
                    rc.ReisdocumentAanvraagAfhandelen();
                }
            }
            

        }

        public char ShowHoofdMenu()
        {
            Console.WriteLine("Maak een keuze:");
            Console.Write("(A)lle lopende aanvragen\r\n(H)andel aanvraag af: ");

            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Escape) 
            {
                _isActive = false;
                Console.WriteLine("\nShutting down...");
                Environment.Exit(0); 
            }

            string? input = Console.ReadLine();
            while (!IsValidInput(input))
            {
                Console.WriteLine("Probeer het nog eens. ");
                Console.Write("(A)lle lopende aanvragen\r\n(H)andel aanvraag af: ");
                input = Console.ReadLine();
            }

            return char.Parse(input.ToUpper());
        }

        private bool IsValidInput(string? input)
        {
            return !string.IsNullOrEmpty(input) && (input == "A" || input == "a" || input == "H" || input == "h");
        }
    }
}
