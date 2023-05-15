using _9_5_23.DAL;
using _9_5_23.Model;

namespace _9_5_23
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");
            EnsureDatabaseCreated();
            FillDBWithData();

            // get all nummers
            var nummers = GetAllNummers();
            foreach (Nummer nummer in nummers)
            {
                Console.WriteLine(nummer.Duur);
            }
            Console.WriteLine("-------------------------");

            // add nummer 
           
            var album5 = new Album { Naam = "MONTERO" };
            AddNummer(new Nummer { Naam = "Montero (Call Me By Your Name) ", Duur = 4.55, Album = album5 });
            nummers = GetAllNummers();
            foreach (Nummer nummer in nummers)
            {
                Console.WriteLine(nummer.Duur);
            }
            Console.WriteLine("-------------------------");

            //update duur nummer
            UpdateNummer("Montero (Call Me By Your Name)", 1.00);
            nummers = GetAllNummers();
            foreach (Nummer nummer in nummers)
            {
                Console.WriteLine(nummer.Duur);
            }


        }

        private static void FillDBWithData()
        {
            var album1 = new Album { Naam = "After Hours" };
            var nummer1 = new Nummer { Naam = "Blinding Lights", Duur = 3.35, Album = album1 };

            var album2 = new Album { Naam = "SOUR" };
            var nummer2 = new Nummer { Naam = "drivers license", Duur = 4.35, Album = album2 };

            var album3 = new Album { Naam = "F*ck Love 3: Over You" };
            var nummer3 = new Nummer { Naam = "Stay", Duur = 2.35, Album = album3 };

            var album4 = new Album { Naam = "Future Nostalgia" };
            var nummer4 = new Nummer { Naam = "Levitating", Duur = 3.45, Album = album4, Artiest = new Artiest { Naam = "Johan" } };

            using (var context = new MuziekDbContext())
            {
                context.Nummer.Add(nummer1);
                context.Nummer.Add(nummer2);
                context.Nummer.Add(nummer3);
                context.Nummer.Add(nummer4);

                context.SaveChanges();
            }
        }

        private static void EnsureDatabaseCreated()
        {
            using (var context = new MuziekDbContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            Console.WriteLine("Your database has been created");
        }

        public static IEnumerable<Nummer> GetAllNummers()
        {
            using (var context = new MuziekDbContext())
            {
                var nummers = context.Nummer.ToList();
                return nummers;
            }
        }

        public static void AddNummer(Nummer nummer)
        {
            using (var context = new MuziekDbContext())
            {
                context.Nummer.Add(nummer);
                context.SaveChanges();
            }
        }

        public static void UpdateNummer(string naam, double nieuweDuur)
        {
            using (var context = new MuziekDbContext())
            {
                var nummer = context.Nummer.FirstOrDefault(n => n.Naam == naam);
                if (nummer == null)
                {
                    Console.WriteLine($"Er is geen Nummer met de naam: {naam} gevonden");
                    return;
                }

                nummer.Duur = nieuweDuur;
                context.SaveChanges();

                Console.WriteLine($"De Duur van het Nummer: {naam} is gewijzigd naar {nieuweDuur}");
            }
        }
    }
}