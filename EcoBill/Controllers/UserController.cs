using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoBill.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoBill.Controllers
{
    public class UserController : Controller
    {
        EcobillDbContext db = new EcobillDbContext();

       
        

        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User u)
        {
            try
            {
                User addeduser = new User();
                addeduser.Email = u.Email;
                addeduser.Name = u.Name;
                addeduser.Phone = u.Phone;
                addeduser.UniqueCode = u.UniqueCode;
                db.User.Add(addeduser);
                db.SaveChanges();
                ViewBag.QR = u.UniqueCode;

                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var itemToRemove = db.User.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                db.User.Remove(itemToRemove);
                db.SaveChanges();
            }
            return View("Index", db.User.ToList());
         
        }

       
        
    }
}