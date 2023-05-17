using cases.reisdocumenten.Model;
using cases.reisdocumenten.Model.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.DAL
{
    public record BurgerGegevens(int documentNr, string datumTijdAanvraag, string reisDocument);

    public class BurgerRepository : IBurgerRepository
    {

        private readonly ReisdocumentenDbContext _context;

        public BurgerRepository(ReisdocumentenDbContext context)
        {
            _context = context;
        }

        public Burger GetBurgerById(long burgerid)
        {
            return _context.Burgers.FirstOrDefault(b => b.Id == burgerid);
        }

        public Burger GetBurgerByNaam(string voornaam, string? tussenvoegesel, string achternaam)
        {
            Burger burger;
            if (String.IsNullOrEmpty(tussenvoegesel))
            {
                burger = _context.Burgers.FirstOrDefault(g => g.Voornaam == voornaam && g.Achternaam == achternaam);
                return burger;
            }


            burger = _context.Burgers.FirstOrDefault(g => g.Voornaam == voornaam && g.Tussenvoegsel == tussenvoegesel && g.Achternaam == achternaam);
            return burger;
        }

        public IEnumerable<BurgerGegevens> GetBurgerGegevens(Burger burger)
        {
            var query = from r in _context.Reisdocumenten
                        join s in _context.Soorten on r.Soort.Id equals s.Id
                        join b in _context.Burgers on r.Burger.Id equals b.Id
                        where b.Id == burger.Id && r.Status == "Actief"
                        select new BurgerGegevens
                            (
                                r.DocumentNr,
                                r.Aanvraagdatum.ToString("d MMMM yyyy HH:mm"),
                                s.Naam
                            );

            return query.ToList();
        }

        public void UpdateBurgerReisdocumentStatus(string documentNr)
        {

        }
    }
}
