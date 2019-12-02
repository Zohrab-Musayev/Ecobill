using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EcoBill.Controllers
{
    [Route("Qrcode")]
    public class DemoController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("generate")]
        public IActionResult Generate(string productId)
        {
            ViewBag.productId = productId;
            return View("Index");
        }
    }
}