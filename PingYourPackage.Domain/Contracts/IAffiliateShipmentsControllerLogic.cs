using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;

namespace PingYourPackage.Domain.Contracts
{
    public interface IAffiliateShipmentsControllerLogic
    {
       IEnumerable<DTO.ShipmentRecord> GetShipmentsByAffiliateId(int id);

    }
}
