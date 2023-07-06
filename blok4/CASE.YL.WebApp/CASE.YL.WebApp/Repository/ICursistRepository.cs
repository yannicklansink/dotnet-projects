using CASE.YL.WebApp.Models;

namespace CASE.YL.WebApp.Repository
{
    public interface ICursistRepository
    {
        Cursist Add(Cursist cursist);
        Cursusinstantie AddCursusinstantie(Cursusinstantie cursusInstantie);
        bool DeleteCursist(int id);
        IQueryable<Cursist> GetAll();
        Cursist GetCursistWithCursussen(int id);
        bool UpdateCursist(int id, Cursist cursist);
    }
}
