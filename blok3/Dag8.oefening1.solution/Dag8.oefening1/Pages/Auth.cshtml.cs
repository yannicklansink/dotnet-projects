using Dag8.oefening1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dag8.oefening1.Pages
{
    public class AuthModel : PageModel
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly SignInManager<Gebruiker> _signInManager;

        public string Status { get; set; }

        public AuthModel(UserManager<Gebruiker> userManager, 
            SignInManager<Gebruiker> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

   

        public async Task OnGetRegister()
        {
            Gebruiker user = new Gebruiker
            {
                UserName = "YL",
                Email = "yd@d.nl",
                FavorieteTodo = "afwas"
            };
            var result = await _userManager.CreateAsync(user, "VeiligGenoegWachtwoord#0");
            if (result.Succeeded)
            {
                Status = "Gerigistreerd";
            } else
            {
                Status = $"Kon niet registreren:   {string.Join(", ", result.Errors.Select(x => x.Description))}";
            }

        }

        public async Task<IActionResult> OnGetLogIn()
        {
            var result = await _signInManager.PasswordSignInAsync("YL", "VeiligGenoegWachtwoord#0", false, false);
            
            if (result.Succeeded)
            {
                Status = "ingelogd";
                return RedirectToPage(); // This will refresh the page
            }
            else
            {
                Status = $"Kon niet inloggen:   ";
                return Page();
            }
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage();
        }

    }
}
