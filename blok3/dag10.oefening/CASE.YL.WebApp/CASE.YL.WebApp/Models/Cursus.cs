namespace CASE.YL.WebApp.Models
{
    public class Cursus
    {
        public int Id { get; set; }

        public int Duur { get; set; }

        public string Titel { get; set; }

        public string Code { get; set; }

        public ICollection<Cursusinstantie> Cursusinstanties { get; set; }


    }
}
