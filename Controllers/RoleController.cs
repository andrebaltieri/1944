using Guardian.Data;
using Guardian.Models;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Guardian.Controllers
{
    public class RoleController : Controller
    {
        private AppDbContext _db;

        public RoleController(AppDbContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Roles.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
           if (ModelState.IsValid)
           {
               _db.Roles.Add(role);
               await _db.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           
           return View(role);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
           if (id == null)
               return HttpNotFound();

           Role role = await _db.Roles.SingleAsync(m => m.Id == id);
           if (role == null)
               return HttpNotFound();

           return View(role);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
           if (id == null)
               return HttpNotFound();

           Role role = await _db.Roles.SingleAsync(m => m.Id == id);
           if (role == null)
               return HttpNotFound();

           return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Role role)
        {
           if (ModelState.IsValid)
           {
               _db.Update(role);
               await _db.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           return View(role);
        }
        
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
           if (id == null)
               return HttpNotFound();

           Role role = await _db.Roles.SingleAsync(m => m.Id == id);
           if (role == null)
               return HttpNotFound();

           return View(role);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           Role role = await _db.Roles.SingleAsync(m => m.Id == id);
           _db.Roles.Remove(role);
           await _db.SaveChangesAsync();
           return RedirectToAction("Index");
        }
    }
}