using Dag8.oefening1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Dag8.oefening1.Dal
{
    public class TodoContext : DbContext
    {

        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionstring = @"Server=localhost,1433;Database=dotnet7todoappdb;User=sa;Password=kpHm4Cfc@;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionstring);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
