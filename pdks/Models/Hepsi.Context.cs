﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PDKSEntities : DbContext
    {
        public PDKSEntities()
            : base("name=PDKSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Belgeler> Belgeler { get; set; }
        public virtual DbSet<Departmanlar> Departmanlar { get; set; }
        public virtual DbSet<IzinTakip> IzinTakip { get; set; }
        public virtual DbSet<PersonelCocuk> PersonelCocuk { get; set; }
        public virtual DbSet<PersonelEgitim> PersonelEgitim { get; set; }
        public virtual DbSet<PersonelKiyafet> PersonelKiyafet { get; set; }
        public virtual DbSet<PersonelOzlukBilgileri> PersonelOzlukBilgileri { get; set; }
        public virtual DbSet<PersonelPuantaj> PersonelPuantaj { get; set; }
        public virtual DbSet<PersonelSaglikDurumlari> PersonelSaglikDurumlari { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
