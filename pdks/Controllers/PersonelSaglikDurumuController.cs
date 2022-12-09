﻿using pdks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pdks.Controllers
{
    public class PersonelSaglikDurumuController : Controller
    { PDKSEntities db = new PDKSEntities(); 
        // GET: PersonelSaglikDurumu
        public ActionResult Index()
        {
            var Bilgi = db.PersonelSaglikDurumlari.ToList();
            return View(Bilgi);
        }
    }
}