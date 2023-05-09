using _9_5_23.Model;

namespace _9_5_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tuple
            (string, int) x = ("dit", 2);

            using (var context = new MagazijnDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            Console.WriteLine("Your database has been created");


            var voorraad1 = new Voorraad
            {
                Artikel = "Muis",
                Aantal = 5,
            };
            var voorraad2 = new Voorraad
            {
                Artikel = "Computer",
                Aantal = 9,
            };

            using (var context = new MagazijnDbContext())
            {
                context.Voorraad.Add(voorraad1);
                context.Voorraad.Add(voorraad2);
                context.SaveChanges();
                Console.WriteLine("Your inserts are done");
            }
        }
    }
}