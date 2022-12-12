﻿using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}