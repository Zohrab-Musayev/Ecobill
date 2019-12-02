using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoBill.Helper;
using EcoBill.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoBill.Controllers
{
    public class UserAccountController : Controller
    {
        EcobillDbContext db = new EcobillDbContext();
        public IActionResult Index()
        {
            var userid = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "userid");
            var bills = db.ShoppingCard.ToList().Where(x => x.UserId == userid); 
            return View(bills);
        }

        public IActionResult Details(int id)
        {
            var carddetails = from t in db.ProductCard.ToList()
                              join p in db.Product.ToList() on t.ProductId equals p.Id
                              where t.ShoppingCardId == id
                              select p;

            return View(carddetails);
        }
    }
}