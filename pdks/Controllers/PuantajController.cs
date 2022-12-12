using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pdks.Controllers
{
    public class PuantajController : Controller
    {
        PDKSEntities db = new PDKSEntities();
        // Paylaş
        // GET: Puantaj
        public ActionResult Index()
        {
            var Veri = db.PersonelOzlukBilgileri.ToList();


            return View(Veri);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Models.PersonelPuantaj Puantaj)
        {

            db.PersonelPuantaj.Add(Puantaj);
            db.SaveChanges();

            return View();
            ;

        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PersonelPuantaj PersonelP = db.PersonelPuantaj.Find(id);


            return View(PersonelP);
        }
        [HttpPost]
        public ActionResult Guncelle(Models.PersonelPuantaj Ekran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Ekran).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Ekran);

        }
    }
}