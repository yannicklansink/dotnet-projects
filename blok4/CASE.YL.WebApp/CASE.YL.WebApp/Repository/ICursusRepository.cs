using CASE.YL.WebApp.Models;

namespace CASE.YL.WebApp.Repository
{
    public interface ICursusRepository
    {
       
        IQueryable<Cursus> GetAll();
        public bool Update(int id, Cursus cursusToUpdate);
        public Cursus? GetCursusWithCursisten(int id);

        public Cursusinstantie AddInstantie(Cursusinstantie cursusinstantie);
        Cursus GetCursusByTitleAndCode(string titel, string cursuscode);
        Cursusinstantie GetCursusinstantieByCurusIdAndCursistIdAndStartdatum(Cursus cursus, Cursist cursist, DateTime startDatum);
        Cursus GetCursusById(int id);
        Cursus Add(Cursus cursus);
        bool DeleteCursus(int id);
    }
}
