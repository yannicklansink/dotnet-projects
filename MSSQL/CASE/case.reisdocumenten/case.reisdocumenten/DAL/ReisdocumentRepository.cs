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

    public record LopendeAanvragen(int documentNr, int bsn, string datumTijdAanvraag, string reisDocument);

    public class ReisdocumentRepository : IReisdocumentRepository
    {

        private readonly ReisdocumentenDbContext _context;

        public ReisdocumentRepository(ReisdocumentenDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reisdocument> GetAllReisdocumenten()
        {
            return _context.Reisdocumenten.Include(r => r.Soort)
                                   .ToList();
        }

        public IEnumerable<LopendeAanvragen> GetLijstMetLopendeAanvragen()
        {
            // preciseloading
            var query = from r in _context.Reisdocumenten
                        join s in _context.Soorten on r.Soort.Id equals s.Id
                        join b in _context.Burgers on r.Burger.Id equals b.Id
                        select new LopendeAanvragen
                            (
                                r.DocumentNr,
                                b.Bsn,
                                r.Aanvraagdatum.ToString("d MMMM yyyy HH:mm"),
                                s.Naam
                            );

            return query.ToList();
        }





    }
}
