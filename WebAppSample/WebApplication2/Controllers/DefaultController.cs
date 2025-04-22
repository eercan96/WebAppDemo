using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            // ViewBag.metin = "asdas";
            TempData["metin"] = "aaa";
            return View();
        }
    }
}
