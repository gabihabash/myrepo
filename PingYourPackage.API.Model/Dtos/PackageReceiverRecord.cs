﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingYourPackage.API.Model.Dtos
{
    public class PackageReceiverRecord
    {
        public int Id { get; set; }
        public int ReceiverNbr { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

    }
}