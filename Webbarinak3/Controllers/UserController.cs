using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webbarinak3.Models.Siniflar;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Webbarinak3.Controllers
{

    public class UserController : Controller
    {
        Context u = new Context();
        public IActionResult Index()
        {
            var degerler = u.Animals.ToList();
            return View(degerler);
        }
        public IActionResult IndexEng()
        {
            var degerler = u.Animals.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User p)
        {
            if (ModelState.IsValid)
            {
                // E-posta ve kullanıcı adı alanlarının unique olup olmadığını kontrol et
                var existingEmail = u.Users.FirstOrDefault(u => u.Email == p.Email);
                var existingUserName = u.Users.FirstOrDefault(u => u.UserName == p.UserName);

                if (existingEmail != null)
                {
                    TempData["Hata"] = "Bu e-posta adresi zaten kullanılıyor!";
                    return RedirectToAction("Register");
                }

                if (existingUserName != null)
                {
                    TempData["Hata"] = "Bu kullanıcı adı zaten kullanılıyor!";
                    return RedirectToAction("Register");
                }

                // E-posta ve kullanıcı adı unique ise kullanıcıyı veritabanına ekle
                u.Users.Add(p);
                u.SaveChanges();
                TempData["Kayit"] = "Kayit Basarili";
                return RedirectToAction("Register");
            }
            else
            {
                TempData["Hata"] = "Eksik Seçim Yaptınız!!";
                return RedirectToAction("Register");
            }

        }
        public IActionResult listele()
        {
            var degerler = u.Users.ToList();
            return View(degerler);
        }
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");

        }
    }

    }
