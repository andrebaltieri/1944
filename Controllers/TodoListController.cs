using TodoCore.Data;
using TodoCore.Models;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System;

namespace TodoCore.Controllers
{
    public class TodoListController : Controller
    {
        private AppDataContext _db;

        public TodoListController(AppDataContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.TodoLists.Include(x => x.Todos).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                _db.TodoLists.Add(todoList);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todoList);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            TodoList todoList = await _db.TodoLists.SingleAsync(m => m.Id == id);
            if (todoList == null)
                return HttpNotFound();

            return View(todoList);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            TodoList todoList = await _db.TodoLists.SingleAsync(m => m.Id == id);
            if (todoList == null)
                return HttpNotFound();

            return View(todoList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                _db.Update(todoList);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(todoList);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
                return HttpNotFound();

            TodoList todoList = await _db.TodoLists.SingleAsync(m => m.Id == id);
            if (todoList == null)
                return HttpNotFound();

            return View(todoList);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            TodoList todoList = await _db.TodoLists.SingleAsync(m => m.Id == id);
            _db.TodoLists.Remove(todoList);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}