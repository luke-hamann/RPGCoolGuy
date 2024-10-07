using Microsoft.AspNetCore.Mvc;
using RPGCoolGuy.Models;
using System.Diagnostics;

namespace RPGCoolGuy.Controllers
{
    public class HomeController : Controller
    {
        private CharacterDBContext context { get; set; }

        public HomeController(CharacterDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var characters = context.Characters.OrderBy(c => c.Name).ToList();
            return View(characters);
        }
    }
}
