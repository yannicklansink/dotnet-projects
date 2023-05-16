using cases.reisdocumenten.DAL;
using cases.reisdocumenten.Model;
using cases.reisdocumenten.Model.Repo;
using Microsoft.EntityFrameworkCore;
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

        public void GetAllReisdocumenten()
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

        public void GetLijstMetLopendeAanvragen()
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
    }
}
