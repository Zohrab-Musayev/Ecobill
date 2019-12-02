using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoBill.Helper;
using EcoBill.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoBill.Controllers
{
    public class AccountController : Controller
    {
        EcobillDbContext db = new EcobillDbContext();

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User u)
        {
            if(db.User.ToList().Any(x=>x.Email == u.Email && x.UniqueCode == u.UniqueCode))
            {
                var user = db.User.FirstOrDefault(x => x.Email == u.Email && x.UniqueCode == u.UniqueCode).Id;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "userid", user);
                return RedirectToAction("Index", "UserAccount");
            }
            else
            {
                ViewBag.ErrorMessage = "There is no such User";
                return View();
            }
            
        }
    }
}