using Dag8.oefening1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Dag8.oefening1.Dal
{
    public class TodoContext : DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = "Server=localhost,1433;Database=dotnet7todoappdb;User=sa;Password=kpHm4Cfc@;TrustServerCertificate=True";

            //var envVariableName = _config.GetValue<string>("EnvKeys:TodoDbConn");
            //var connectionString = Environment.GetEnvironmentVariable(envVariableName); // <- werkt niet :(
            optionsBuilder.UseSqlServer(connectionString);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
