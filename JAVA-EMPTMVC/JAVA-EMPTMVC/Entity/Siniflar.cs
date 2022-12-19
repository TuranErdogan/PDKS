using JAVA_EMPTMVC.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JAVA_EMPTMVC.Models
{
    public class Siniflar
    {
        public int Id { get; set; }
        [StringLength(50)]
        //[DisplayName(Name = "Sınıf Adı")]
        public string Name { get; set; }
        public ICollection<Ogrenci> ogrencis { get; set; }//bir sınıfın birden çok öğrencisi olur (ICollection)
        //public int EgitmenId { get; set; }
        //public virtual EgitmenAdi Egitmen { get; set; }

    }
}