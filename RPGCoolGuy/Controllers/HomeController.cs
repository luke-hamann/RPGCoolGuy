using Microsoft.AspNetCore.Mvc;
using RPGCoolGuy.Models;

namespace RPGCoolGuy.Controllers
{
    public class HomeController : Controller
    {
        private CharacterContext ctx { get; set; }

        public HomeController(CharacterContext context)
        {
            ctx = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var chars = ctx.Characters.OrderBy(c => c.Name).ToList();
            return View(chars);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add Character";
            return View("CharacterForm");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit Character";
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
                return RedirectToAction("Index");
            }
            else
            {
                return View("CharacterForm", c);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Character? character = ctx.Characters.Find(id);

            if (character != null)
            {
                ctx.Characters.Remove(character);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
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
                ViewBag.result = c1.Name + " won.";
            }
            else if (c2.Attack > c1.Attack)
            {
                ViewBag.result = c2.Name + " won.";
            }
            else
            {
                ViewBag.result = "Tie.";
            }

            return View("Result");
        }
    }
}
