using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Security.Claims;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel

    {
        //
        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }
        //

        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid) return Page();

            // Buscar el usuario en la base de datos
            var usr = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == User.Email && u.Password == User.Password);

            //if (User.Email == "correo@gmail.com" && User.Password == "123456")
            if(usr != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ""),
                    new Claim(ClaimTypes.Email, User.Email),

                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();

            Console.WriteLine("User: " + User.Email + " Password: " + User.Password);
        }
    }
}
