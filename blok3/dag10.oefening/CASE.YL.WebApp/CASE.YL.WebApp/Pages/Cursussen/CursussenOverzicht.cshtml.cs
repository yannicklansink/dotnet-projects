using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CASE.YL.WebApp.Pages
{
    public class CursussenOverzichtModel : PageModel
    {

        public List<Cursus> CursusList { get; set; }

        private readonly ICursusRepository _cursusRepository;
        public int WeekNumber { get; set; }
        public int Year { get; set; }


        public CursussenOverzichtModel(ICursusRepository cursusRepository)
        {
            _cursusRepository = cursusRepository;
        }

        public void OnGet(int weekNumber, int year)
        {
            Console.WriteLine("test1");
            // If weekNumber and year are not provided, use the current week and year.
            if (weekNumber <= 0 && year <= 0)
            {
                Console.WriteLine("test2");
                var currentDate = DateTime.Now;
                var dayOfWeek = (int)currentDate.DayOfWeek;
                var startOfWeek = currentDate.AddDays(-dayOfWeek).Date;
                WeekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                Year = currentDate.Year;
            } else
            {
                WeekNumber = weekNumber;
                Year = year;
                CheckWeekAndYearValues();
            }

            var startDate = new DateTime(Year, 1, 1).AddDays((WeekNumber - 1) * 7);
            var endDate = startDate.AddDays(7);

            CursusList = _cursusRepository.GetAll()
                                  .Include(c => c.Cursusinstanties)
                                  .ToList();

            // Filter CursusInstanties for each Cursus based on the date range.
            foreach (var cursus in CursusList)
            {
                cursus.Cursusinstanties = cursus.Cursusinstanties
                    .Where(ci => ci.Startdatum >= startDate && ci.Startdatum < endDate)
                    .ToList();
            }
        }

        private void CheckWeekAndYearValues()
        {
            if (WeekNumber > 52)
            {
                WeekNumber = 1;
                Year++;
            } else if (WeekNumber <= 0)
            {
                WeekNumber = 52;
                Year--;
            }
        }
    }
}
