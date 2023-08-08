using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Webbarinak3.Models.Siniflar;

namespace Webbarinak3.Controllers
{
    public class RequestController : Controller
    {
        Context t = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sahiplen(int animalId)
        {
            // Veritabanında verilen "animalId" ile eşleşen hayvanı bulun
            var animal = t.Animals.Find(animalId);

            if (animal == null)
            {
                // Hayvan bulunamadı, bir hata sayfasına yönlendirin veya uygun mesaj verin.
                return NotFound();
            }
            //string userName = HttpContext.User.Identity.Name;
            // Sahiplenme talebini veritabanına kaydedin
            var request = new Request
            {
                AnimalID = animal.AnimalID,
                Turu = animal.Turu,
                Cinsi = animal.Cinsi,
                Yasi = animal.Yasi,
                SaglikDurumu = animal.SaglikDurumu,
                CreatedTime = DateTime.Now,
            };

            t.Requests.Add(request);
            t.SaveChanges();
            TempData["Basarili"] = "Başvuru Yapıldı!";
            TempData["Success"] = "Application Submitted!";
            // Daha sonra talep sonucunu göstereceğiniz bir sayfaya yönlendirin (örn: "SahiplenmeBasarili.cshtml")
            return RedirectToAction("Index", "User");
        }

        public IActionResult SahiplenEng(int animalId)
        {
            // Veritabanında verilen "animalId" ile eşleşen hayvanı bulun
            var animal = t.Animals.Find(animalId);

            if (animal == null)
            {
                // Hayvan bulunamadı, bir hata sayfasına yönlendirin veya uygun mesaj verin.
                return NotFound();
            }
            //string userName = HttpContext.User.Identity.Name;
            // Sahiplenme talebini veritabanına kaydedin
            var request = new Request
            {
                AnimalID = animal.AnimalID,
                Turu = animal.Turu,
                Cinsi = animal.Cinsi,
                Yasi = animal.Yasi,
                SaglikDurumu = animal.SaglikDurumu,
                CreatedTime = DateTime.Now,
            };

            t.Requests.Add(request);
            t.SaveChanges();
            TempData["Basarili"] = "Application Submitted!";
            // Daha sonra talep sonucunu göstereceğiniz bir sayfaya yönlendirin (örn: "SahiplenmeBasarili.cshtml")
            return RedirectToAction("IndexEng", "User");
        }
        [HttpGet]
        public IActionResult hayvanshiplendir()
        {
            List<string> animalTypeList = t.AnimalTypes.Select(a => a.AnimalTur).ToList();
            ViewBag.AnimalType = animalTypeList;

            List<string> animalHealthList = t.AnimalHealths.Select(b => b.health).ToList();
            ViewBag.Health = animalHealthList;

            return View(); //Sayfa yüklenince hiçbir şey yapma sayfanın bos halini dönd
        }
        [HttpPost]
        public IActionResult hayvanshiplendir(Request2 l)
        {

            if (ModelState.IsValid)
            {
                t.Requests2.Add(l);
                t.SaveChanges();
                TempData["Basarili"] = "Başvuru Yapıldı!";
                return RedirectToAction("Index","User");
            }
            else
            {
                TempData["Hata"] = "Eksik Seçim Yaptınız!!";
                return RedirectToAction("hayvanshiplendir");
            }


        }
    }
}
