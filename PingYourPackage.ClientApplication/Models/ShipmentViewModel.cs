using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingYourPackage.ClientApplication.Models
{
    public class ShipmentViewModel
    {
        public int Id { get; set; }
        public int TrackingNbr { get; set; }
        public string ShippingAddress { get; set; }
        public string Zipcode { get; set; }
        public int AffilateRefNbr { get; set; }
        public PackageReceiverViewModel PackageReceiver { get; set; }
    }
}