using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pdks.Controllers
{

    public class DepartmanlarController : Controller
    {
        PDKSEntities db = new PDKSEntities();
        // GET: Departmanlar
        public ActionResult Index()
        {
            var Veri = db.Departmanlar.ToList();
            return View(Veri);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Models.Departmanlar departmanlar)
        {
            db.Departmanlar.Add(departmanlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Departmanlar deparman = db.Departmanlar.Find(id);


            return View(deparman);
        }
        [HttpPost]
        public ActionResult Guncelle(Models.Departmanlar EkranaGelenDepartman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(EkranaGelenDepartman).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(EkranaGelenDepartman);

        }
        public ActionResult Sil(int id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); /* hata mesajı gönderir*/
            }
            Models.Departmanlar SilinecekDepartman = db.Departmanlar.Find(id);
            if (SilinecekDepartman == null)
            {
                return HttpNotFound(); /*kayıt bulunamadı mesajı döner*/
            }
            return View(SilinecekDepartman);  
        }
        [HttpPost] 
        public ActionResult Sil(Models.Departmanlar SilinecekDepartman, int id)
        {
            Models.Departmanlar SilinmisDepartman = db.Departmanlar.Find(id);
            db.Departmanlar.Remove(SilinmisDepartman);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Detay(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Departmanlar GosterilecekDepartman = db.Departmanlar.Find(id);

            return View(GosterilecekDepartman);
        }


    }
}