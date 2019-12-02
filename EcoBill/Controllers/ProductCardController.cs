using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoBill.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcoBill.Controllers
{
    public class ProductCardController : Controller
    {
        EcobillDbContext db = new EcobillDbContext();
        public IActionResult Index()
        {
          
            return View(db.ProductCard.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.products = new SelectList(db.Product.ToList(), "Id", "Name");
            ViewBag.cards = new SelectList(db.ShoppingCard.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCard pc)
        {
            ViewBag.products = new SelectList(db.Product.ToList(), "Id", "Name");
            ViewBag.cards = new SelectList(db.ShoppingCard.ToList(), "Id", "Name");
            ProductCard addedpc = new ProductCard();
            addedpc.ProductId = pc.ProductId;
            addedpc.ShoppingCardId = pc.ShoppingCardId;
            db.ProductCard.Add(addedpc);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var itemToRemove = db.ProductCard.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                db.ProductCard.Remove(itemToRemove);
                db.SaveChanges();
            }
            return View("Index", db.ProductCard.ToList());

        }
    }
}