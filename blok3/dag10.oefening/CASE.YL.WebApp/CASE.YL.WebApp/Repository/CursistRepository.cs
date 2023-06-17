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
            // Debugging code
            var exists = _context.Cursussen.Any(c => c.Id == cursusInstantie.CursusId);
            
            if (!exists)
            {
                throw new Exception("Cursus with the given CursusId does not exist.");
            }

            _context.Entry(cursusInstantie).State = EntityState.Added;
            _context.SaveChanges();
            return cursusInstantie;
        }

    }
}
