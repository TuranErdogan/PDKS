using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pdks.Models;

namespace pdks.Controllers
{
    public class OzlukController : Controller
    {
        PDKSEntities db = new PDKSEntities();
        // GET: Ozluk
        public ActionResult Index()
        {

            var Veri = db.PersonelOzlukBilgileri.ToList();


            return View(Veri);
        }
        [HttpGet]
        public ActionResult Giris()

        {

            return View();
        }
        [HttpPost]
        public ActionResult Giris(Models.PersonelOzlukBilgileri Ozluk)
        {

            db.PersonelOzlukBilgileri.Add(Ozluk);   
            db.SaveChanges();

            return View();
;

        }
    }
}