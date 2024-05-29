using Microsoft.AspNetCore.Mvc;

namespace Prronia.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
