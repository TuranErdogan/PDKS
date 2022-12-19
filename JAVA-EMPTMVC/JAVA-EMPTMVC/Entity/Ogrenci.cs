using JAVA_EMPTMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAVA_EMPTMVC.Entity
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TcKimlik { get; set; }
        public int SiniflarId { get; set; } //sınıflar ıd ile eşleştirdik
        public virtual Siniflar siniflar { get; set; }// siniflar class ı ile  1'e çok ilişkisi vardır
    }
}