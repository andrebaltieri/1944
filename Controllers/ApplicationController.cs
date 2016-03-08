using Guardian.Data;
using Guardian.Models;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Guardian.Controllers
{
    public class ApplicationController : Controller
    {
        private AppDbContext _db;

        public ApplicationController(AppDbContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Applications.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Application application)
        {
           if (ModelState.IsValid)
           {
               _db.Applications.Add(application);
               await _db.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           
           return View(application);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
           if (id == null)
               return HttpNotFound();

           Application application = await _db.Applications.SingleAsync(m => m.Id == id);
           if (application == null)
               return HttpNotFound();

           return View(application);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
           if (id == null)
               return HttpNotFound();

           Application application = await _db.Applications.SingleAsync(m => m.Id == id);
           if (application == null)
               return HttpNotFound();

           return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Application application)
        {
           if (ModelState.IsValid)
           {
               _db.Update(application);
               await _db.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           return View(application);
        }
        
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
           if (id == null)
               return HttpNotFound();

           Application application = await _db.Applications.SingleAsync(m => m.Id == id);
           if (application == null)
               return HttpNotFound();

           return View(application);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           Application application = await _db.Applications.SingleAsync(m => m.Id == id);
           _db.Applications.Remove(application);
           await _db.SaveChangesAsync();
           return RedirectToAction("Index");
        }
    }
}