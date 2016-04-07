using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingYourPackage.Domain.Data.Contracts
{
    public interface IShipmentRepository<T> : IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetShipmentsByAffiliateId(int id);
        T GetShipmentByTrackingNumber(string number);
    }
}
