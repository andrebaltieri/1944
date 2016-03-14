using Microsoft.AspNet.Mvc;

namespace TodoCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}