using Microsoft.AspNetCore.Identity;

namespace Dag8.oefening1.Models
{
    public class Gebruiker : IdentityUser
    {

        public int Id { get; set; }

        public string FavorieteTodo;


    }
}
