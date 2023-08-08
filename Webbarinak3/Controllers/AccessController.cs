using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Webbarinak3.Models;

namespace Webbarinak3.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User; //Kullanıcının önceden giriş yapmış olduğunu kontrol ediyoruz
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Admin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login modelLogin)
        {
            if (modelLogin.Email == "g221210376@sakarya.edu.tr" &&
                modelLogin.Password == "sau"
                )
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim(ClaimTypes.Role,"admin"),
                    new Claim(ClaimTypes.Role,"user")

                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLogedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Admin");
            }

            ViewData["ValidateMessage"] = "Kullanıcı bulunamadı.";
            return View();
        }
    }
}