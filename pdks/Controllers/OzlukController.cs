using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return RedirectToAction("index");

            return View();
            

        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PersonelOzlukBilgileri PersonelO = db.PersonelOzlukBilgileri.Find(id);


            return View(PersonelO);
        }
        [HttpPost]
        public ActionResult Guncelle(Models.PersonelOzlukBilgileri Ekran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Ekran).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Ekran);

        }

        public ActionResult Sil(int id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PersonelOzlukBilgileri Silinecek = db.PersonelOzlukBilgileri.Find(id);
            if (Silinecek == null)
            {
                return HttpNotFound();
            } 
            return View(Silinecek);        
        }
        [HttpPost]
        public ActionResult Sil (Models.PersonelOzlukBilgileri Silinecek,int id)
          
        {   
             Models.PersonelOzlukBilgileri Silinmis = db.PersonelOzlukBilgileri.Find(id);
             db.PersonelOzlukBilgileri.Remove(Silinmis);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult Goster(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PersonelOzlukBilgileri Gosterilecek = db.PersonelOzlukBilgileri.Find(id);


            return View(Gosterilecek);
        }
    }
}