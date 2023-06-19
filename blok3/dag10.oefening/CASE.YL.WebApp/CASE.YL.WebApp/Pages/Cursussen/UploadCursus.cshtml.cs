using CASE.YL.WebApp.Dal;
using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CASE.YL.WebApp.Pages.Cursussen
{
    public class UploadCursusModel : PageModel
    {
        private readonly ICursusRepository _cursusRepository;

        public UploadCursusModel(ICursusRepository cursusRepository)
        {
            _cursusRepository = cursusRepository;
        }

        [BindProperty]
        public IFormFile FileUpload { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        public string ErrorMessage { get; set; }

        // property to store the added entries in the database
        public List<string> AddedCursessen { get; set; } = new List<string>();

        public List<string> AddedCursusinstanties { get; set; } = new List<string>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (FileUpload != null)
            {
                ErrorMessage = "Please select a file.";
                return Page();
            }

            // StreamReader object is disposed of once it goes out of the using block's scope.
            // This ensures that any file handles associated with the StreamReader object are released properly.
            using (var reader = new StreamReader(FileUpload.OpenReadStream()))
            {
                string content = await reader.ReadToEndAsync();
                // \r\n == new line character
                string[] entries = content.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var record in entries)
                {
                    
                    string[] fields = record.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);


                    // Check for correct format
                    if (fields.Length != 4 ||
                        !fields[0].StartsWith("Titel: ") ||
                        !fields[1].StartsWith("Cursuscode: ") ||
                        !fields[2].StartsWith("Duur: ") ||
                        !fields[3].StartsWith("Startdatum: "))
                    {
                        ErrorMessage = "Invalid file format. Fields are incorrect";
                        return Page();
                    }

                    string titel = fields[0].Substring(7).Trim();
                    string cursuscode = fields[1].Substring(12).Trim();
                    string duur = fields[2].Substring(6).Trim().Split(' ').First();
                    string startdatum = fields[3].Substring(12).Trim();

                    // With the out keyword duurInt and startDatumDate will be filled when parsing is succesfull :)
                    if (!int.TryParse(duur, out int duurInt) ||
                        !DateTime.TryParseExact(startdatum, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDatumDate))
                    {
                        ErrorMessage = "Invalid file format. Can't parse the DateTime or Integer duur.";
                        return Page();
                    }

                    // Check if 'cursuscode' with 'titel' togheter already exists in the Database. 
                    // If so, get that 'Cursus' object out of the database and add it to the 'Curcusinstantie'
                    // if not, add a new 'Cursus' to the database 
                    Cursus existingCursus = _cursusRepository.GetCursusByTitleAndCode(titel, cursuscode);
                    Cursus cursus;
                    if (existingCursus != null)
                    {
                        // Cursus already existed. 
                        cursus = existingCursus;
                    } else
                    {
                        cursus = new Cursus
                        {
                            Duur = duurInt,
                            Titel = titel,
                            Code = cursuscode,
                        };
                        AddedCursessen.Add($"Added Cursus: {cursus.Titel} ({cursus.Code})");
                    }

                    // Check if the start date is on or between the dates entered by the user
                    if (startDatumDate >= StartDate && startDatumDate <= EndDate)
                    {
                        Cursusinstantie cursusinstantie = new Cursusinstantie
                        {
                            Cursus = cursus,
                            Startdatum = startDatumDate
                        };
                        _cursusRepository.AddInstantie(cursusinstantie);
                        AddedCursusinstanties.Add($"Added Cursusinstantie with date: {startDatumDate}");
                    }
                }
            }

            return Page();
        }

    }
}
