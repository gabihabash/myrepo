﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PingYourPackage.Domain.Data
{
    using PingYourPackage.Domain.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PingYourPackageEntities : DbContext
    {
        public PingYourPackageEntities()
            : base("name=PingYourPackageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<PackageReceiver> PackageReceivers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentType> ShipmentTypes { get; set; }
    }
}
