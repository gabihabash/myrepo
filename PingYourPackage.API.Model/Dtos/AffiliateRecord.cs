using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingYourPackage.API.Model.Dtos
{
    public class AffiliateRecord
    {
        public int Id { get; set; }
        public int ReferenceNbr { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}
