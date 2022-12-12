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

            return View();
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


    }
}