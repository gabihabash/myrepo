using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PingYourPackage.Domain.Data.Contracts
{
    public interface IAffiliateRepository<T> : IRepository<T> where T : IEntity
    {
        T GetAffiliateByReferenceNumber(string number);
    }
}
