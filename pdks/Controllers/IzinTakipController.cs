using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pdks.Controllers
{
    public class IzinTakipController : Controller
    {
        PDKSEntities db = new PDKSEntities();
        // GET: IzinTakip
        public ActionResult Index()
        {
            var izin = db.IzinTakip.ToList();
            return View(izin);
        }

        public ActionResult IzinKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IzinKayit(Models.IzinTakip ızinTakip)
        {
            db.IzinTakip.Add(ızinTakip);
            db.SaveChanges();
            return RedirectToAction("index");
            return View();  /*aaaaaaaaaaa*/           

        }
        [HttpGet]
        public ActionResult Update1(int Id) 
        {
            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//hata mesajı
            }
            Models.IzinTakip PersonelIzın = db.IzinTakip.Find(Id);

            return View(PersonelIzın);
        }
        public ActionResult Update1(Models.IzinTakip Ekran) 
        {
            if (ModelState.IsValid)// doldurulması zorunlu alanlar doldurulmuş ise
            {
                db.Entry(Ekran).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View(Ekran);
        }
        public ActionResult Sil(int Id) 
        {
            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//hata mesajı
            }
            Models.IzinTakip Silinecek = db.IzinTakip.Find(Id);
            if (Silinecek==null)
            {
                return HttpNotFound();// database de olmayan bi ıd gelirse veya girilirse
            }
            return View(Silinecek);
        }
        [HttpPost]
        public ActionResult Sil(Models.IzinTakip IzinSil , int Id)
        {
            Models.IzinTakip Silinmis = db.IzinTakip.Find(Id);
            //1. yöntem
            db.IzinTakip.Remove(Silinmis);
            //2. yöntem
            db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}