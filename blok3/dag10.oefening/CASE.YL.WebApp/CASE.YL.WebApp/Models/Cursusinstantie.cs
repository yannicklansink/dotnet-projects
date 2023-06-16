namespace CASE.YL.WebApp.Models
{
    public class Cursusinstantie
    {
        public int CursusId { get; set; }

        public int CursistId { get; set; }

        public Cursus Cursus { get; set; }

        public Cursist Cursist { get; set; }

        public DateTime Startdatum { get; set; }
    }
}
