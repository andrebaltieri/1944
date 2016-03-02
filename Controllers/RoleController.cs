
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
            _db.Roles.Add(new Role{ Name="Teste" });
            _db.SaveChanges();
            
            return View(_db.Roles);
        }
    }
}