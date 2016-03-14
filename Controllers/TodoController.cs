using TodoCore.Data;
using TodoCore.Models;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.Linq;
using System;

namespace TodoCore.Controllers
{
    public class TodoController : Controller
    {
        private AppDataContext _db;

        public TodoController(AppDataContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            ViewBag.Id = id;
            return View(await _db.TodoItems.Where(x => x.TodoListId == id).OrderBy(x => x.Done).ToListAsync());
        }

        public IActionResult Create(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.Id = Guid.NewGuid();
                _db.TodoItems.Add(todoItem);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", new { id = todoItem.TodoListId });
            }

            return View(todoItem);
        }

        public async Task<IActionResult> MarkAsDone(Guid id)
        {
            var todo = await _db.TodoItems.SingleAsync(m => m.Id == id);
            if (todo == null)
                return HttpNotFound();

            todo.Done = true;
            _db.Update(todo);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", new { Id = todo.TodoListId });
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            var todo = await _db.TodoItems.SingleAsync(m => m.Id == id);
            if (todo == null)
                return HttpNotFound();

            _db.TodoItems.Remove(todo);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", new { Id = todo.TodoListId });
        }
    }
}