using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CASE.YL.WebApp.Pages
{
    public class CursistDetailModel : PageModel
    {

        private readonly ICursistRepository _cursistRepository;

        public Cursist Cursist { get; set; }

        public List<Cursus> CursusList { get; set; }

        public CursistDetailModel(ICursistRepository cursistRepository)
        {
            _cursistRepository = cursistRepository;
        }

        public void OnGet(int id)
        {
            Cursist = _cursistRepository.GetCursistWithCursussen(id);
            if (Cursist != null)
            {
                CursusList = Cursist.Cursusinstanties
                                .Select(ci => ci.Cursus)
                                .ToList();
            }
        }
    }
}
