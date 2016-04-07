//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PingYourPackage.Domain.Data.Models
{
    using PingYourPackage.Domain.Data.Contracts;
    using System;
    using System.Collections.Generic;

    public partial class Shipment : IEntity
    {
        public int Id { get; set; }
        public int TrackingNbr { get; set; }
        public string ShippingAddress { get; set; }
        public string Zipcode { get; set; }
        public Nullable<int> AffiliateReferenceNbr { get; set; }
        public Nullable<int> PackageReceiverNbr { get; set; }
        public Nullable<int> ShipmentTypeId { get; set; }

        public virtual Affiliate Affiliate { get; set; }
        public virtual PackageReceiver PackageReceiver { get; set; }
        public virtual ShipmentType ShipmentType { get; set; }
    }
}