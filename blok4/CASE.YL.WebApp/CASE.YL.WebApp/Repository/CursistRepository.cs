using CASE.YL.WebApp.Dal;
using CASE.YL.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CASE.YL.WebApp.Repository
{
    public class CursistRepository : ICursistRepository
    {

        private readonly CursusContext _context;

        public CursistRepository(CursusContext context)
        {
            _context = context;
        }

        public Cursist Add(Cursist cursist)
        {
            _context.Add(cursist);
            _context.SaveChanges();
            return cursist;
        }

        public Cursusinstantie AddCursusinstantie(Cursusinstantie cursusInstantie)
        {
            var exists = _context.Cursussen.Any(c => c.Id == cursusInstantie.CursusId);
            
            if (!exists)
            {
                throw new Exception("Cursus with the given CursusId does not exist.");
            }

            _context.Entry(cursusInstantie).State = EntityState.Added;
            _context.SaveChanges();
            return cursusInstantie;
        }

        public bool DeleteCursist(int id)
        {
            Cursist cursist = GetCursistWithCursussen(id);

            if (cursist != null)
            {
                _context.Custisten.Remove(cursist);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IQueryable<Cursist> GetAll()
        {
            return _context.Custisten;
                           //.Include(c => c.Cursusinstanties);
        }

        public Cursist? GetCursistWithCursussen(int id)
        {
            return _context.Custisten
                          .Include(c => c.Cursusinstanties)
                          .ThenInclude(ci => ci.Cursus)
                          .FirstOrDefault(c => c.Id == id); 
        }

        public bool UpdateCursist(int id, Cursist cursist)
        {
            if (id != cursist.Id)
            {
                return false;
            }

            // This line marks the cursist entity as modified in the Entity Framework's DbContext.
            // This tells the Entity Framework that it needs to generate SQL to update this
            // object's data in the database when SaveChanges() is called.
            _context.Entry(cursist).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            // to generic?
            catch (Exception)
            {
                throw new Exception("Something went wrong.");
            }

            return true;
        }

    }
}
