using Microsoft.AspNetCore.Mvc;
using Webbarinak3.Models.Siniflar;

namespace Webbarinak3.Controllers
{
    public class HayvanlarController : Controller
    {
        Context _context = new Context();  
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IEnumerable<Animal> Kedi()
        {
            var kedi = from k in _context.Animals.Where(k => k.Turu == "Kedi")
                       select k;

            return kedi.ToList();
        }

        [HttpGet]
        public IEnumerable<Animal> Köpek()
        {
            var köpek = from k in _context.Animals.Where(k => k.Turu == "Köpek")
                       select k;

            return köpek.ToList();
        }

        [HttpGet]
        public IEnumerable<Animal> Kuş()
        {
            var kuş = from k in _context.Animals.Where(k => k.Turu == "Kuş")
                       select k;

            return kuş.ToList();
        }
    }
} 
