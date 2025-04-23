using ETicaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ETicaret.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection connection=new SqlConnection("Server=EMRE\\SQLEXPRESS01; Database=EticaretDemoDb;Integrated Security=true");

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
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Urunler",connection);
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            adapter.Fill(dataTable);
            List<Urunler> urunlerim=new List<Urunler>();
            foreach (DataRow row in dataTable.Rows)
            {
                urunlerim.Add(new Urunler
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UrunAdi = row["Urunadi"].ToString(),
                    Resim = row["Resim"].ToString(),
                    BirimFiyati = Convert.ToDecimal(row["BirimFiyati"])


                });

            }
            return View(urunlerim);
        }

      
    }
}
