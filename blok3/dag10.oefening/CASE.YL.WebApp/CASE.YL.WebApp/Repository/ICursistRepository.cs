using CASE.YL.WebApp.Models;

namespace CASE.YL.WebApp.Repository
{
    public interface ICursistRepository
    {
        Cursist Add(Cursist cursist);
        Cursusinstantie AddCursusinstantie(Cursusinstantie cursusInstantie);
    }
}
