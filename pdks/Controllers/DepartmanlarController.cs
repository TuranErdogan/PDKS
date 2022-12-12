using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}