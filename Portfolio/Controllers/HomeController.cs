using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Data;
using Portfolio.Entities.Models;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // STATIK PROFIL
            var model = new ProfileViewModel
            {
                FullName = "Yi�it �ENER",
                About = "Merhaba, Ben Yi�it �ENER. Yeditepe �niversitesi Y�netim Bili�im Sistemleri Mezunuyum ve Aktif olarak yaz�l�m geli�tirme ile u�ra�maktay�m.",
                ProfileImage = "/img/y.jpg",
                Linkedin = "https://linkedin.com/in/yigitsener7",
                Github = "https://github.com/yigitsener77",

                Projects = _dbContext.Projects
                .Select(p => new ProjectViewModel
                {
                    Title = p.Title,
                    Description = p.Description,
                    Link = p.Link

                }).ToList(),

                Messages = _dbContext.Messages
                .OrderByDescending(m => m.SentAt)
                .Select(m => new MessageViewModel
                {
                    Name = m.Name,
                    Email = m.Email,
                    Content = m.Content,
                    SentAt = m.SentAt
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SendMessage(MessageViewModel message)
        {
            if (ModelState.IsValid)
            {
                var msg = new Message
                {
                    Name = message.Name,
                    Email = message.Email,
                    Content = message.Content,
                    SentAt = DateTime.Now
                };
                _dbContext.Messages.Add(msg);
                _dbContext.SaveChanges();
                TempData["MessageResult"] = "Mesaj�n�z ba�ar�yla iletildi!";
                return RedirectToAction("Index");
            }
            TempData["MessageResult"] = "Mesaj g�nderilirken hata olu�tu!";
            return RedirectToAction("Index");
        }
    }
}
