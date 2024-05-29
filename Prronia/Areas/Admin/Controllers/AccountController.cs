using Microsoft.AspNetCore.Mvc;

namespace Prronia.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
