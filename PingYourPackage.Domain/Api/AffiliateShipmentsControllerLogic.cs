using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using Model = PingYourPackage.Domain.Data.Models;
using Repository = PingYourPackage.Domain.Data.Repositories;
using Contracts = PingYourPackage.Domain.Contracts;

namespace PingYourPackage.Domain.Api
{
    public class AffiliateShipmentsControllerLogic : Contracts.IAffiliateShipmentsControllerLogic
    {
        private readonly Data.Contracts.IShipmentRepository<Model.Shipment> ShipmentsRepository;

        public AffiliateShipmentsControllerLogic(Repository.ShipmentRepository shipmentRepo)
        {
            this.ShipmentsRepository = shipmentRepo;
        }

        public IEnumerable<DTO.ShipmentRecord> GetShipmentsByAffiliateId(int id)
        {
            var query = this.ShipmentsRepository.GetShipmentsByAffiliateId(id);
            if (query != null && query.Count() > 0)
            {
                var shipmentRecords = new List<DTO.ShipmentRecord>();
                foreach (var item in query)
                {
                    var shipmentItem = AutoMapper.Mapper.Map<Model.Shipment, DTO.ShipmentRecord>(item);
                    shipmentRecords.Add(shipmentItem);
                }
                return shipmentRecords;
            }
            return null;
        }
    }
}
