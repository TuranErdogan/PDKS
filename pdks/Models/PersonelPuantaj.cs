//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pdks.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PersonelPuantaj
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        [Display(Name="G?n")]
        public System.DateTime CalismaGunu { get; set; }
        public System.DateTime GirisSaati { get; set; }
        public System.DateTime CikisSaati { get; set; }
        public string Mazeret { get; set; }
    
        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
    }
}
