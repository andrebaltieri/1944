using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using TodoCore.Data;

public class Navigation : ViewComponent
{
    private readonly AppDataContext _db;

    public Navigation(AppDataContext context)
    {
        _db = context;
    }

    public IViewComponentResult Invoke()
    {
        var lists = _db.TodoLists.Include(x => x.Todos).ToList();
        return View(lists);
    }
}
