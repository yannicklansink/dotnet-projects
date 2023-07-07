using System.ComponentModel.DataAnnotations.Schema;

namespace CASE.YL.WebApp.Models
{
    public class Cursusinstantie
    {
        public int Id { get; set; }

        public int CursusId { get; set; }

        public int? CursistId { get; set; }

        public Cursus Cursus { get; set; }

        public Cursist? Cursist { get; set; }

        public DateTime Startdatum { get; set; }
    }
}
