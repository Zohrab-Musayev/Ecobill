using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoBill.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoBill.Controllers
{
    public class ProductController : Controller
    {
        EcobillDbContext db = new EcobillDbContext();
        public IActionResult Index()
        {           
            return View(db.Product.ToList());
        }

        public IActionResult Delete(int id)
        {
            var itemToRemove = db.Product.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                db.Product.Remove(itemToRemove);
                db.SaveChanges();
            }
            return View("Index",db.Product.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            Product addedproduct = new Product();
            addedproduct.Name = p.Name;
            addedproduct.Price = p.Price;
            db.Product.Add(addedproduct);           
            db.SaveChanges();

            return View("Index", db.Product.ToList());
        }
    }
}