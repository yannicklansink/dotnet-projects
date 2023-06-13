using Dag8.oefening1.Models;
using Dag8.oefening1.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Dag8.oefening1.Dal
{
    public class TodoContext : IdentityDbContext<Gebruiker>
    {
        private readonly IConfiguration _config;
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "dotnet7inmemory");

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{


        //    //var connectionString = "Server=(localdb);Database=dotnet7todoappdb;User=sa;Password=kpHm4Cfc@;TrustServerCertificate=True";
        //    var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=dotnet7todoappdb;TrustServerCertificate=True; Integrated Security=true";
        //    //var envVariableName = _config.GetValue<string>("EnvKeys:TodoDbConn");
        //    //var connectionString = Environment.GetEnvironmentVariable(envVariableName); // <- werkt niet :(
        //    optionsBuilder.UseSqlServer(connectionString);


        //}

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // keys of Identity tables are mapped in OnModelCreating
            modelBuilder.Seed();
        }

    }
}
