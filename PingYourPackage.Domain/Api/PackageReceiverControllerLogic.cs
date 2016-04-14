using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PingYourPackage.Domain.Contracts;
using DTO = PingYourPackage.API.Model.Dtos;
using Model = PingYourPackage.Domain.Data.Models;
using Repository = PingYourPackage.Domain.Data.Repositories;

namespace PingYourPackage.Domain.Api
{
    public class PackageReceiverControllerLogic : IPackageReceiverControllerLogic
    {
        private readonly Data.Contracts.IRepository<Model.PackageReceiver> Repository;

        public PackageReceiverControllerLogic(Repository.PackageReceiverRepository repo)
        {
            this.Repository = repo;
        }

        public IEnumerable<DTO.PackageReceiverRecord> GetAllPackageReceivers()
        {
            var query = this.Repository.GetAll();
            if (query != null && query.Count() > 0)
            {
                var records = new List<DTO.PackageReceiverRecord>();
                foreach (var item in query)
                {
                    var prItem = AutoMapper.Mapper.Map<Model.PackageReceiver, DTO.PackageReceiverRecord>(item);
                    records.Add(prItem);
                }
                return records;
            }
            return null;
        }
    }
}
