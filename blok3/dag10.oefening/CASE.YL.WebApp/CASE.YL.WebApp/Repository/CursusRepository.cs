using CASE.YL.WebApp.Dal;
using CASE.YL.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CASE.YL.WebApp.Repository
{
    public class CursusRepository : ICursusRepository
    {

        private readonly CursusContext _context;

        public CursusRepository(CursusContext context)
        {
            _context = context;
        }

        public Cursus Add(Cursus cursus)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cursus? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cursus> GetAll()
        {
            return _context.Cursussen
                           .Include(c => c.Cursusinstanties);
        }

        public Cursus Update(Cursus cursusToUpdate)
        {
            throw new NotImplementedException();
        }

        public Cursus? GetCursusWithCursisten(int id)
        {
            return _context.Cursussen
                           .Include(c => c.Cursusinstanties) // retrieve CursusInstantie table from Cursus
                           .ThenInclude(ci => ci.Cursist) // retrieve Cursist table from CursusInstantie
                           .FirstOrDefault(c => c.Id == id); // retrieve a single Cursus entity that matches the Id, or null if no such entity is found.
        }

        public Cursusinstantie AddInstantie(Cursusinstantie cursusinstantie)
        {
            _context.Cursusinstanties.Add(cursusinstantie);
            _context.SaveChanges();
            return cursusinstantie;
        }

        public Cursus GetCursusByTitleAndCode(string titel, string cursuscode)
        {
            return _context.Cursussen.FirstOrDefault(c => c.Titel == titel && c.Code == cursuscode);
        }

        public Cursusinstantie? GetCursusinstantieByCurusIdAndCursistIdAndStartdatum(Cursus cursus, Cursist cursist, DateTime startDatum)
        {
            if (cursist == null)
            {
                return _context.Cursusinstanties.FirstOrDefault(ci => ci.CursusId == cursus.Id && 
                                                                ci.Startdatum == startDatum);
            }
            return _context.Cursusinstanties.FirstOrDefault(ci => ci.CursusId == cursus.Id && 
                                                            ci.CursistId == cursist.Id && 
                                                            ci.Startdatum == startDatum);
        }
    }
}
