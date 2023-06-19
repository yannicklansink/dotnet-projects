using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASE.YL.WebApp.Pages
{
    public class CursusDetailModel : PageModel
    {
        private readonly ICursusRepository _cursusRepository;

        public Cursus Cursus { get; set; }
        public List<Cursist> Cursisten { get; set; }

        public CursusDetailModel(ICursusRepository cursusRepository)
        {
            _cursusRepository = cursusRepository;
        }

        public void OnGet(int id)
        {
            Cursus = _cursusRepository.GetCursusWithCursisten(id);
            if (Cursus != null)
            {
                Cursisten = Cursus.Cursusinstanties
                                 .Select(ci => ci.Cursist)
                                 .ToList();
            }
        }
    }
}
