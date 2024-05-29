using Microsoft.AspNetCore.Mvc;

namespace Prronia.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
