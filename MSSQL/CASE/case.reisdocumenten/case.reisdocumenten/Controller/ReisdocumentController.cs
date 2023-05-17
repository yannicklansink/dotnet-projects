using cases.reisdocumenten.DAL;
using cases.reisdocumenten.Model;
using cases.reisdocumenten.Model.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Controller
{
    public class ReisdocumentController
    {

        private DbContextOptions<ReisdocumentenDbContext> _options;

        public ReisdocumentController(DbContextOptions<ReisdocumentenDbContext> options) 
        { 
            _options = options;
        }

        public void ShowAllReisdocumenten()
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                IReisdocumentRepository repo = new ReisdocumentRepository(context);

                var reisdocumenten = repo.GetAllReisdocumenten();

                foreach (var reisdocument in reisdocumenten)
                {
                    Console.WriteLine(reisdocument.DocumentNr);
                }
            }
        }

        public void ShowLijstMetLopendeAanvragen()
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                IReisdocumentRepository repo = new ReisdocumentRepository(context);

                var lopendeAanvragen = repo.GetLijstMetLopendeAanvragen();

                Console.Clear();
                Console.WriteLine("AanvraagNr\t| Burger Service Nr\t| Datum/Tijd Aanvraag\t| Reisdocument");
                Console.WriteLine("----------\t| -------------------\t| -------------------\t| ------------");

                foreach (LopendeAanvragen aanvraag in lopendeAanvragen)
                {
                    Console.WriteLine($"{aanvraag.documentNr}\t\t| {aanvraag.bsn}\t\t| {aanvraag.datumTijdAanvraag}\t\t| {aanvraag.reisDocument}");
                }

                Console.WriteLine("\nType ENTER om terug te gaan naar het hoofdmenu.");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("\nType ENTER om terug te gaan naar het hoofdmenu.");
                }
                
            }
        }

        public void AanvraagAfhandelen()
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                BurgerController bc = new BurgerController(_options);

                Console.Clear();

                string naam;
                Burger burger = null;

                do
                {
                    Console.WriteLine("Vul de naam van de burger in:");

                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Escape) { return; }

                    naam = Console.ReadLine();
                    while (!IsNameValid(naam))
                    {
                        Console.WriteLine("Ongeldige naam. Probeer het opnieuw:");
                        naam = Console.ReadLine();
                    }

                    burger = bc.GetBurgerByNaam(naam);

                    if (burger == null) { Console.WriteLine($"De Burger met de naam {naam} is niet gevonden in de database. Probeer het opnieuw."); }
                } while (burger == null);

                bc.ShowBurgerGegevens(burger);
            }

        }

        private bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }


    }
}
