using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dag8.oefening1.Pages
{
    [Authorize] // moet ingelogd zijn dus
    public class PaginaModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
