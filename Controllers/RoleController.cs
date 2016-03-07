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
        public IActionResult Create(Role role)
        {
            if (!ModelState.IsValid)
                return View(role);
                
            _db.Roles.Add(role);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
                //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Role.ToListAsync());
        //}

        //// GET: Roles/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Role role = await _context.Role.SingleAsync(m => m.Id == id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(role);
        //}

        //// GET: Roles/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Roles/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Role role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Role.Add(role);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(role);
        //}

        //// GET: Roles/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Role role = await _context.Role.SingleAsync(m => m.Id == id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}

        //// POST: Roles/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Role role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(role);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(role);
        //}

        //// GET: Roles/Delete/5
        //[ActionName("Delete")]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Role role = await _context.Role.SingleAsync(m => m.Id == id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(role);
        //}

        //// POST: Roles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    Role role = await _context.Role.SingleAsync(m => m.Id == id);
        //    _context.Role.Remove(role);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}