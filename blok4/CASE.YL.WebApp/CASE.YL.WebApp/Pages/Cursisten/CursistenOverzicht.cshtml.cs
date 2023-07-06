using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASE.YL.WebApp.Pages
{
    public class CursistenOverzichtModel : PageModel
    {

        public List<Cursist> CursistList { get; set; }

        private readonly ICursistRepository _cursistRepository;


        public CursistenOverzichtModel(ICursistRepository cursistRepository)
        {
            _cursistRepository = cursistRepository;
        }
        public void OnGet()
        {
            CursistList = _cursistRepository.GetAll()
                                  //.Include(c => c.Cursusinstanties)
                                  .ToList();

        }
    }
}
