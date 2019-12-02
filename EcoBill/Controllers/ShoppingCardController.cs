using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoBill.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcoBill.Controllers
{
    public class ShoppingCardController : Controller
    {
        EcobillDbContext db = new EcobillDbContext();
        public IActionResult Index()
        {          
            return View(db.ShoppingCard.ToList());
        }
        public IActionResult Create()
        {
            var users = db.User.ToList();
            ViewBag.Users = new SelectList(users, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShoppingCard sc)
        {
            var users = db.User.ToList();
            ViewBag.Users = new SelectList(users, "Id", "Name");
            ShoppingCard addedspcd = new ShoppingCard();
            addedspcd.UserId = sc.UserId;
            addedspcd.Name = sc.Name;
            addedspcd.TotalPrice = sc.TotalPrice;
            addedspcd.CreatedDate = DateTime.Now;
            db.ShoppingCard.Add(addedspcd);
            db.SaveChanges();

            return View("Index", db.ShoppingCard.ToList());
        }

        public IActionResult Delete(int id)
        {
            var itemToRemove = db.ShoppingCard.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                db.ShoppingCard.Remove(itemToRemove);
                db.SaveChanges();
            }
            return View("Index", db.ShoppingCard.ToList());
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