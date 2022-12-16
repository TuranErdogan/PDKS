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
            var Veri = db.PersonelPuantaj.ToList();


            return View(Veri);
        }
        [HttpGet]
        public ActionResult Ekle()
        {

            ViewBag.Personel = new SelectList(db.PersonelOzlukBilgileri, "Id", "Ad");
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Models.PersonelPuantaj Puantaj)
        {

            db.PersonelPuantaj.Add(Puantaj);
            db.SaveChanges();
            return RedirectToAction("Index");
            return View(Puantaj);
            

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
        public ActionResult Guncelle(Models.PersonelPuantaj Ekran,int id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Ekran).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Ekran);

        }
        [HttpGet]
        public ActionResult Sil(int id) 
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); /* hata mesajı gönderir */
            }
            Models.PersonelPuantaj SilinecekPuantaj = db.PersonelPuantaj.Find(id);
            if (SilinecekPuantaj == null)
            {
                return HttpNotFound(); /* kayıt bulunamadı mesajı döner */
            }
            return View(SilinecekPuantaj);
        }
        [HttpPost]
        public ActionResult Sil(Models.PersonelPuantaj SilinecekPuantaj, int id)
        {
            Models.PersonelPuantaj SilinmisPuantaj = db.PersonelPuantaj.Find(id);
            db.PersonelPuantaj.Remove(SilinmisPuantaj);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Goster(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PersonelPuantaj Gosterilecek = db.PersonelPuantaj.Find(id);

            return View(Gosterilecek);
        }
    }
}