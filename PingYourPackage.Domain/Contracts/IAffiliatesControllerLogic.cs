using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;

namespace PingYourPackage.Domain.Contracts
{
    public interface IAffiliatesControllerLogic
    {
        DTO.AffiliateRecord GetAffiliate(int id);
        IEnumerable<DTO.AffiliateRecord> GetAllAffiliates();
        DTO.AffiliateRecord InsertAffiliate(DTO.AffiliateRecord record);
        DTO.AffiliateRecord ModifyAffiliate(int id, DTO.AffiliateRecord record);
        ResponseModels.Result RemoveAffiliate(int id);
        DTO.AffiliateRecord GetAffiliateByReferenceNumber(string number);
    }
}
