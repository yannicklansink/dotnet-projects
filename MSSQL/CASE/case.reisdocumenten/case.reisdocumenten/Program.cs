using cases.reisdocumenten.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace cases.reisdocumenten;
internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Server=localhost,1433;Database=ReisdocumentenDb2;User=SA;Password=kpHm4Cfc@;TrustServerCertificate=True";
        DbContextOptions<ReisdocumentenDbContext> options =
            new DbContextOptionsBuilder<ReisdocumentenDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        EnsureDatabase(options);
    }

    private static void EnsureDatabase(DbContextOptions<ReisdocumentenDbContext> options)
    {
        using (var context = new ReisdocumentenDbContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        Console.WriteLine("Your database has been created");
    }
}
