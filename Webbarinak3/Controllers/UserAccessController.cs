using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Webbarinak3.Models;
using Webbarinak3.Models.Siniflar;
using Microsoft.AspNetCore.Authorization;

namespace Webbarinak3.Controllers
{
    
    public class UserAccessController : Controller
    {
        Context user = new Context();
        public IActionResult UserLogin()
        {          

            ClaimsPrincipal claimUser = HttpContext.User; //Kullanıcının önceden giriş yapmış olduğunu kontrol ediyoruz
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "User");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLogin modelLogin2)
        {
            var users = user.Users.FirstOrDefault(user => user.UserName == modelLogin2.Username && user.Password == modelLogin2.Password);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin2.Username),
                    new Claim(ClaimTypes.Role,"user")

                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin2.KeepLogedIn
                };


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                
                return RedirectToAction("Index", "User");
            }

            ViewData["ValidateMessage"] = "Kullanıcı bulunamadı.";
            return View();
        }
    }
}
