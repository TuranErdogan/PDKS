using JAVA_EMPTMVC.Entity;
using JAVA_EMPTMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JAVA_EMPTMVC.DAL
{
    public class CodeFirstContext :DbContext
    {
        public DbSet<Siniflar> siniflars { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<EgitmenAdi> Ogrencis { get; set; }

    }
}