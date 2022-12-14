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
            return RedirectToAction("Index");

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
        [HttpGet]
        public ActionResult Sil(int id)
        {
                //bir sebepten dolayhı boş ghelirse
            if (id==null)
            {
                //hata mesajı ver demek bu.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            Models.PersonelSaglikDurumlari Silinecek = db.PersonelSaglikDurumlari.Find(id);
            // kayıtlarda olmayan bir id girilirse;
            if (Silinecek == null)
            {
                return HttpNotFound();
            }
                return View(Silinecek);
        }
        [HttpPost]
        //ekrandaki modelden silinecek id yi al.
        public ActionResult Sil ( Models.PersonelSaglikDurumlari Silinecek,int id)
        {
            //ekrandaki silinmiş hali bul
            Models.PersonelSaglikDurumlari Silinmis = db.PersonelSaglikDurumlari.Find(id);
            // sil knk
            db.PersonelSaglikDurumlari.Remove(Silinmis); 
            db.SaveChanges();  
                //silinmiş halini listele
            return RedirectToAction("Index");
        }
        //details te get post yok :)
        public ActionResult Goster(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PersonelSaglikDurumlari Gosterilecek = db.PersonelSaglikDurumlari.Find(id);
            
            return View(Gosterilecek);
        }
    }
}




//*****************************NOTLARIMISSSSS (BERNAKO-SİNEMKO)*********************************************
//controller oluşturulur, gösterme ve işlem yapılıp gösterilecekse get ve post kullanılır actionresultlarda.
//sonra view oluşturulur 
//indexte ki ActionLink kısmı değiştirilir(birinci sitede gösterilcek olan yer.2.isim ise actionresulttaki isim olur.
//indexte calıstırılır.
//indexte css özelliği yapılır. models te de yapılır.