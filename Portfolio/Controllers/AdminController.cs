using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Data;
using Portfolio.Entities.Models;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _dbContext;

        // Admin giriş bilgileri
        private const string adminUser = "yigit";
        private const string adminPass = "159951";

        public AdminController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLoginViewModel model)
        {
            if (model.Username == adminUser && model.Password == adminPass)
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Kullanıcı adı veya şifre yanlış!";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path.Value?.ToLower();
            if (!path.Contains("login") && !path.Contains("logout"))
            {
                if (HttpContext.Session.GetString("IsAdmin") != "true")
                {
                    context.Result = RedirectToAction("Login");
                }
            }
            base.OnActionExecuting(context);
        }

        //  CRUD İşlemleri 

        // Listele
        public IActionResult Index()
        {
            var model = new AdminConsoleViewModel
            {
                Projects = _dbContext.Projects.ToList(),
                Messages = _dbContext.Messages.OrderByDescending(x => x.SentAt).ToList()
            };
            return View(model);
        }

        // Yeni Proje (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Proje (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Projects.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Düzenle (GET)
        public IActionResult Edit(int id)
        {
            var project = _dbContext.Projects.Find(id);
            if (project == null)
                return NotFound();
            return View(project);
        }

        // Düzenle (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Projects.Update(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Sil (GET)
        public IActionResult Delete(int id)
        {
            var project = _dbContext.Projects.Find(id);
            if (project == null)
                return NotFound();
            return View(project);
        }

        // Sil (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var project = _dbContext.Projects.Find(id);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
