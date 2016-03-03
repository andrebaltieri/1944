
using Guardian.Data;
using Guardian.Models;
using Microsoft.AspNet.Mvc;

namespace Guardian.Controllers
{
    public class RoleController : Controller
    {
        private AppDbContext _db;

        public RoleController(AppDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View(_db.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            if (!ModelState.IsValid)
                return View(role);
                
            _db.Roles.Add(role);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}