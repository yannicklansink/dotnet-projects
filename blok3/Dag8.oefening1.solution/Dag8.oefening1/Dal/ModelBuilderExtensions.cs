using Dag8.oefening1.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Dag8.oefening1.Dal
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(new Todo
            {
                Id = 1,
                Title = "afwas",
                UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52),
                Description = "Doe de afwas",
                IsDone = false,
            },
            new Todo
            {
                Id = 2,
                Title = "afwas",
                UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52),
                Description = "Doe de afwas2",
                IsDone = false,
            },
            new Todo
            {
                Id = 3,
                Title = "afwas",
                UitersteDatum = new DateTime(2008, 5, 1, 8, 30, 52),
                Description = "Doe de afwas3",
                IsDone = false,
            });
        }

    }
}
