using ETicaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaret.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login.Email == "emre.ercan@windowslive.com")
            {
                return RedirectToAction("Home", "Home");
            }
            TempData["hata"] = "Hatalı giriş";
            return RedirectToAction("Index", "Home");
            
           
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

      
    }
}
