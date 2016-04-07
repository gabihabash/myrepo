using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using Model = PingYourPackage.Domain.Data.Models;
using Repository = PingYourPackage.Domain.Data.Repositories;
using Contracts = PingYourPackage.Domain.Contracts;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;

namespace PingYourPackage.Domain.Api
{
    public class AffiliatesControllerLogic : Contracts.IAffiliatesControllerLogic
    {
        private readonly Data.Contracts.IAffiliateRepository<Model.Affiliate> Repository;

        public AffiliatesControllerLogic(Repository.AffiliateRepository affiliateRepository)
        {
            this.Repository = affiliateRepository;
        }

        public DTO.AffiliateRecord GetAffiliate(int id)
        {
            var query = this.Repository.GetSingle(id);
            if (query != null)
            { 
                return AutoMapper.Mapper.Map<Model.Affiliate, DTO.AffiliateRecord>(query);
            }
            return null;
        }

        public IEnumerable<DTO.AffiliateRecord> GetAllAffiliates()
        {
            var query = this.Repository.GetAll();
            if (query != null && query.Count() > 0)
            {
                var affiliateRecords = new List<DTO.AffiliateRecord>();
                foreach (var item in query)
                {
                    var affiliateItem = AutoMapper.Mapper.Map<Model.Affiliate, DTO.AffiliateRecord>(item);
                    affiliateRecords.Add(affiliateItem);
                }
                return affiliateRecords;
            }
            return null;
        }

        public DTO.AffiliateRecord InsertAffiliate(DTO.AffiliateRecord affiliateRecord)
        {
            int result = 0;
            if (affiliateRecord != null)
            {
                var affiliate = AutoMapper.Mapper.Map<DTO.AffiliateRecord, Model.Affiliate>(affiliateRecord);
                result = this.Repository.Add(affiliate);

                if (result > 0)
                {
                    return AutoMapper.Mapper.Map<Model.Affiliate, DTO.AffiliateRecord>(affiliate);
                }
            }
            return null;
        }

        public DTO.AffiliateRecord ModifyAffiliate(int id, DTO.AffiliateRecord affiliateRecord)
        {
            int result = 0;
            if (id > 0 && affiliateRecord != null)
            {
                var affiliate = AutoMapper.Mapper.Map<DTO.AffiliateRecord, Model.Affiliate>(affiliateRecord);
                result = this.Repository.Edit(id, affiliate);

                if (result > 0)
                {
                    return AutoMapper.Mapper.Map<Model.Affiliate, DTO.AffiliateRecord>(affiliate);
                }
            }
            return null;
        }

        public ResponseModels.Result RemoveAffiliate(int id)
        {
            int result = 0;
            if (id > 0)
            {
                result = this.Repository.Delete(id);
                if (result > 0)
                {
                    return null;
                }
            }
            return new ResponseModels.Result("Record could not be found.");

        }

        public DTO.AffiliateRecord GetAffiliateByReferenceNumber(string number)
        {
            if (!string.IsNullOrWhiteSpace(number))
            {
                var query = this.Repository.GetAffiliateByReferenceNumber(number);
                if (query != null)
                {
                    return AutoMapper.Mapper.Map<Model.Affiliate, DTO.AffiliateRecord>(query);
                }
            }
            return null;
        }
    }
}
