using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pdks.Controllers
{
    public class PersonelSaglikDurumuController : Controller
    {
        PDKSEntities db = new PDKSEntities();
        // GET: PersonelSaglikDurumu
        public ActionResult Index()
        {
            var Bilgi = db.PersonelSaglikDurumlari.ToList();
            return View(Bilgi);
        }
        [HttpGet]
        public ActionResult KayitEkle()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult KayitEkle(Models.PersonelSaglikDurumlari Saglik)

        {
            db.PersonelSaglikDurumlari.Add(Saglik);
            db.SaveChanges();

            return View();
        }
        [HttpGet]
        public ActionResult Güncelle(int id )
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
            Models.PersonelSaglikDurumlari PersonelSag = db.PersonelSaglikDurumlari.Find(id);
            //modelim var gıt db den tabloyu ara ıd ye gore bul modelin içine bırak.personelsag dosyası olusur.
            return View(PersonelSag);
        }

        [HttpPost]
        public ActionResult Güncelle (Models.PersonelSaglikDurumlari Saglik)
        {
            //veritabanıındaki boşluk sartlarına uygunsa verilen veri veritabanın ozelliklerine uyuyorsa
            if (ModelState.IsValid)
            {
                //state yapısal ozellık demek.
                //saglık ekranını al sistemde guncelle
                db.Entry(Saglik).State = System.Data.Entity.EntityState.Modified;
                //kaydet
                db.SaveChanges();
                //lıstele. (index yazmamın sebebi indexte listelediğim için)
                return RedirectToAction("Index");
            }
            return View(Saglik);
        }
    }
}