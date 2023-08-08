using Microsoft.AspNetCore.Mvc;
using Webbarinak3.Models.Siniflar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webbarinak3.Migrations;
using Webbarinak3.Helpers;

namespace Webbarinak3.Controllers
{
    
    public class AdminController : Controller
    {

        Context c = new Context();
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var degerler = c.Animals.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult NewAnimals() //Bunlardan bir tanesi httpgette çalışağı için aynı metottan iki tane oluşturuyoruz.
        {

            List<string> animalTypeList = c.AnimalTypes.Select(a => a.AnimalTur).ToList();
            ViewBag.AnimalType = animalTypeList;

            List<string> animalHealthList = c.AnimalHealths.Select(b => b.health).ToList();
            ViewBag.Health = animalHealthList;

            return View(); //Sayfa yüklenince hiçbir şey yapma sayfanın bos halini döndür
        }

        [HttpPost]
        public IActionResult NewAnimals(Animal u)
        {
            if (ModelState.IsValid)
            {
                c.Animals.Add(u);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Hata"] = "Eksik Seçim Yaptınız!!";
                return RedirectToAction("NewAnimals");
            }
             
        }

        [HttpGet]
        public IActionResult FormAdd(int id)
        {
            var req = c.Requests2.Find(id);
            if (req != null)
            {
                // Request2 nesnesini Animal nesnesine dönüştür
                var animal = MappingHelper.MapRequestToAnimal(req);

                c.Animals.Add(animal);
                c.Requests2.Remove(req);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Hata"] = "Eksik Seçim Yaptınız!!";
                return RedirectToAction("FormAdd");
            }

        }


        public IActionResult FormIgnore(int id)
        {
            var requ = c.Requests2.Find(id);
            if(requ == null)
            {
                return RedirectToAction("Index");

            }
            c.Requests2.Remove(requ);
            c.SaveChanges();
            return RedirectToAction("FormIgnore");

        }


        public IActionResult DeleteAnimals(int id)
        {
            var u = c.Animals.Find(id);
            c.Animals.Remove(u); 
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RequestOnayla(int id)
        {
            var r = c.Requests.Find(id);
            var sil = c.Animals.Find(r.AnimalID);
            c.Animals.Remove(sil);
            c.Requests.Remove(r);
            c.SaveChanges();
            return RedirectToAction("Istekler");
        }
        public IActionResult RequestReddet(int id)
        {
            var r = c.Requests.Find(id);
            c.Requests.Remove(r);
            c.SaveChanges();
            return RedirectToAction("Istekler");
        }

        public IActionResult DeleteAnimalTypes(int id)
        {
            var u = c.AnimalTypes.Find(id);
            c.AnimalTypes.Remove(u);
            c.SaveChanges();
            return RedirectToAction("ListType");
        }

        public IActionResult GetAnimals(int id)
        {
            if (ModelState.IsValid)
            {
                List<string> animalTypeList = c.AnimalTypes.Select(a => a.AnimalTur).ToList();
                ViewBag.AnimalType = animalTypeList;

                List<string> animalHealthList = c.AnimalHealths.Select(b => b.health).ToList();
                ViewBag.Health = animalHealthList;

                var ur = c.Animals.Find(id);
                return View("GetAnimals", ur);
            }
            else
            {
                TempData["Hata"] = "Güncelleme Yaparken Eksik Seçim Yaptınız!!";
                return RedirectToAction("GetAnimals");
            }
            
        }

        public IActionResult UpdateAnimals(Animal u)
        {
            if (ModelState.IsValid) { 
                var ani = c.Animals.Find(u.AnimalID);
                ani.Turu = u.Turu;
                ani.Cinsi = u.Cinsi;
                ani.Yasi = u.Yasi;
                ani.SaglikDurumu = u.SaglikDurumu;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Hata"] = "Güncelleme Yaparken Eksik Seçim Yaptınız!!";
                return RedirectToAction("GetAnimals");
            }
        }
        public IActionResult Istekler()
        {
            var degerler = c.Requests.ToList();
            return View(degerler);
        }
        public IActionResult basvuru()
        {
            var degerler = c.Requests2.ToList();
            return View(degerler);
        }

        public IActionResult ListType()
        {
            var degerler = c.AnimalTypes.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult AddTur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTur(AnimalType u)
        {
            if (ModelState.IsValid)
            {
                c.AnimalTypes.Add(u);
                c.SaveChanges();
                TempData["Hata"] = u + "Tür Eklendi";
                return RedirectToAction("ListType");
            }
            else
            {
                TempData["Hata"] = "Eksik Seçim Yaptınız!!";
                return RedirectToAction("AddAnimalTur");
            }
        }

        
        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");

        }

       

    }
}
