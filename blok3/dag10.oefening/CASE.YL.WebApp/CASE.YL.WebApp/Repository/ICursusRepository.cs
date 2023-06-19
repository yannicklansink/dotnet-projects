using CASE.YL.WebApp.Models;

namespace CASE.YL.WebApp.Repository
{
    public interface ICursusRepository
    {
        Cursus Add(Cursus cursus);
        Cursus? Get(int id);
        IQueryable<Cursus> GetAll();
        public void Delete(int id);
        public Cursus Update(Cursus cursusToUpdate);
        public Cursus? GetCursusWithCursisten(int id);

        public Cursusinstantie AddInstantie(Cursusinstantie cursusinstantie);
        Cursus GetCursusByTitleAndCode(string titel, string cursuscode);
    }
}
