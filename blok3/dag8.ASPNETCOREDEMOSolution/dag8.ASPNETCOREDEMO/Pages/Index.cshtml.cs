using dag8.ASPNETCOREDEMO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dag8.ASPNETCOREDEMO.Pages
{
    public class IndexModel : PageModel
    {
        public string Naam { get; set; } = "Yannick";

        public IEnumerable<MovieModel> Movies { get; set; } = new List<MovieModel>()
        {
            new MovieModel
            {
                Id = 4,
                Title = "Hot Fuzz",
                PosterUrl = "https://marketplace.canva.com/EAFTl0ixW_k/1/0/1131w/canva-black-white-minimal-alone-movie-poster-YZ-0GJ13Nc8.jpg",
                Rating = 9
            },
            new MovieModel
            {
                Id = 6,
                Title = "Scarface",
                PosterUrl = "https://marketplace.canva.com/EAFTl0ixW_k/1/0/1131w/canva-black-white-minimal-alone-movie-poster-YZ-0GJ13Nc8.jpg",
                Rating = 4
            },
            new MovieModel
            {
                Id = 8,
                Title = "The Office",
                PosterUrl = "https://marketplace.canva.com/EAFTl0ixW_k/1/0/1131w/canva-black-white-minimal-alone-movie-poster-YZ-0GJ13Nc8.jpg",
                Rating = 11
            }
        };

        public void OnGet()
        {

        }
    }
}
