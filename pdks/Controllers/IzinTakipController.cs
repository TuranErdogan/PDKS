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
            return View();  /*aaaaaaaaaaa*/           

        }
        [HttpGet]
        public ActionResult Update1(int Id) 
        {
            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
    }
}