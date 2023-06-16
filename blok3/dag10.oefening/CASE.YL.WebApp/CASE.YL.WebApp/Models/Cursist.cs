namespace CASE.YL.WebApp.Models
{
    public class Cursist
    {
        public int Id { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        // Navigation Property
        public ICollection<Cursusinstantie> Cursusinstanties { get; set; }
    }
}
