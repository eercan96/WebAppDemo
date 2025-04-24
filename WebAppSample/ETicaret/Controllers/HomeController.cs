using ETicaret.Dto;
using ETicaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ETicaret.Controllers
{
    public class HomeController : Controller
    {
        Context con= new Context();

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
            //SqlDataAdapter adapter = new SqlDataAdapter("Select * From Urunler",connection);
            //DataTable dataTable = new DataTable();
            //dataTable.Clear();
            //adapter.Fill(dataTable);
            //List<Urun> urunlerim=new List<Urun>();
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    urunlerim.Add(new Urun
            //    {
            //        Id = Convert.ToInt32(row["Id"]),
            //        UrunAdi = row["Urunadi"].ToString(),
            //        Resim = row["Resim"].ToString(),
            //        BirimFiyati = Convert.ToDecimal(row["BirimFiyati"])


            //    });

            //}
            List<Urun> urunlerim = new List<Urun>();
            urunlerim = con.Urunler.ToList();

            List<Sepet> sepetlerim= new List<Sepet>();
            sepetlerim =con.Sepetim.ToList();

            HomeDto list = new HomeDto();    

            list.Urunlerim = urunlerim;
            list.Sepetim = sepetlerim;

            return View(list);
        }

      
    }
}
