using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingYourPackage.API.Model.Dtos
{
    public class ShipmentRecord
    {
        public int Id { get; set; }
        public int TrackingNbr { get; set; }
        public string ShippingAddress { get; set; }
        public string Zipcode { get; set; }
        public Nullable<int> AffiliateReferenceNbr { get; set; }
        public Nullable<int> PackageReceiverNbr { get; set; }
        public Nullable<int> ShipmentTypeId { get; set; }

        public virtual PackageReceiverRecord PackageReceiver { get; set; }
    }
}
