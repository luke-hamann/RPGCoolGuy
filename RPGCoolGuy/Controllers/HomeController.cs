using Microsoft.AspNetCore.Mvc;
using RPGCoolGuy.Models;
using System.Diagnostics;

namespace RPGCoolGuy.Controllers
{
    public class HomeController : Controller
    {
        private CharacterContext ctx { get; set; }

        public HomeController(CharacterContext context)
        {
            ctx = context;
        }

        public IActionResult Index()
        {
            var chars = ctx.Characters.ToList();
            return View(chars);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("CharacterForm");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var c = ctx.Characters.Find(id);
            return View("CharacterForm", c);
        }

        [HttpPost]
        public IActionResult Edit(Character c)
        {
            if (ModelState.IsValid)
            {
                if (c.Id == 0)
                {
                    ctx.Characters.Add(c);
                }
                else
                {
                    ctx.Characters.Update(c);
                }
                ctx.SaveChanges();
                var chars = ctx.Characters.ToList();
                return View("Index", chars);
            }
            else { return View("CharacterForm", c); }
        }

        public IActionResult Delete(int id)
        {
            Character del = ctx.Characters.Find(id);
            ctx.Characters.Remove(del);
            ctx.SaveChanges();
            var c = ctx.Characters.ToList();
            return View("Index", c);
        }

        [HttpGet]
        public IActionResult Fight()
        {
            ViewBag.Characters = ctx.Characters.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Fight(Fight fight)
        {
            Character c1 = ctx.Characters.Find(fight.Character1);
            Character c2 = ctx.Characters.Find(fight.Character2);
            if (c1.Attack > c2.Attack)
            {
                ViewBag.result = c1.Name;
            }
            else if (c2.Attack > c1.Attack)
            {
                ViewBag.result = c2.Name;
            }
            else
            {
                ViewBag.result = "tie";
            }

            return View("Result");
        }
    }
}
