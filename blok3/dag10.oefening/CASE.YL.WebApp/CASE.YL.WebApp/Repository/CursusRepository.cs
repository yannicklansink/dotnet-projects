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


        public IQueryable<Cursus> GetAll()
        {
            return _context.Cursussen
                           .Include(c => c.Cursusinstanties);
        }

        public bool Update(int id, Cursus cursusToUpdate)
        {
            if (id != cursusToUpdate.Id)
            {
                return false;
            }

            // Hierdoor weet de dbcontext dat het cursusToUpdate object moet
            // onthouden en opslaan als modified. Zodat later met savechanges 
            // het kan worden opgeslaan in de dbcontext.
            _context.Entry(cursusToUpdate).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong with saving changes");
            }
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

        public Cursus GetCursusById(int id)
        {
            return _context.Cursussen.FirstOrDefault(c => c.Id == id);
        }

        public Cursus Add(Cursus cursus)
        {
            _context.Cursussen.Add(cursus);
            _context.SaveChanges();
            return cursus;
        }

        public bool DeleteCursus(int id)
        {
            Cursus cursusToDelete = GetCursusById(id);

            if (cursusToDelete == null)
            {
                return false;
            }

            _context.Cursussen.Remove(cursusToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
