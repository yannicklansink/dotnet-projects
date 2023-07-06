using CASE.YL.WebApp.Dal;
using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public List<string> AddedCursussen { get; set; } = new List<string>();

        public List<string> AddedCursusinstanties { get; set; } = new List<string>();

        public int RecordCounter;

        public async Task<IActionResult> OnPostAsync()
        {
            if (FileUpload == null)
            {
                ErrorMessage = "File is not correct.";
                return Page();
            }

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (var reader = new StreamReader(FileUpload.OpenReadStream()))
            {
                string fileContent = await reader.ReadToEndAsync();

                // \r\n == new line character
                string[] records = fileContent.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var record in records)
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
                    string duur = fields[2].Substring(6).Trim(); // fix for fout4.txt
                    string startdatum = fields[3].Substring(12).Trim();

                    string[] duurParts = duur.Split(' ');
                    // With the out keyword duurInt and startDatumDate will be filled when parsing is succesfull :)
                    // 5 dagen
                    if (duurParts.Length != 2 || !int.TryParse(duurParts[0], out int duurOut))
                    {
                        ErrorMessage = "Invalid file format. Can't parse duur.";
                        return Page();
                    }

                    if (!DateTime.TryParseExact(startdatum, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDatumOut))
                    {
                        ErrorMessage = "Invalid file format. Can't parse the DateTime.";
                        return Page();
                    }

                    Cursus cursus = GetCursusByTitelAndCode(titel, cursuscode, duurOut);

                    if (startDatumOut >= StartDate && startDatumOut <= EndDate)
                    {
                        Cursusinstantie cursusinstantie = GetCursusinstantieByCurusIdAndCursistIdAndStartdatum(cursus, null, startDatumOut);
                        RecordCounter++;
                    }

                    
                }
            }

            return Page();
        }

        // Check if 'cursus', 'cursist', and 'startDatum' togheter already exists in the Database. 
        // If so, get that 'Cursusinstantie' object out of the database
        // if not, add a new 'Cursusinstantie' to the database 
        private Cursusinstantie GetCursusinstantieByCurusIdAndCursistIdAndStartdatum(Cursus cursus, Cursist cursist, DateTime startDatum)
        {
            Cursusinstantie existingCursusinstantie = _cursusRepository.GetCursusinstantieByCurusIdAndCursistIdAndStartdatum(cursus, cursist, startDatum);
            Cursusinstantie cursusinstantie;
            if (existingCursusinstantie != null)
            {
                // Cursusinstantie already existed. 
                cursusinstantie = existingCursusinstantie;
            }
            else
            {
                cursusinstantie = new Cursusinstantie
                {
                    Cursus = cursus,
                    Cursist = cursist,
                    Startdatum = startDatum
                };
                _cursusRepository.AddInstantie(cursusinstantie);
                AddedCursusinstanties.Add($"Added Cursusinstantie with date: {startDatum}");
            }
            return cursusinstantie;
        }

        // Check if 'cursuscode' with 'titel' togheter already exists in the Database. 
        // If so, get that 'Cursus' object out of the database and add it to the 'Curcusinstantie'
        // if not, add a new 'Cursus' to the database 
        private Cursus GetCursusByTitelAndCode(string titel, string cursuscode, int duur)
        {
            Cursus existingCursus = _cursusRepository.GetCursusByTitleAndCode(titel, cursuscode);
            Cursus cursus;
            if (existingCursus != null)
            {
                // Cursus already existed. 
                cursus = existingCursus;
            } 
            else
            {
                cursus = new Cursus
                {
                    Duur = duur,
                    Titel = titel,
                    Code = cursuscode,
                };
                AddedCursussen.Add($"Added Cursus: {cursus.Titel} ({cursus.Code})");
            }

            return cursus;
        }

        public int GetDuplicateCursusCounter()
        {
            return RecordCounter - AddedCursussen.Count; 
        }

        public int GetDuplicateCursusinstantiesCounter()
        {
            return RecordCounter - AddedCursusinstanties.Count;
        }

    }
}
