using cases.reisdocumenten.DAL;
using cases.reisdocumenten.Exceptions;
using cases.reisdocumenten.Model;
using cases.reisdocumenten.Model.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Controller
{
    public class BurgerController
    {

        private DbContextOptions<ReisdocumentenDbContext> _options;

        public BurgerController(DbContextOptions<ReisdocumentenDbContext> options)
        {
            _options = options;
        }

        public Burger GetBurgerById(int burgerId)
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                IBurgerRepository repo = new BurgerRepository(context);

                var burger = repo.GetBurgerById(burgerId);

                return burger;
            }
        }

        public Burger GetBurgerByNaam(string geheleNaam)
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                IBurgerRepository repo = new BurgerRepository(context);
                Burger burger = null;

                var tuple = SplitNaam(geheleNaam);

                if (string.IsNullOrEmpty(tuple.Item1))
                {
                    return burger;
                }

                burger = repo.GetBurgerByNaam(tuple.Item1, tuple.Item2, tuple.Item3);

                return burger;
            }
        }

        // returns a tuple with 3 or 2 strings
        public (string voornaam, string tussenvoegsel, string achternaam) SplitNaam(string input)
        {
            string[] naamParts = input.Split(' ');

            if (naamParts.Length == 3)
            {
                return (naamParts[0], naamParts[1], naamParts[2]);
            }
            else if (naamParts.Length == 2)
            {
                return (naamParts[0], string.Empty, naamParts[1]);
            }
            else
            {
                return (string.Empty, string.Empty, string.Empty);
            }
        }

        public void ShowBurgerGegevens(Burger burger)
        {
            Console.Clear();
            string tussenvoegsel = burger.Tussenvoegsel != null ? burger.Tussenvoegsel + " " : "";
            Console.WriteLine($"Naam burger: {burger.Voornaam} {tussenvoegsel}{burger.Achternaam} ");
            if (burger.OorspronkelijkeNaam != null) 
            { 
                Console.WriteLine($"Oorsponkelijke naam: {burger.OorspronkelijkeNaam}"); 
            }
            Console.WriteLine($"BSN: {burger.Bsn}\n");

            using (var context = new ReisdocumentenDbContext(_options))
            {
                IBurgerRepository repo = new BurgerRepository(context);
                var burgerGegevens = repo.GetBurgerGegevens(burger);
                if (!IsBurgerGegevensEmpty(burgerGegevens))
                {
                    Console.WriteLine("AanvraagNr\t|  Datum/Tijd Aanvraag\t| Reisdocument");
                    Console.WriteLine("----------\t|  -------------------\t| ------------");

                    foreach (var aanvraag in burgerGegevens)
                    {
                        Console.WriteLine($"{aanvraag.documentNr}\t\t| {aanvraag.datumTijdAanvraag}\t\t| {aanvraag.reisDocument}");
                    }

                    AanvragenAfhandelen(burgerGegevens);
                }
                PressEnterToContinue();

            }
        }

        private void AanvragenAfhandelen(IEnumerable<BurgerGegevens> burgerGegevens)
        {
            string aanvraagNrs = GetAanvraagNrs(burgerGegevens);
            string[] splittedAanvraagNrs = aanvraagNrs.Split(null); // split on whitespaces

            Console.Write($"\nOm te administreren dat het reisdocument is uitgegeven, typ hierna het aanvraagnr ({aanvraagNrs}): ");

            string? aanvraagNr = Console.ReadLine();
            while (aanvraagNr is not null && !splittedAanvraagNrs.Contains(aanvraagNr))
            {
                Console.Write($"Ongeldige input. Probeer het opnieuw. Kies uit ({aanvraagNrs}): ");
                aanvraagNr = Console.ReadLine();
            }

            if (aanvraagNr is null)
            {
                Console.WriteLine("Aanvraag geannuleerd");
                return;
            }
            else
            {
                UpdateBurgerReisdocumentStatus(aanvraagNr);
            }
        }

        private void UpdateBurgerReisdocumentStatus(string aanvraagNr)
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                IBurgerRepository burgerRepo = new BurgerRepository(context);
                IReisdocumentRepository reisRepo = new ReisdocumentRepository(context);

                var reisdocument = reisRepo.GetReisdocumentByDocumentNr(aanvraagNr);

                // Is het nou mooier om dit in de Repository te doen?
                if (reisdocument != null)
                {
                    reisdocument.Status = "ingeleverd";
                    context.SaveChanges();
                }
                Console.WriteLine($"De status van document nummer: {aanvraagNr} is veranderd naar 'ingeleverd'");
            }
        }

        private void PressEnterToContinue()
        {
            Console.WriteLine("\nType ENTER om terug te gaan naar het hoofdmenu.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\nType ENTER om terug te gaan naar het hoofdmenu.");
            }
        }

        private string GetAanvraagNrs(IEnumerable<BurgerGegevens> burgerGegevens)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aanvraag in burgerGegevens)
            {
                sb.Append(aanvraag.documentNr + " ");
            }
            return sb.ToString();
        }

        private bool IsBurgerGegevensEmpty(IEnumerable<BurgerGegevens> burgerGegevens)
        {
            if (burgerGegevens.IsNullOrEmpty())
            {
                Console.WriteLine("Geen lopende aanvragen voor deze burger.\r\n");
                return true;
            }
            return false;
        }
    }
}
