using JAVA_EMPTMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAVA_EMPTMVC.Entity
{
    public class EgitmenAdi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SiniflarId { get; set; }
        public virtual Siniflar Siniflar { get; set; }
    }
}