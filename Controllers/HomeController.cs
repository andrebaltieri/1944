using Microsoft.AspNet.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace Guardian.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}