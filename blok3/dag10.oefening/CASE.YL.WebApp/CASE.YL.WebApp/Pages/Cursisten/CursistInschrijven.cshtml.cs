using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace CASE.YL.WebApp.Pages
{
    public class CursistInschrijvenModel : PageModel
    {

        private readonly ICursistRepository _cursistRepository;

        public bool IsRegistrationSuccessful { get; set; }

        [BindProperty]
        public string Voornaam { get; set; }

        [BindProperty]
        public string Achternaam { get; set; }

        [BindProperty]
        public string Type { get; set; } // Type will be set from the radiobutton value


        [BindProperty]
        public int CursusId { get; set; }

        [BindProperty]
        public DateTime Startdatum { get; set; }

        public CursistInschrijvenModel(ICursistRepository cursistRepository)
        {
            _cursistRepository = cursistRepository;
        }

        public void OnGet(int cursusId, DateTime startDatum)
        {
            CursusId = cursusId;
            Startdatum = startDatum;
        }

        public IActionResult OnPost()
        {
            var action = Request.Form["action"];

            if (action == "add" && ModelState.IsValid)
            {
                Cursist cursist; // abstract class
                //var cursistType = Request.Form["userType"]; // can only be particulier or medewerkerbedrijf
                //Console.WriteLine("cusisttype: " + cursistType);
                if (Type == "particulier")
                {
                    cursist = new Particulier
                    {
                        Voornaam = Request.Form["voornaam"],
                        Achternaam = Request.Form["achternaam"],
                        Straatnaam = Request.Form["straatnaam"],
                        Huisnummer = int.Parse(Request.Form["huisnummer"]),
                        Postcode = Request.Form["postcode"],
                        Woonplaats = Request.Form["woonplaats"],
                        Rekeningnummer = Request.Form["rekeningnummer"],
                    };
                }
                else if (Type == "medewerkerbedrijf")
                {
                    cursist = new Bedrijfsmedewerker
                    {
                        Voornaam = Request.Form["voornaam"],
                        Achternaam = Request.Form["achternaam"],
                        Bedrijfsnaam = Request.Form["bedrijfsnaam"],
                        Afdeling = Request.Form["afdeling"],
                        Offertenummer = int.Parse(Request.Form["offertenummer"]),
                    };
                }
                else
                {
                    Console.WriteLine("else ....");
                    return Page();
                }

                // Save the cursist to the database
                Cursist savedCursist = _cursistRepository.Add(cursist);

                // Create a new Cursusinstantie object
                Cursusinstantie cursusInstantie = new Cursusinstantie
                {
                    CursusId = this.CursusId,
                    CursistId = savedCursist.Id,
                    Startdatum = this.Startdatum, 
                };

                _cursistRepository.AddCursusinstantie(cursusInstantie); // werkt dit nu?

                IsRegistrationSuccessful = true;
                //return RedirectToPage("/Standard/Index");
                return Page();
            }

            return Page();
        }




    }
}
